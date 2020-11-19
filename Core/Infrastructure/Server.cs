using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    /// <summary>
    /// The Server is the only layer that keeps a connection with a Client.
    /// They all share the same database meaning they all share the same rooms and players.
    /// The Server handle the chat and rooms for its Clients and share informations to its sole Server Manager.
    /// </summary>
    public class Server
    {
        public readonly List<IOnlineConnection> ListPlayer;
        public readonly List<IOnlineConnection> ListPlayerToRemove;

        public readonly Dictionary<string, ClientGroup> DicLocalRoom;
        public readonly List<string> ListLocalRoomToRemove;

        public readonly Dictionary<string, ClientGroup> DicTransferingRoom;
        public readonly List<string> ListTransferingRoomToRemove;

        public readonly Dictionary<string, IRoomInformations> DicAllRoom;

        public string IP;
        public int Port;
        public string ServerVersion;
        public string LatestVersion;//If a Server doesn't have the latest version and there are no Client connected, it can be closed as it won't receive new Clients.

        private DateTimeOffset NextRoomUpdateTime;

        public readonly IDataManager Database;
        public readonly OnlineWriter SharedWriteBuffer;
        private readonly Dictionary<string, OnlineScript> DicOnlineScripts;

        private TcpListener ClientsListener;

        private CancellationTokenSource CancelToken;

        public Server(IDataManager Database)
        {
            ListPlayer = new List<IOnlineConnection>();
            ListPlayerToRemove = new List<IOnlineConnection>();

            DicLocalRoom = new Dictionary<string, ClientGroup>();
            ListLocalRoomToRemove = new List<string>();

            DicTransferingRoom = new Dictionary<string, ClientGroup>();
            ListTransferingRoomToRemove = new List<string>();

            DicAllRoom = new Dictionary<string, IRoomInformations>();

            SharedWriteBuffer = new OnlineWriter();

            DicOnlineScripts = new Dictionary<string, OnlineScript>();
            DicOnlineScripts.Add(AskGameDataScriptServer.ScriptName, new AskGameDataScriptServer());
            DicOnlineScripts.Add(AskStartGameScriptServer.ScriptName, new AskStartGameScriptServer(this));
            DicOnlineScripts.Add(TransferRoomScriptServer.ScriptName, new AskRoomListScriptServer(this));
            DicOnlineScripts.Add(CreateRoomScriptServer.ScriptName, new CreateRoomScriptServer(this));
            DicOnlineScripts.Add(SendGameDataScriptServer.ScriptName, new SendGameDataScriptServer(this));
            DicOnlineScripts.Add(StartGameScriptServer.ScriptName, new StartGameScriptServer());
            DicOnlineScripts.Add(TransferRoomScriptServer.ScriptName, new TransferRoomScriptServer(this));

            this.Database = Database;
        }

        public Server(IDataManager Database, Dictionary<string, OnlineScript> DicOnlineScripts)
        {
            ListPlayer = new List<IOnlineConnection>();
            ListPlayerToRemove = new List<IOnlineConnection>();

            DicLocalRoom = new Dictionary<string, ClientGroup>();
            ListLocalRoomToRemove = new List<string>();

            DicTransferingRoom = new Dictionary<string, ClientGroup>();
            ListTransferingRoomToRemove = new List<string>();

            DicAllRoom = new Dictionary<string, IRoomInformations>();

            SharedWriteBuffer = new OnlineWriter();

            NextRoomUpdateTime = DateTimeOffset.Now;

            this.DicOnlineScripts = DicOnlineScripts;

            this.Database = Database;
        }

        private void WaitForConnections()
        {
            if (ClientsListener.Pending())
            {
                TcpClient ConnectingClient = ClientsListener.AcceptTcpClient();
                ConnectingClient.NoDelay = true;

                NetworkStream ClientStream = ConnectingClient.GetStream();

                IOnlineConnection NewConnection = new OnlineConnection(ConnectingClient, ClientStream, new Dictionary<string, OnlineScript>(DicOnlineScripts), SharedWriteBuffer);
                OnClientConnected(NewConnection);
            }
        }

        private void Update()
        {
            while (!CancelToken.IsCancellationRequested)
            {
                WaitForConnections();
                UpdatePlayers();
            }

            ClientsListener.Stop();
            ClientsListener = null;
        }

        public void UpdatePlayers()
        {
            Parallel.ForEach(ListPlayer, (ActivePlayer, loopState) =>
            {
                if (!ActivePlayer.IsConnected())
                {
                    if (ActivePlayer.HasLeftServer())
                    {
                        ListPlayerToRemove.Add(ActivePlayer);
                    }
                }
                else
                {
                    foreach (OnlineScript ActiveScript in ActivePlayer.ReadScripts())
                    {
                        ActiveScript.Execute(ActivePlayer);
                    }
                }
            });

            while (ListPlayerToRemove.Count > 0)
            {
                ListPlayer.Remove(ListPlayerToRemove[0]);
                ListPlayerToRemove.RemoveAt(0);
            }

            Parallel.ForEach(DicLocalRoom.Values, (ActiveGroup, loopState) =>
            {
                if (ActiveGroup.IsRunningSlow())
                {
                    //Send Room to another Server
                }

                if (ActiveGroup.CurrentGame != null)
                {
                    ActiveGroup.CurrentGame.Update(0f);
                }

                for (int P = ActiveGroup.Room.ListOnlinePlayer.Count - 1; P >= 0; --P)
                {
                    IOnlineConnection ActivePlayer = ActiveGroup.Room.ListOnlinePlayer[P];

                    if (!ActivePlayer.IsConnected())
                    {
                        if (ActivePlayer.HasLeftServer())
                        {
                            ActiveGroup.Room.ListOnlinePlayer.RemoveAt(P);
                            Database.UpdatePlayerCountInRoom(ActiveGroup.Room.RoomID, ActiveGroup.Room.ListOnlinePlayer.Count);

                            if (ActiveGroup.Room.ListOnlinePlayer.Count == 0)
                            {
                                ListLocalRoomToRemove.Add(ActiveGroup.Room.RoomID);
                            }
                        }
                    }
                    else
                    {
                        foreach (OnlineScript ActiveScript in ActivePlayer.ReadScripts())
                        {
                            ActiveScript.Execute(ActivePlayer);
                        }
                    }
                }
            });

            while (ListLocalRoomToRemove.Count > 0)
            {
                DicLocalRoom.Remove(ListLocalRoomToRemove[0]);
                Database.RemoveRoom(ListLocalRoomToRemove[0]);
                ListLocalRoomToRemove.RemoveAt(0);
            }

            foreach (ClientGroup ActiveGroup in DicTransferingRoom.Values)
            {
                foreach (IOnlineConnection ActivePlayer in ActiveGroup.Room.ListOnlinePlayer)
                {
                    foreach (OnlineScript ActiveScript in ActivePlayer.ReadScripts())
                    {
                        ActiveScript.Execute(ActivePlayer);
                    }
                }

                if (ActiveGroup.Room.ListOnlinePlayer.Count == ActiveGroup.Room.CurrentPlayerCount && ActiveGroup.CurrentGame != null)
                {
                    ListTransferingRoomToRemove.Add(ActiveGroup.Room.RoomID);
                }
            }

            while (ListTransferingRoomToRemove.Count > 0)
            {
                DicLocalRoom.Add(ListTransferingRoomToRemove[0], DicTransferingRoom[ListTransferingRoomToRemove[0]]);
                DicTransferingRoom.Remove(ListTransferingRoomToRemove[0]);
                ListTransferingRoomToRemove.RemoveAt(0);
            }

            //TODO: Run task in background
            if (DateTimeOffset.Now > NextRoomUpdateTime)
            {
                NextRoomUpdateTime = NextRoomUpdateTime.AddSeconds(10);

                List<IRoomInformations> ListRoomUpdates = Database.GetAllRoomUpdatesSinceLastTimeChecked(ServerVersion);

                if (ListRoomUpdates != null && ListRoomUpdates.Count > 0)
                {
                    foreach (IRoomInformations ActiveRoomUpdate in ListRoomUpdates)
                    {
                        if (ActiveRoomUpdate.IsDead)
                        {
                            DicAllRoom.Remove(ActiveRoomUpdate.RoomID);
                        }
                        else if (DicAllRoom.ContainsKey(ActiveRoomUpdate.RoomID))
                        {
                            DicAllRoom[ActiveRoomUpdate.RoomID] = ActiveRoomUpdate;
                        }
                        else
                        {
                            DicAllRoom.Add(ActiveRoomUpdate.RoomID, ActiveRoomUpdate);
                        }
                    }

                    SharedWriteBuffer.ClearWriteBuffer();
                    SharedWriteBuffer.WriteScript(new RoomListScriptServer(this, ListRoomUpdates));

                    foreach (IOnlineConnection ActivePlayer in ListPlayer)
                    {
                        ActivePlayer.SendWriteBuffer();
                    }
                }
            }
        }

        public void StartListening(string PublicIP, int ClientsPort)
        {
            try
            {
                CancelToken = new CancellationTokenSource();

                IPEndPoint ListeningEndPointClient = new IPEndPoint(IPAddress.Any, ClientsPort);
                ClientsListener = new TcpListener(ListeningEndPointClient);
                ClientsListener.Start();

                this.IP = PublicIP;
                this.Port = ClientsPort;

                Database.DeleteOldRooms(IP, Port);

                Task.Run(() => { Update(); });
            }
            catch (Exception)
            {
                ClientsListener = null;
            }
        }

        public void StopListening()
        {
            CancelToken.Cancel();
        }

        public void OnClientConnected(IOnlineConnection NewClient)
        {
            ListPlayer.Add(NewClient);
        }

        public ClientGroup TransferRoom(string RoomID)
        {
            IRoomInformations UpdatedRoom = Database.TransferRoom(RoomID, IP);

            return new ClientGroup(UpdatedRoom);
        }
    }
}

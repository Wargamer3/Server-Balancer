using System;
using System.IO;
using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    /// <summary>
    /// Only contains barebone display information about a room
    /// </summary>

    public class RoomInformations : IRoomInformations
    {
        public string RoomID { get; }//Only contains a value for locally create Rooms, if the Room is on another server the ID should be null.
        public List<IOnlineConnection> ListOnlinePlayer { get; }
        public int CurrentPlayerCount { get; }
        public int MaxNumberOfPlayer { get; }
        public string OwnerServerIP { get; }
        public int OwnerServerPort { get; }
        public bool IsDead { get; set; }//Used when the DataManager need to tell that a Room is deleted.

        public string RoomName { get; }
        public string MapName { get; set; }
        public readonly List<Player> ListRoomPlayer;
        public string Password;

        public RoomInformations(string RoomID, bool IsDead)
        {
            this.RoomID = RoomID;
            this.IsDead = IsDead;

            ListOnlinePlayer = new List<IOnlineConnection>();
            ListRoomPlayer = new List<Player>();
            RoomName = "";
            OwnerServerIP = null;
            OwnerServerPort = 0;
            CurrentPlayerCount = 0;
            MaxNumberOfPlayer = 0;
        }

        public RoomInformations(string ID, string Name, string OwnerServerIP, int OwnerServerPort)
        {
            this.RoomID = ID;
            this.RoomName = Name;
            this.OwnerServerIP = OwnerServerIP;
            this.OwnerServerPort = OwnerServerPort;

            ListOnlinePlayer = new List<IOnlineConnection>();
            ListRoomPlayer = new List<Player>();
            IsDead = false;
            CurrentPlayerCount = 1;
            MaxNumberOfPlayer = 3;
        }

        public RoomInformations(string RoomID, string Name, int MaxPlayer, int CurrentClientCount)
        {
            this.RoomID = RoomID;
            this.RoomName = Name;
            this.MaxNumberOfPlayer = MaxPlayer;
            this.CurrentPlayerCount = CurrentClientCount;

            ListOnlinePlayer = new List<IOnlineConnection>();
            ListRoomPlayer = new List<Player>();
            IsDead = false;
            OwnerServerIP = null;
            OwnerServerPort = 0;
        }

        public RoomInformations(string RoomID, string RoomName, string Password, string OwnerServerIP, int OwnerServerPort, int CurrentPlayerCount, int MaxNumberOfPlayer, bool IsDead)
        {
            this.RoomID = RoomID;
            this.RoomName = RoomName;
            this.Password = Password;
            this.OwnerServerIP = OwnerServerIP;
            this.OwnerServerPort = OwnerServerPort;
            this.CurrentPlayerCount = CurrentPlayerCount;
            this.MaxNumberOfPlayer = MaxNumberOfPlayer;
            this.IsDead = IsDead;
        }

        public void AddPlayer(IOnlineConnection NewPlayer)
        {
            ListOnlinePlayer.Add(NewPlayer);
            Player NewRoomPlayer = new Player();
            NewRoomPlayer.ID = NewPlayer.ID;
            NewRoomPlayer.Name = NewPlayer.Name;
            ListRoomPlayer.Add(NewRoomPlayer);
        }

        public void RemovePlayer(IOnlineConnection OnlinePlayerToRemove)
        {
            for (int P = 0; P < ListOnlinePlayer.Count; ++P)
            {
                if (ListOnlinePlayer[P] == OnlinePlayerToRemove)
                {
                    ListOnlinePlayer.RemoveAt(P);
                    ListRoomPlayer.RemoveAt(P);

                    if (ListOnlinePlayer.Count == 0)
                    {
                        IsDead = true;
                    }
                }
            }
        }

        public Player GetPlayer(IOnlineConnection Sender)
        {
            for (int P = 0; P < ListOnlinePlayer.Count; ++P)
            {
                if (ListOnlinePlayer[P] == Sender)
                {
                    return ListRoomPlayer[P];

                }
            }

            return null;
        }

        public byte[] GetRoomInfo()
        {
            using (MemoryStream MS = new MemoryStream())
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(ListRoomPlayer.Count);
                    for (int P = 0; P < ListRoomPlayer.Count; P++)
                    {
                        BW.Write(ListRoomPlayer[P].ID);
                        BW.Write(ListRoomPlayer[P].Name);
                    }

                    return MS.ToArray();
                }
            }
        }

        public override string ToString()
        {
            return RoomName + " - " + RoomID;
        }
    }
}

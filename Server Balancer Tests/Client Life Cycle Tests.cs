using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEternity.Core.Online;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        Dictionary<string, OnlineScript> DicServerOnlineScripts;
        Dictionary<string, OnlineScript> DicClientOnlineScripts;

        List<OnlineScript> ListMasterScriptRead;

        List<OnlineScript> ListServerManagerScriptRead;

        List<OnlineScript> ListClientToServerScriptSent;
        List<OnlineScript> ListServerToClientScriptSent;

        DummyOnlineConnection MockMasterToClientConnection;
        DummyOnlineConnection MockClientToMasterConnection;

        DummyOnlineConnection MockServerManagerToClientConnection;
        DummyOnlineConnection MockClientToServerManagerConnection;

        DummyOnlineConnection MockServerToClientConnection;
        DummyOnlineConnection MockClientToServerConnection;

        [TestInitialize]
        public void Init()
        {
            DicServerOnlineScripts = new Dictionary<string, OnlineScript>();
            DicClientOnlineScripts = new Dictionary<string, OnlineScript>();

            ListMasterScriptRead = new List<OnlineScript>();

            ListServerManagerScriptRead = new List<OnlineScript>();

            ListClientToServerScriptSent = new List<OnlineScript>();
            ListServerToClientScriptSent = new List<OnlineScript>();

            MockMasterToClientConnection = new DummyOnlineConnection("MockMasterToClientConnection", DicServerOnlineScripts, ListMasterScriptRead);
            MockClientToMasterConnection = new DummyOnlineConnection("MockClientToMasterConnection", DicClientOnlineScripts, ListMasterScriptRead);

            MockServerManagerToClientConnection = new DummyOnlineConnection("MockServerManagerToClientConnection", DicServerOnlineScripts, ListServerManagerScriptRead);
            MockClientToServerManagerConnection = new DummyOnlineConnection("MockClientToServerManagerConnection", DicClientOnlineScripts, ListServerManagerScriptRead);

            MockServerToClientConnection = new DummyOnlineConnection("MockServerToClientConnection", DicServerOnlineScripts, ListClientToServerScriptSent, ListServerToClientScriptSent);
            MockClientToServerConnection = new DummyOnlineConnection("MockClientToServerConnection", DicClientOnlineScripts, ListServerToClientScriptSent, ListClientToServerScriptSent);
        }

        [TestMethod]
        public void TestClientToServerThroughMasterConnection()
        {
            Client ClientTest = new Client();

            DicServerOnlineScripts.Add("Redirect", new RedirectScriptServer());
            DicClientOnlineScripts.Add("Redirect", new DummyRedirectScriptClient(ClientTest, MockClientToServerManagerConnection));

            Master MasterTest = new Master();

            ClientTest.ChangeHost(MockClientToMasterConnection);

            MasterTest.OnClientConnected(MockMasterToClientConnection);

            ClientTest.Update();

            Assert.AreEqual(MockClientToServerManagerConnection, ClientTest.Host);
            DicClientOnlineScripts["Redirect"] = new DummyRedirectScriptClient(ClientTest, MockClientToServerConnection);

            ServerManager ServerManagerTest = new ServerManager();

            ServerManagerTest.OnClientConnected(MockServerManagerToClientConnection);

            ClientTest.Update();

            Assert.AreEqual(MockClientToServerConnection, ClientTest.Host);
            Assert.AreEqual(MockClientToServerManagerConnection, ClientTest.LastTopLevel);
        }

        [TestMethod]
        public void TestClientServerTransferWhileInRoom()
        {
            string DummyRoomID = "Dummy Room";

            Client ClientTest = new Client();

            DicServerOnlineScripts.Add("Redirect", new RedirectScriptServer());
            DicClientOnlineScripts.Add("Redirect", new DummyRedirectScriptClient(ClientTest, MockClientToServerManagerConnection));

            Master MasterTest = new Master();

            ClientTest.ChangeHost(MockClientToMasterConnection);

            MasterTest.OnClientConnected(MockMasterToClientConnection);

            ClientTest.Update();

            DicClientOnlineScripts["Redirect"] = new DummyRedirectScriptClient(ClientTest, MockClientToServerConnection);

            ServerManager ServerManagerTest = new ServerManager();

            ServerManagerTest.OnClientConnected(MockServerManagerToClientConnection);
            ClientTest.Update();
            Assert.AreEqual(MockClientToServerConnection, ClientTest.Host);

            Server ServerTest = new Server(new DummyDataManager(DummyRoomID));
            ServerTest.OnClientConnected(MockServerToClientConnection);

            DicServerOnlineScripts.Add("Create Room", new CreateRoomScriptServer(ServerTest));
            DicClientOnlineScripts.Add("Create Room", new CreateRoomScriptClient(""));
            DicServerOnlineScripts.Add("Send Room Information", new SendRoomIDScriptServer(""));
            DicClientOnlineScripts.Add("Send Room Information", new DummySendRoomInformationScriptClient(ClientTest, DummyRoomID));

            //Create Room
            ClientTest.CreateRoom("");
            ServerTest.UpdatePlayers();
            ClientTest.Update();
            Assert.AreEqual(0, ServerTest.ListPlayer.Count);
            Assert.AreEqual(DummyRoomID, ClientTest.RoomID);

            DicServerOnlineScripts.Add("Ask Start Game", new DummyAskStartGameScriptServer(ServerTest, ClientTest.RoomID));
            DicClientOnlineScripts.Add("Ask Start Game", new AskStartGameScriptClient());
            DicClientOnlineScripts.Add("Start Game", new DummyStartGameScriptClient(ClientTest));

            //Start Game
            ClientTest.StartGame();
            ServerTest.UpdatePlayers();
            Assert.IsNotNull(ServerTest.DicLocalRoom[ClientTest.RoomID].CurrentGame);
            ClientTest.Update();
            Assert.IsNotNull(ClientTest.CurrentGame);

            //Lose connection to Server, connect back to Server Manager
            MockClientToServerConnection.Connected = false;
            ClientTest.Update();
            Assert.AreEqual(MockClientToServerManagerConnection, ClientTest.Host);
            Assert.IsNull(ClientTest.LastTopLevel);

            //Get new Server
            MockServerToClientConnection.Clear();
            MockClientToServerConnection.Clear();
            ServerTest = new Server(new DummyDataManager(DummyRoomID));
            ServerTest.DicAllRoom.Add(DummyRoomID, new RoomInformations(DummyRoomID, "", "", 0));

            MockClientToServerConnection.Connected = true;
            ServerManagerTest.OnClientConnected(MockServerManagerToClientConnection);
            ClientTest.Update();
            Assert.AreEqual(MockClientToServerConnection, ClientTest.Host);

            ServerTest.OnClientConnected(MockServerToClientConnection);
            Assert.IsFalse(ServerTest.DicLocalRoom.ContainsKey(ClientTest.RoomID));

            //Send Server the game data
            DicServerOnlineScripts.Add("Transfer Room", new TransferRoomScriptServer(ServerTest, DummyRoomID));
            ServerTest.UpdatePlayers();
            Assert.AreEqual(1, ServerTest.DicTransferingRoom.Count);

            DicClientOnlineScripts.Add("Ask Game Data", new AskGameDataScriptClient(ClientTest));
            ClientTest.Update();

            DicServerOnlineScripts.Add("Send Game Data", new DummySendGameDataScriptServer(ServerTest, DummyRoomID));
            ServerTest.UpdatePlayers();

            //Wait for sync
            Assert.AreEqual(0, ServerTest.DicTransferingRoom.Count);
            Assert.AreEqual(1, ServerTest.DicLocalRoom.Count);
            Assert.IsNotNull(ServerTest.DicLocalRoom[ClientTest.RoomID].CurrentGame);
        }

        [TestMethod]
        public void TestClientJoinWaitingRoomOnSameServer()
        {
            string DummyRoomID = "Dummy Room";

            Client ClientTest = new Client();
            ClientTest.ChangeHost(MockClientToServerConnection);
            Server ServerTest = new Server(new DummyDataManager(DummyRoomID));
            ServerTest.OnClientConnected(MockServerToClientConnection);

            DicServerOnlineScripts.Add("Create Room", new CreateRoomScriptServer(ServerTest));
            DicClientOnlineScripts.Add("Create Room", new CreateRoomScriptClient(""));
            DicServerOnlineScripts.Add("Send Room Information", new SendRoomIDScriptServer(""));
            DicClientOnlineScripts.Add("Send Room Information", new DummySendRoomInformationScriptClient(ClientTest, DummyRoomID));

            //Create Room
            ClientTest.CreateRoom("");
            ServerTest.UpdatePlayers();
            ClientTest.Update();
            Assert.AreEqual(0, ServerTest.ListPlayer.Count);
            Assert.AreEqual(DummyRoomID, ClientTest.RoomID);

            DicServerOnlineScripts.Add("Ask Start Game", new DummyAskStartGameScriptServer(ServerTest, ClientTest.RoomID));
            DicClientOnlineScripts.Add("Ask Start Game", new AskStartGameScriptClient());
            DicClientOnlineScripts.Add("Start Game", new DummyStartGameScriptClient(ClientTest));

            //Client 2 connect to the server
            var DicClient2OnlineScripts = new Dictionary<string, OnlineScript>();
            List<OnlineScript> ListClient2ToServerScriptSent = new List<OnlineScript>();
            List<OnlineScript> ListServerToClient2ScriptSent = new List<OnlineScript>();
            DummyOnlineConnection MockServerToClient2Connection = new DummyOnlineConnection("MockServerToClient2Connection", DicServerOnlineScripts, ListClient2ToServerScriptSent, ListServerToClient2ScriptSent);
            DummyOnlineConnection MockClient2ToServerConnection = new DummyOnlineConnection("MockClient2ToServerConnection", DicClient2OnlineScripts, ListServerToClient2ScriptSent, ListClient2ToServerScriptSent);
            
            Client ClientTest2 = new Client();
            ClientTest2.ChangeHost(MockClient2ToServerConnection);
            ServerTest.OnClientConnected(MockServerToClient2Connection);
            Assert.AreEqual(1, ServerTest.ListPlayer.Count);

            //Client 2 join the room
            DicServerOnlineScripts.Add("Ask Join Room", new DummyAskJoinRoomScriptServer(ServerTest, DummyRoomID));
            DicClient2OnlineScripts.Add("Join Room Local", new DummyJoinRoomLocalScriptClient(ClientTest2, DummyRoomID, false));
            ClientTest2.JoinRoom(DummyRoomID);
            Assert.IsNull(ClientTest2.RoomID);
            ServerTest.UpdatePlayers();
            Assert.AreEqual(0, ServerTest.ListPlayer.Count);
            Assert.AreEqual(2, ServerTest.DicLocalRoom[DummyRoomID].Room.ListOnlinePlayer.Count);
            ClientTest2.Update();
            Assert.AreEqual(DummyRoomID, ClientTest2.RoomID);

            //Start Game
            DicClient2OnlineScripts.Add("Start Game", new DummyStartGameScriptClient(ClientTest2));
            ClientTest.StartGame();
            ServerTest.UpdatePlayers();
            Assert.IsNotNull(ServerTest.DicLocalRoom[DummyRoomID].CurrentGame);
            ClientTest.Update();
            Assert.IsNotNull(ClientTest.CurrentGame);
            ClientTest2.Update();
            Assert.IsNotNull(ClientTest2.CurrentGame);
        }

        [TestMethod]
        public void TestClientJoinGameOnSameServer()
        {
            string DummyRoomID = "Dummy Room";

            Client ClientTest = new Client();
            ClientTest.ChangeHost(MockClientToServerConnection);
            Server ServerTest = new Server(new DummyDataManager(DummyRoomID));
            ServerTest.OnClientConnected(MockServerToClientConnection);

            DicServerOnlineScripts.Add("Create Room", new CreateRoomScriptServer(ServerTest));
            DicClientOnlineScripts.Add("Create Room", new CreateRoomScriptClient(""));
            DicServerOnlineScripts.Add("Send Room Information", new SendRoomIDScriptServer(""));
            DicClientOnlineScripts.Add("Send Room Information", new DummySendRoomInformationScriptClient(ClientTest, DummyRoomID));

            //Create Room
            ClientTest.CreateRoom("");
            ServerTest.UpdatePlayers();
            ClientTest.Update();
            Assert.AreEqual(0, ServerTest.ListPlayer.Count);
            Assert.AreEqual(DummyRoomID, ClientTest.RoomID);

            DicServerOnlineScripts.Add("Ask Start Game", new DummyAskStartGameScriptServer(ServerTest, ClientTest.RoomID));
            DicClientOnlineScripts.Add("Ask Start Game", new AskStartGameScriptClient());
            DicClientOnlineScripts.Add("Start Game", new DummyStartGameScriptClient(ClientTest));

            //Start Game
            ClientTest.StartGame();
            ServerTest.UpdatePlayers();
            Assert.IsNotNull(ServerTest.DicLocalRoom[DummyRoomID].CurrentGame);
            ClientTest.Update();
            Assert.IsNotNull(ClientTest.CurrentGame);

            //Client 2 connect to the server
            var DicClient2OnlineScripts = new Dictionary<string, OnlineScript>();
            List<OnlineScript> ListClient2ToServerScriptSent = new List<OnlineScript>();
            List<OnlineScript> ListServerToClient2ScriptSent = new List<OnlineScript>();
            DummyOnlineConnection MockServerToClient2Connection = new DummyOnlineConnection("MockServerToClient2Connection", DicServerOnlineScripts, ListClient2ToServerScriptSent, ListServerToClient2ScriptSent);
            DummyOnlineConnection MockClient2ToServerConnection = new DummyOnlineConnection("MockClient2ToServerConnection", DicClient2OnlineScripts, ListServerToClient2ScriptSent, ListClient2ToServerScriptSent);

            Client ClientTest2 = new Client();
            ClientTest2.ChangeHost(MockClient2ToServerConnection);
            ServerTest.OnClientConnected(MockServerToClient2Connection);
            Assert.AreEqual(1, ServerTest.ListPlayer.Count);

            //Client 2 join the room
            DicServerOnlineScripts.Add("Ask Join Room", new DummyAskJoinRoomScriptServer(ServerTest, DummyRoomID));
            DicClient2OnlineScripts.Add("Join Room Local", new DummyJoinRoomLocalScriptClient(ClientTest2, DummyRoomID, true));
            DicClient2OnlineScripts.Add("Start Game", new DummyStartGameScriptClient(ClientTest2));
            ClientTest2.JoinRoom(DummyRoomID);
            Assert.IsNull(ClientTest2.RoomID);
            ServerTest.UpdatePlayers();
            Assert.AreEqual(0, ServerTest.ListPlayer.Count);
            Assert.AreEqual(2, ServerTest.DicLocalRoom[DummyRoomID].Room.ListOnlinePlayer.Count);
            ClientTest2.Update();
            Assert.AreEqual(DummyRoomID, ClientTest2.RoomID);
            Assert.IsNotNull(ClientTest2.CurrentGame);
        }

        [TestMethod]
        public void TestClientJoinWaitingRoomOnDifferentServer()
        {
            string DummyRoomID = "Dummy Room";

            Client ClientTest = new Client();
            ClientTest.ChangeHost(MockClientToServerConnection);
            Server ServerTest = new Server(new DummyDataManager(DummyRoomID));
            ServerTest.IP = "1";
            ServerTest.OnClientConnected(MockServerToClientConnection);

            DicServerOnlineScripts.Add("Create Room", new CreateRoomScriptServer(ServerTest));
            DicClientOnlineScripts.Add("Create Room", new CreateRoomScriptClient(""));
            DicServerOnlineScripts.Add("Send Room Information", new SendRoomIDScriptServer(""));
            DicClientOnlineScripts.Add("Send Room Information", new DummySendRoomInformationScriptClient(ClientTest, DummyRoomID));

            //Create Room
            ClientTest.CreateRoom("");
            ServerTest.UpdatePlayers();
            ClientTest.Update();
            Assert.AreEqual(0, ServerTest.ListPlayer.Count);
            Assert.AreEqual(DummyRoomID, ClientTest.RoomID);

            DicServerOnlineScripts.Add("Ask Start Game", new DummyAskStartGameScriptServer(ServerTest, ClientTest.RoomID));
            DicClientOnlineScripts.Add("Ask Start Game", new AskStartGameScriptClient());
            DicClientOnlineScripts.Add("Start Game", new DummyStartGameScriptClient(ClientTest));

            //Client 2 connect to Server 2
            var DicClient2OnlineScripts = new Dictionary<string, OnlineScript>();
            List<OnlineScript> ListClient2ToServer2ScriptSent = new List<OnlineScript>();
            List<OnlineScript> ListServer2ToClient2ScriptSent = new List<OnlineScript>();
            List<OnlineScript> ListClient2ToServerScriptSent = new List<OnlineScript>();
            DummyOnlineConnection MockServer2ToClient2Connection = new DummyOnlineConnection("MockServer2ToClient2Connection", "2", DicServerOnlineScripts, ListClient2ToServer2ScriptSent, ListServer2ToClient2ScriptSent);
            DummyOnlineConnection MockClient2ToServer2Connection = new DummyOnlineConnection("MockClient2ToServer2Connection", "2", DicClient2OnlineScripts, ListServer2ToClient2ScriptSent, ListClient2ToServer2ScriptSent);
            DummyOnlineConnection MockClient2ToServerConnection = new DummyOnlineConnection("MockClient2ToServerConnection", "1", DicClient2OnlineScripts, ListServerToClientScriptSent, ListClient2ToServerScriptSent);
            DummyOnlineConnection MockServerToClient2Connection = new DummyOnlineConnection("MockServerToClient2Connection", "1", DicServerOnlineScripts, ListClient2ToServerScriptSent, ListServerToClientScriptSent);

            Server ServerTest2 = new Server(new DummyDataManager(DummyRoomID));
            ServerTest2.IP = "2";
            ServerTest2.DicAllRoom.Add(DummyRoomID, ServerTest.DicAllRoom[DummyRoomID]);
            Client ClientTest2 = new Client();
            ClientTest2.ChangeHost(MockClient2ToServer2Connection);
            ServerTest2.OnClientConnected(MockServer2ToClient2Connection);
            Assert.AreEqual(1, ServerTest2.ListPlayer.Count);
            Assert.AreEqual(ServerTest2.IP, ClientTest2.Host.IP);

            //Client 2 join the room from Server 2
            DicServerOnlineScripts.Add("Ask Join Room", new DummyAskJoinRoomScriptServer(ServerTest2, DummyRoomID));
            DicClient2OnlineScripts.Add("Join Room Remote", new DummyJoinRoomRemoteScriptClient(ClientTest2, MockClient2ToServerConnection, ServerTest, MockServerToClient2Connection, DummyRoomID));
            ClientTest2.JoinRoom(DummyRoomID);
            ServerTest2.UpdatePlayers();
            ClientTest2.Update();
            Assert.IsNull(ClientTest2.RoomID);
            DicServerOnlineScripts["Ask Join Room"] = new DummyAskJoinRoomScriptServer(ServerTest, DummyRoomID);
            DicClient2OnlineScripts.Add("Join Room Local", new DummyJoinRoomLocalScriptClient(ClientTest2, DummyRoomID, false));
            ServerTest.UpdatePlayers();
            Assert.AreEqual(2, ServerTest.DicLocalRoom[DummyRoomID].Room.ListOnlinePlayer.Count);
            ClientTest2.Update();
            Assert.AreEqual(DummyRoomID, ClientTest2.RoomID);
            Assert.AreEqual(ServerTest.IP, ClientTest2.Host.IP);
        }
    }
}

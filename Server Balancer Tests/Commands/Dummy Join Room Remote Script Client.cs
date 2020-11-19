using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummyJoinRoomRemoteScriptClient : OnlineScript
    {
        private readonly Client Owner;
        private readonly IOnlineConnection ClientToServerConnection;
        private readonly Server RemoteServer;
        private readonly IOnlineConnection RemoteServerToClientConnection;
        private readonly string RoomID;

        public DummyJoinRoomRemoteScriptClient(Client Owner, IOnlineConnection ClientToServerConnection, Server RemoteServer, IOnlineConnection RemoteServerToClientConnection, string RoomID)
            : base("Join Room Remote")
        {
            this.Owner = Owner;
            this.ClientToServerConnection = ClientToServerConnection;
            this.RemoteServer = RemoteServer;
            this.RemoteServerToClientConnection = RemoteServerToClientConnection;
            this.RoomID = RoomID;
        }

        public override OnlineScript Copy()
        {
            return new DummyJoinRoomRemoteScriptClient(Owner, ClientToServerConnection, RemoteServer, RemoteServerToClientConnection, RoomID);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            RemoteServer.OnClientConnected(RemoteServerToClientConnection);
            Owner.ChangeHost(ClientToServerConnection);

            ClientToServerConnection.Send(new AskJoinRoomScriptClient(RoomID));
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

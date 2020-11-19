using System;
using System.Net;

namespace ProjectEternity.Core.Online
{
    public class JoinRoomRemoteScriptClient : OnlineScript
    {
        private readonly Client Owner;

        private string RoomID;
        private string RemoteIP;
        private int RemotePort;

        public JoinRoomRemoteScriptClient(Client Owner)
            : base("Join Room Remote")
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected internal override void Execute(IOnlineConnection Host)
        {
            Owner.ChangeHost(IPAddress.Parse(RemoteIP), RemotePort);

            Owner.Host.Send(new AskJoinRoomScriptClient(RoomID));
        }

        protected internal override void Read(OnlineReader Sender)
        {
            RoomID = Sender.ReadString();
            RemoteIP = Sender.ReadString();
            RemotePort = Sender.ReadInt32();
        }
    }
}

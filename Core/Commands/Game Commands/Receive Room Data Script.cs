using System;

namespace ProjectEternity.Core.Online
{
    public class ReceiveRoomDataScript : OnlineScript
    {
        Server Owner;
        string RoomID;
        byte[] RoomData;

        public ReceiveRoomDataScript(Server Owner)
            : base("Transfer Room")
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

        protected internal override void Execute(IOnlineConnection ActivePlayer)
        {
        }

        protected internal override void Read(OnlineReader Sender)
        {
        }
    }
}

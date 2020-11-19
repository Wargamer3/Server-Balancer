using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummySendRoomInformationScriptClient : OnlineScript
    {
        private readonly Client Owner;
        private readonly string RoomID;

        public DummySendRoomInformationScriptClient(Client Owner, string RoomID)
            : base("Send Room Information")
        {
            this.Owner = Owner;
            this.RoomID = RoomID;
        }

        public override OnlineScript Copy()
        {
            return new DummySendRoomInformationScriptClient(Owner, RoomID);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            Owner.RoomID = RoomID;
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

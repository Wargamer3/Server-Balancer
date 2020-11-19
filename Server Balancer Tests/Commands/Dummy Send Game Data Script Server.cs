using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummySendGameDataScriptServer : OnlineScript
    {
        private readonly Server Owner;
        private readonly string RoomID;

        public DummySendGameDataScriptServer(Server Owner, string RoomID)
            : base("Send Game Data")
        {
            this.Owner = Owner;
            this.RoomID = RoomID;
        }

        public override OnlineScript Copy()
        {
            return new DummySendGameDataScriptServer(Owner, RoomID);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            Owner.DicTransferingRoom[RoomID].CurrentGame = new DummyGame();
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

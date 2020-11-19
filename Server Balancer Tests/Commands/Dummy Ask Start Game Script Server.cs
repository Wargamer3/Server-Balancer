using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummyAskStartGameScriptServer : OnlineScript
    {
        private readonly Server Owner;
        private readonly string RoomID;

        public DummyAskStartGameScriptServer(Server Owner, string RoomID)
            : base("Ask Start Game")
        {
            this.Owner = Owner;
            this.RoomID = RoomID;
        }

        public override OnlineScript Copy()
        {
            return new DummyAskStartGameScriptServer(Owner, RoomID);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            Owner.DicLocalRoom[RoomID].CurrentGame = new DummyGame();
            foreach (IOnlineConnection ActivePlayer in Owner.DicLocalRoom[RoomID].Room.ListOnlinePlayer)
            {
                ActivePlayer.Send(new StartGameScriptServer());
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

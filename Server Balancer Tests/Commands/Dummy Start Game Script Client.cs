using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummyStartGameScriptClient : OnlineScript
    {
        private readonly Client Owner;

        public DummyStartGameScriptClient(Client Owner)
            : base("Start Game")
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new DummyStartGameScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            Owner.CurrentGame = new DummyGame();
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

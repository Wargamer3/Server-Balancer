using System;

namespace ProjectEternity.Core.Online
{
    public class StartGameScriptClient : OnlineScript
    {
        private readonly Client Owner;

        public StartGameScriptClient(Client Owner)
            : base("Start Game")
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new StartGameScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected internal override void Execute(IOnlineConnection Sender)
        {
        }

        protected internal override void Read(OnlineReader Sender)
        {
        }
    }
}

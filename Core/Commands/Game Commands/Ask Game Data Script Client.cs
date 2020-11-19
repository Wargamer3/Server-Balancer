using System;

namespace ProjectEternity.Core.Online
{
    public class AskGameDataScriptClient : OnlineScript
    {
        private readonly Client Owner;

        public AskGameDataScriptClient(Client Owner)
            : base("Ask Game Data")
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new AskGameDataScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
        }

        protected internal override void Execute(IOnlineConnection Host)
        {
            Host.Send(new SendGameDataScriptClient(Owner));
        }

        protected internal override void Read(OnlineReader Sender)
        {
        }
    }
}

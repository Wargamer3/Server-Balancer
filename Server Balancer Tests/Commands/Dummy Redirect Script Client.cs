using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummyRedirectScriptClient : OnlineScript
    {
        private readonly Client Owner;
        private readonly IOnlineConnection Server;

        public DummyRedirectScriptClient(Client Owner, IOnlineConnection Server)
            : base("Redirect")
        {
            this.Owner = Owner;
            this.Server = Server;
        }

        public override OnlineScript Copy()
        {
            return new DummyRedirectScriptClient(Owner, Server);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection ActivePlayer)
        {
            Owner.ChangeHost(Server);
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

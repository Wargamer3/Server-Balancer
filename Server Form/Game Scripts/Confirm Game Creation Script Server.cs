using System;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class ConfirmGameCreationScriptServer : OnlineScript
    {
        public const string ScriptName = "Confirm Game Creation";

        private readonly PlayerWithID Owner;

        public ConfirmGameCreationScriptServer(PlayerWithID Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new ConfirmGameCreationScriptServer(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            Owner.HasFinishedLoadingGame = true;
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

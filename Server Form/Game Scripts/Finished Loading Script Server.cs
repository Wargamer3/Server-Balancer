using System;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class FinishedLoadingScriptServer : OnlineScript
    {
        public const string ScriptName = "Finished Loading";

        private readonly ClientGroup ActiveGroup;
        private readonly PlayerWithID Owner;

        public FinishedLoadingScriptServer(ClientGroup ActiveGroup, PlayerWithID Owner)
            : base(ScriptName)
        {
            this.ActiveGroup = ActiveGroup;
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new FinishedLoadingScriptServer(ActiveGroup, Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            if (ActiveGroup.CurrentGame.HasGameStarted)
            {
                Sender.Send(new StartGameScriptServer());
            }
            Owner.HasFinishedLoadingGame = true;
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

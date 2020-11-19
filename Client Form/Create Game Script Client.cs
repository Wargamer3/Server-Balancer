using System;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class CreateGameScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Create Game";

        private readonly ClientForm Owner;

        public CreateGameScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new CreateGameScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            Owner.ActiveGame = new TextGame(Owner.lstRoomPlayers.Items.Count);
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

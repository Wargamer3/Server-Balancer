using System;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class StartGameScriptClientForm : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Start Game";

        private readonly ClientForm Owner;

        public StartGameScriptClientForm(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new StartGameScriptClientForm(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.lstRoomPlayers.InvokeRequired)
            {
                Owner.lstRoomPlayers.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Owner.lstRoomPlayers.Items.Clear();
                for (int P = 1; P <= Owner.ActiveGame.DicPlayerByID.Values.Count; ++P)
                {
                    Owner.lstRoomPlayers.Items.Add("Player " + P + " In Game");
                }

                Owner.btnCreateSquare.Enabled = true;
                Owner.btnCreateCircle.Enabled = true;
            }
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

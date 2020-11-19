using ProjectEternity.Core.Online;
using System;

namespace ClientForm
{
    public class LoginSuccessScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Login Success";

        private readonly ClientForm Owner;
        private string PlayerID;
        private string PlayerName;

        public LoginSuccessScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new LoginSuccessScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.txtName.InvokeRequired)
            {
                Owner.txtName.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Owner.txtName.Text = PlayerName;
                Owner.RoomPlayer = new Player();
                Owner.RoomPlayer.ID = PlayerID;
                Owner.RoomPlayer.Name = PlayerName;
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            PlayerID = Sender.ReadString();
            PlayerName = Sender.ReadString();
        }
    }
}

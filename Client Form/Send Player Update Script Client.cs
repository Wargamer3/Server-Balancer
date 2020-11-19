using ProjectEternity.Core.Online;
using System;

namespace ClientForm
{
    public class SendPlayerUpdateScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Send Player Update";

        private readonly ClientForm Owner;

        private uint PlayerID;
        private string Input;

        public SendPlayerUpdateScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new SendPlayerUpdateScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.txtRoomInfo.InvokeRequired)
            {
                Owner.txtRoomInfo.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Owner.ActiveGame.DicPlayerByID[PlayerID].Input = Input;
                Owner.UpdateGameUI();
            }
        }

        protected override void Read(OnlineReader Host)
        {
            PlayerID = Host.ReadUInt32();
            Input = Host.ReadString();
        }
    }
}

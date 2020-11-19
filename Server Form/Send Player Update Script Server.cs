using System;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class SendPlayerUpdateScriptServer : OnlineScript
    {
        public const string ScriptName = "Send Player Update";

        private readonly uint PlayerID;
        private readonly string Input;

        public SendPlayerUpdateScriptServer(uint PlayerID, string Input)
            : base(ScriptName)
        {
            this.PlayerID = PlayerID;
            this.Input = Input;
        }

        public override OnlineScript Copy()
        {
            throw new NotImplementedException();
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendUInt32(PlayerID);
            WriteBuffer.AppendString(Input);
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            throw new NotImplementedException();
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

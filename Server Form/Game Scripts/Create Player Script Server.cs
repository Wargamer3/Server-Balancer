using System;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class CreatePlayerScriptServer : OnlineScript
    {
        public const string ScriptName = "Create Player";

        private readonly uint PlayerID;
        private readonly bool IsPlayerControlled;

        public CreatePlayerScriptServer(uint PlayerID, bool IsPlayerControlled)
            : base(ScriptName)
        {
            this.PlayerID = PlayerID;
            this.IsPlayerControlled = IsPlayerControlled;
        }

        public override OnlineScript Copy()
        {
            throw new NotImplementedException();
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendUInt32(PlayerID);
            WriteBuffer.AppendBoolean(IsPlayerControlled);
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

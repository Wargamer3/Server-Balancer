using System;

namespace ProjectEternity.Core.Online
{
    public class PlayerLeftScriptServer : OnlineScript
    {
        public const string ScriptName = "Player Left";

        private readonly string PlayerID;

        public PlayerLeftScriptServer(string PlayerID)
            : base(ScriptName)
        {
            this.PlayerID = PlayerID;
        }

        public override OnlineScript Copy()
        {
            throw new NotImplementedException();
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendString(PlayerID);
        }

        protected internal override void Execute(IOnlineConnection Sender)
        {
            throw new NotImplementedException();
        }

        protected internal override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace ProjectEternity.Core.Online
{
    public class StartGameScriptServer : OnlineScript
    {
        public const string ScriptName = "Start Game";

        public StartGameScriptServer()
            : base(ScriptName)
        {
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
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

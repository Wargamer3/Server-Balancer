using System;

namespace ProjectEternity.Core.Online
{
    public class PlayerJoinedScriptServer : OnlineScript
    {
        public const string ScriptName = "Player Joined";

        private readonly Player JoiningPlayer;

        public PlayerJoinedScriptServer(Player JoiningPlayer)
            : base(ScriptName)
        {
            this.JoiningPlayer = JoiningPlayer;
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendString(JoiningPlayer.ID);
            WriteBuffer.AppendString(JoiningPlayer.Name);
        }

        protected internal override void Execute(IOnlineConnection ActivePlayer)
        {
        }

        protected internal override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

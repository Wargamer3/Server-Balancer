using System;

namespace ProjectEternity.Core.Online
{
    public class AskStartGameScriptServer : OnlineScript
    {
        public const string ScriptName = "Ask Start Game";

        private readonly Server Owner;
        private string RoomID;

        public AskStartGameScriptServer(Server Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected internal override void Execute(IOnlineConnection Sender)
        {
            Owner.SharedWriteBuffer.ClearWriteBuffer();
            Owner.SharedWriteBuffer.WriteScript(new StartGameScriptServer());

            //Create game and tell client to start it too.
            foreach (IOnlineConnection ActivePlayer in Owner.DicLocalRoom[RoomID].Room.ListOnlinePlayer)
            {
                ActivePlayer.SendWriteBuffer();
            }
        }

        protected internal override void Read(OnlineReader Sender)
        {
            RoomID = Sender.ReadString();
        }
    }
}

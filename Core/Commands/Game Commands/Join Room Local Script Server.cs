using System;

namespace ProjectEternity.Core.Online
{
    public class JoinRoomLocalScriptServer : OnlineScript
    {
        private IOnlineGame CurrentGame;
        private string RoomID;

        public JoinRoomLocalScriptServer(string RoomID, IOnlineGame CurrentGame)
            : base("Join Room Local")
        {
            this.RoomID = RoomID;
            this.CurrentGame = CurrentGame;
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendString(RoomID);
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

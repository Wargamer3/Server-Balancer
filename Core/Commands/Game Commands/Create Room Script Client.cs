using System;

namespace ProjectEternity.Core.Online
{
    public class CreateRoomScriptClient : OnlineScript
    {
        private readonly string RoomName;

        public CreateRoomScriptClient(string RoomName)
            : base("Create Room")
        {
            this.RoomName = RoomName;
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendString(RoomName);
        }

        protected internal override void Execute(IOnlineConnection Host)
        {
            throw new NotImplementedException();
        }

        protected internal override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

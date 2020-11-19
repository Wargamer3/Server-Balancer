using System;

namespace ProjectEternity.Core.Online
{
    public class SendGameDataScriptClient : OnlineScript
    {
        private readonly Client Owner;

        public SendGameDataScriptClient(Client Owner)
            : base("Send Game Data")
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            byte[] ArrayGameData = Owner.CurrentGame.GetSnapshotData();

            WriteBuffer.AppendString(Owner.RoomID);
            WriteBuffer.AppendByteArray(ArrayGameData);
        }

        protected internal override void Execute(IOnlineConnection ActivePlayer)
        {
            throw new NotImplementedException();
        }

        protected internal override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummyJoinRoomLocalScriptClient : OnlineScript
    {
        private readonly Client Owner;
        private readonly string RoomID;
        private readonly bool HasGame;

        public DummyJoinRoomLocalScriptClient(Client Owner, string RoomID, bool HasGame)
            : base("Join Room Local")
        {
            this.Owner = Owner;
            this.RoomID = RoomID;
            this.HasGame = HasGame;
        }

        public override OnlineScript Copy()
        {
            return new DummyJoinRoomLocalScriptClient(Owner, RoomID, HasGame);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            Owner.RoomID = RoomID;

            if (HasGame)
            {
                Owner.CurrentGame = new DummyGame();
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

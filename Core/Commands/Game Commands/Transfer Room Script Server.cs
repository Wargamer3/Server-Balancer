using System;

namespace ProjectEternity.Core.Online
{
    public class TransferRoomScriptServer : OnlineScript
    {
        public const string ScriptName = "Transfer Room";

        private readonly Server Owner;
        string RoomID;

        public TransferRoomScriptServer(Server Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public TransferRoomScriptServer(Server Owner, string RoomID)
            : this(Owner)
        {
            this.RoomID = RoomID;
        }

        public override OnlineScript Copy()
        {
            return new TransferRoomScriptServer(Owner, RoomID);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected internal override void Execute(IOnlineConnection ActivePlayer)
        {
            ClientGroup ActiveTransferingRoom;

            if (Owner.DicTransferingRoom.TryGetValue(RoomID, out ActiveTransferingRoom) && ActiveTransferingRoom.Room.ListOnlinePlayer.Count < ActiveTransferingRoom.Room.CurrentPlayerCount)
            {
                ActiveTransferingRoom.Room.ListOnlinePlayer.Add(ActivePlayer);
            }
            else if (Owner.DicAllRoom.ContainsKey(RoomID))
            {
                ClientGroup NewRoom = Owner.TransferRoom(RoomID);
                Owner.DicTransferingRoom.Add(RoomID, NewRoom);
                NewRoom.Room.ListOnlinePlayer.Add(ActivePlayer);
                ActivePlayer.Send(new AskGameDataScriptServer());
            }
        }

        protected internal override void Read(OnlineReader Sender)
        {
            RoomID = Sender.ReadString();
        }
    }
}

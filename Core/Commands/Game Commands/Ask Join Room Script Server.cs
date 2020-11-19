using System;

namespace ProjectEternity.Core.Online
{
    public abstract class AskJoinRoomScriptServer : OnlineScript
    {
        public const string ScriptName = "Ask Join Room";

        protected readonly Server Owner;
        protected string RoomID;

        public AskJoinRoomScriptServer(Server Owner)
            : this(Owner, null)
        {
        }

        public AskJoinRoomScriptServer(Server Owner, string RoomID)
            : base(ScriptName)
        {
            this.Owner = Owner;
            this.RoomID = RoomID;
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
            IRoomInformations RoomToJoin;
            if (Owner.DicAllRoom.TryGetValue(RoomID, out RoomToJoin))
            {
                if (RoomToJoin.OwnerServerIP != Owner.IP)
                {
                    Sender.Send(new JoinRoomRemoteScriptServer(RoomID, RoomToJoin.OwnerServerIP, RoomToJoin.OwnerServerPort));
                }
                else if (Owner.DicLocalRoom.ContainsKey(RoomID) && Owner.DicLocalRoom[RoomID].Room.ListOnlinePlayer.Count < Owner.DicLocalRoom[RoomID].Room.MaxNumberOfPlayer)
                {
                    Owner.Database.UpdatePlayerCountInRoom(RoomID, Owner.DicLocalRoom[RoomID].Room.ListOnlinePlayer.Count + 1);
                    Owner.DicLocalRoom[RoomID].Room.AddPlayer(Sender);
                    Owner.ListPlayerToRemove.Add(Sender);

                    OnJoinRoomLocal(Sender, RoomID, Owner.DicLocalRoom[RoomID]);
                }
                else
                {
                    //Maybe in transfer, don't allow the client to join
                }
            }
        }

        protected abstract void OnJoinRoomLocal(IOnlineConnection Sender, string RoomID, ClientGroup ActiveGroup);

        protected internal override void Read(OnlineReader Sender)
        {
            RoomID = Sender.ReadString();
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    public class CreateRoomScriptServer : OnlineScript
    {
        public const string ScriptName = "Create Room";

        private readonly Server Owner;

        private string RoomName;
        public ClientGroup CreatedGroup;

        public CreateRoomScriptServer(Server Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new CreateRoomScriptServer(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected internal override void Execute(IOnlineConnection Sender)
        {
            IRoomInformations CreatedRoom = Owner.Database.GenerateNewRoom(RoomName, "", Owner.IP, Owner.Port);

            CreatedGroup = new ClientGroup(CreatedRoom);
            CreatedGroup.Room.AddPlayer(Sender);

            Owner.DicLocalRoom.Add(CreatedRoom.RoomID, CreatedGroup);
            Owner.DicAllRoom.Add(CreatedRoom.RoomID, CreatedRoom);
            Owner.ListPlayerToRemove.Add(Sender);

            Owner.SharedWriteBuffer.ClearWriteBuffer();
            Owner.SharedWriteBuffer.WriteScript(new RoomListScriptServer(Owner, new List<IRoomInformations>() { CreatedRoom }));

            foreach (IOnlineConnection ActivePlayer in Owner.ListPlayer)
            {
                if (ActivePlayer == Sender)
                {
                    continue;
                }

                ActivePlayer.SendWriteBuffer();
            }

            Sender.Send(new SendRoomIDScriptServer(CreatedRoom.RoomID));
        }

        protected internal override void Read(OnlineReader Sender)
        {
            RoomName = Sender.ReadString();
        }
    }
}

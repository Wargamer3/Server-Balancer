using System;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class RoomListScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Room List";

        private readonly ClientForm Owner;

        private List<RoomInformations> ListAllRoom;

        public RoomListScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;

            ListAllRoom = new List<RoomInformations>();
        }

        public override OnlineScript Copy()
        {
            return new RoomListScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.lstRooms.InvokeRequired)
            {
                Owner.lstRooms.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Owner.UpdateRooms(ListAllRoom);
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            int ListRoomUpdatesCount = Sender.ReadInt32();

            for (int i = 0; i < ListRoomUpdatesCount; ++i)
            {
                string RoomID = Sender.ReadString();
                bool IsDead = Sender.ReadBoolean();

                if (IsDead)
                {
                    ListAllRoom.Add(new RoomInformations(RoomID, IsDead));
                }
                else
                {
                    string Name = Sender.ReadString();
                    int MaxPlayer = Sender.ReadInt32();
                    int CurrentClientCount = Sender.ReadInt32();

                    ListAllRoom.Add(new RoomInformations(RoomID, Name, MaxPlayer, CurrentClientCount));
                }
            }
        }
    }
}

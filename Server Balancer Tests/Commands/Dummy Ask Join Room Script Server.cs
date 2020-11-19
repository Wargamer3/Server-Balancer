using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    public class DummyAskJoinRoomScriptServer : AskJoinRoomScriptServer
    {
        public DummyAskJoinRoomScriptServer(Server Owner, string RoomID)
            : base(Owner, RoomID)
        {
        }

        public override OnlineScript Copy()
        {
            return new DummyAskJoinRoomScriptServer(Owner, RoomID);
        }

        protected override void OnJoinRoomLocal(IOnlineConnection Sender, string RoomID, ClientGroup ActiveGroup)
        {
            foreach (IOnlineConnection ActivePlayer in ActiveGroup.Room.ListOnlinePlayer)
            {
                if (ActivePlayer == Sender)
                {
                    continue;
                }

                ActivePlayer.Send(new PlayerJoinedScriptServer(ActiveGroup.Room.GetPlayer(Sender)));
            }

            Sender.Send(new JoinRoomLocalScriptServer(RoomID, ActiveGroup.CurrentGame));
        }
    }
}

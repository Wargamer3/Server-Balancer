using ProjectEternity.Core.Online;
using System;
using System.Collections.Generic;

namespace ServerForm
{
    public class CreateRoomScriptServerForm : CreateRoomScriptServer
    {
        private delegate void SafeCallDelegate();

        private readonly ServerForm Owner;

        public CreateRoomScriptServerForm(ServerForm Owner)
            : base(Owner.OnlineServer)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new CreateRoomScriptServerForm(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            base.Execute(Sender);

            RoomInformations NewRoom = (RoomInformations)CreatedGroup.Room;

            foreach (IOnlineConnection ActivePlayer in CreatedGroup.Room.ListOnlinePlayer)
            {
                //Add Game Specific scripts
                Dictionary<string, OnlineScript> DicNewScript = new Dictionary<string, OnlineScript>();
                DicNewScript.Add(AskStartGameScriptServer.ScriptName, new AskStartGameScriptServer(CreatedGroup));
                DicNewScript.Add(LeaveRoomScriptServer.ScriptName, new LeaveRoomScriptServer(NewRoom, Owner.OnlineServer));
                ActivePlayer.AddOrReplaceScripts(DicNewScript);
            }

            AddRoom();
        }

        protected void AddRoom()
        {
            if (Owner.lstRooms.InvokeRequired)
            {
                Owner.lstRooms.Invoke(new SafeCallDelegate(AddRoom), new object[] {  });
            }
            else
            {
                Owner.lstRooms.Items.Add(CreatedGroup.Room);
            }
        }
    }
}

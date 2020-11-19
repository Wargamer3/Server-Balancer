using ProjectEternity.Core.Online;
using System;

namespace ClientForm
{
    public class SendRoomInformationScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Send Room Information";

        private readonly ClientForm Owner;
        private string RoomID;

        public SendRoomInformationScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new SendRoomInformationScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.txtRoomID.InvokeRequired)
            {
                Owner.txtRoomID.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Owner.txtRoomID.Text = RoomID;
                Owner.lstRoomPlayers.Items.Clear();
                Owner.lstRoomPlayers.Items.Add(Owner.RoomPlayer);
                Owner.lstRooms.Items.Add(new RoomInformations(RoomID, Owner.txtRoomName.Text, 3, 1));
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            RoomID = Sender.ReadString();
        }
    }
}

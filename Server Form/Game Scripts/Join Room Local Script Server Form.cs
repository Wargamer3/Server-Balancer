using System;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class JoinRoomLocalScriptServerForm : OnlineScript
    {
        public const string ScriptName = "Join Room Local";

        private readonly string RoomID;
        private readonly PlayerWithID JoinedPlayer;
        private readonly ClientGroup ActiveGroup;

        public JoinRoomLocalScriptServerForm(string RoomID, PlayerWithID JoinedPlayer, ClientGroup ActiveGroup)
            : base(ScriptName)
        {
            this.RoomID = RoomID;
            this.JoinedPlayer = JoinedPlayer;
            this.ActiveGroup = ActiveGroup;
        }

        public override OnlineScript Copy()
        {
            throw new NotImplementedException();
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendString(RoomID);

            WriteBuffer.AppendByteArray(ActiveGroup.Room.GetRoomInfo());

            WriteBuffer.AppendBoolean(ActiveGroup.CurrentGame != null);

            if (ActiveGroup.CurrentGame != null)
            {
                WriteBuffer.AppendUInt32(JoinedPlayer.ID);
                WriteBuffer.AppendByteArray(ActiveGroup.CurrentGame.GetSnapshotData());
            }
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            throw new NotImplementedException();
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class PlayerJoinedScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Player Joined";

        private readonly ClientForm Owner;

        private string PlayerID;
        private string PlayerName;

        public PlayerJoinedScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new PlayerJoinedScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.lstRoomPlayers.InvokeRequired)
            {
                Owner.lstRoomPlayers.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Player JoiningPlayer = new Player();
                JoiningPlayer.ID = PlayerID;
                JoiningPlayer.Name = PlayerName;
                Owner.lstRoomPlayers.Items.Add(JoiningPlayer);
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            PlayerID = Sender.ReadString();
            PlayerName = Sender.ReadString();
        }
    }
}

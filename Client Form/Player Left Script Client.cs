using System;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class PlayerLeftScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Player Left";

        private readonly ClientForm Owner;

        private string PlayerID;

        public PlayerLeftScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new PlayerLeftScriptClient(Owner);
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
                for (int P = 0; P < Owner.lstRoomPlayers.Items.Count; ++P)
                {
                    if (((Player)Owner.lstRoomPlayers.Items[P]).ID == PlayerID)
                    {
                        Owner.lstRoomPlayers.Items.RemoveAt(P);
                        break;
                    }
                }
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            PlayerID = Sender.ReadString();
        }
    }
}

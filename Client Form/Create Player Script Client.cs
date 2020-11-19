using System;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class CreatePlayerScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate();

        public const string ScriptName = "Create Player";

        private readonly ClientForm Owner;

        private uint PlayerID;
        private bool IsPlayerControlled;

        public CreatePlayerScriptClient(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new CreatePlayerScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            PlayerWithID NewPlayer = new PlayerWithID(PlayerID);
            Owner.ActiveGame.DicPlayerByID.Add(PlayerID, NewPlayer);

            if (IsPlayerControlled)
            {
                Owner.GamePlayer = NewPlayer;
            }

            Owner.UpdateGame();
            UpdateUI();
        }

        protected void UpdateUI()
        {
            if (Owner.txtRoomInfo.InvokeRequired)
            {
                Owner.txtRoomInfo.Invoke(new SafeCallDelegate(UpdateUI), new object[] {  });
            }
            else
            {
                Owner.UpdateGameUI();
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            PlayerID = Sender.ReadUInt32();
            IsPlayerControlled = Sender.ReadBoolean();
        }
    }
}

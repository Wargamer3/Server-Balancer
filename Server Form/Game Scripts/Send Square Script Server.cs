using ProjectEternity.Core.Online;
using System;

namespace ServerForm
{
    public class SendSquareScriptServer : OnlineScript
    {
        public const string ScriptName = "Send Square";

        private readonly ClientGroup ActiveGroup;
        private readonly PlayerWithID Owner;

        public SendSquareScriptServer(ClientGroup ActiveGroup, PlayerWithID Owner)
            : base(ScriptName)
        {
            this.ActiveGroup = ActiveGroup;
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new SendSquareScriptServer(ActiveGroup, Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            Owner.CreateSquare();

            foreach (IOnlineConnection ActivePlayer in ActiveGroup.Room.ListOnlinePlayer)
            {
                if (ActivePlayer == Sender)
                {
                    continue;
                }

                ActivePlayer.Send(new SendPlayerUpdateScriptServer(Owner.ID, "[]"));
            }
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

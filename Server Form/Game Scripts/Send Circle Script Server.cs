using ProjectEternity.Core.Online;
using System;

namespace ServerForm
{
    public class SendCircleScriptServer : OnlineScript
    {
        public const string ScriptName = "Send Circle";

        private readonly ClientGroup ActiveGroup;
        private readonly PlayerWithID Owner;

        public SendCircleScriptServer(ClientGroup ActiveGroup, PlayerWithID Owner)
            : base(ScriptName)
        {
            this.ActiveGroup = ActiveGroup;
            this.Owner = Owner;
        }

        public override OnlineScript Copy()
        {
            return new SendCircleScriptServer(ActiveGroup, Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            Owner.CreateCircle();

            foreach (IOnlineConnection ActivePlayer in ActiveGroup.Room.ListOnlinePlayer)
            {
                if (ActivePlayer == Sender)
                {
                    continue;
                }

                ActivePlayer.Send(new SendPlayerUpdateScriptServer(Owner.ID, "O"));
            }
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}

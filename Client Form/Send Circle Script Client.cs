using ProjectEternity.Core.Online;
using System;

namespace ClientForm
{
    public class SendCircleScriptClient : OnlineScript
    {
        public const string ScriptName = "Send Circle";
        
        public SendCircleScriptClient()
            : base(ScriptName)
        {
        }

        public override OnlineScript Copy()
        {
            throw new NotImplementedException();
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
        }

        protected override void Execute(IOnlineConnection Host)
        {
            throw new NotImplementedException();
        }

        protected override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}

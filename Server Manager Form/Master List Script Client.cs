using System;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ServerManagerForm
{
    public class MasterListScriptClient : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Master List";

        private readonly ServerManagerForm Owner;
        private List<string> ListOtherMasterIP;

        public MasterListScriptClient(ServerManagerForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;

            ListOtherMasterIP = new List<string>();
        }

        public override OnlineScript Copy()
        {
            return new MasterListScriptClient(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.lstMasters.InvokeRequired)
            {
                Owner.lstMasters.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Owner.lstMasters.Items.Add(Host);
                Owner.lstMasters.Items.AddRange(ListOtherMasterIP.ToArray());
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            int ListOtherMasterCount = Sender.ReadInt32();
            for (int M = 0; M < ListOtherMasterCount; ++M)
            {
                ListOtherMasterIP.Add(Sender.ReadString());
            }
        }
    }
}

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ServerManagerForm
{
    public partial class ServerManagerForm : Form
    {
        public readonly ServerManager OnlineServerManager;

        public ServerManagerForm()
        {
            InitializeComponent();

            Dictionary<string, OnlineScript> DicOnlineScripts = new Dictionary<string, OnlineScript>();
            DicOnlineScripts.Add(MasterListScriptClient.ScriptName, new MasterListScriptClient(this));
            OnlineServerManager = new ServerManager(DicOnlineScripts);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OnlineServerManager.StartListening((int)txtClientsPort.Value, (int)txtMastersPort.Value);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            OnlineServerManager.StopListening();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            ConnectToServerForm ConnectForm = new ConnectToServerForm(this);
            ConnectForm.ShowDialog();
        }

        private void btnActivateServer_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveServer_Click(object sender, EventArgs e)
        {

        }
    }
}

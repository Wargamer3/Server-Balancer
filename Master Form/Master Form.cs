using System;
using System.Windows.Forms;
using ProjectEternity.Core.Online;

namespace MasterForm
{
    public partial class MasterForm : Form
    {
        public readonly Master OnlineMaster;

        public MasterForm()
        {
            InitializeComponent();

            OnlineMaster = new Master();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OnlineMaster.StartListening((int)txtClientsPort.Value, (int)txtMastersPort.Value);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            OnlineMaster.StopListening();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnConnectMaster_Click(object sender, EventArgs e)
        {
            ConnectToMasterForm ConnectForm = new ConnectToMasterForm(this);
            ConnectForm.ShowDialog();
        }

        private void btnActivateMaster_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveMaster_Click(object sender, EventArgs e)
        {

        }

        private void btnConnectServerManager_Click(object sender, EventArgs e)
        {
            ConnectToServerManagerForm ConnectForm = new ConnectToServerManagerForm(this);
            ConnectForm.ShowDialog();
        }

        private void btnActivateServerManager_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveServerManager_Click(object sender, EventArgs e)
        {

        }
    }
}

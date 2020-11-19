using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using ProjectEternity.Core.Online;

namespace MasterForm
{
    public partial class ConnectToMasterForm : Form
    {
        private readonly MasterForm OwnerForm;

        public ConnectToMasterForm()
        {
            InitializeComponent();
        }

        public ConnectToMasterForm(MasterForm OwnerForm)
        {
            InitializeComponent();

            this.OwnerForm = OwnerForm;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPEndPoint HostEndPoint = new IPEndPoint(IPAddress.Parse(txtMasterIP.Text), (int)txtMasterPort.Value);
            TcpClient UserClient = new TcpClient();
            UserClient.NoDelay = true;
            try
            {
                UserClient.Connect(HostEndPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Get a client stream for reading and writing.
            NetworkStream HostStream = UserClient.GetStream();
            IOnlineConnection NewMasterConnection = OwnerForm.OnlineMaster.CreateNewConnection(UserClient, HostStream);
            OwnerForm.OnlineMaster.ConnectToExistingMaster(NewMasterConnection);
            OwnerForm.lstIdleMasters.Items.Add(NewMasterConnection);
        }
    }
}

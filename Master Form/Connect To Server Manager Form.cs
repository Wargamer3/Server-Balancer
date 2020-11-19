using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using ProjectEternity.Core.Online;

namespace MasterForm
{
    public partial class ConnectToServerManagerForm : Form
    {
        private readonly MasterForm OwnerForm;

        public ConnectToServerManagerForm()
        {
            InitializeComponent();
        }

        public ConnectToServerManagerForm(MasterForm OwnerForm)
        {
            InitializeComponent();

            this.OwnerForm = OwnerForm;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPEndPoint HostEndPoint = new IPEndPoint(IPAddress.Parse(txtServerManagerIP.Text), (int)txtServerManagerPort.Value);
            TcpClient UserClient = new TcpClient();
            UserClient.NoDelay = true;
            try
            {
                UserClient.Connect(HostEndPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get a client stream for reading and writing.
            NetworkStream HostStream = UserClient.GetStream();
            IOnlineConnection NewServerManagerConnection = OwnerForm.OnlineMaster.CreateNewConnection(UserClient, HostStream);
            OwnerForm.OnlineMaster.ConnectToExistingServerManager(NewServerManagerConnection);
            OwnerForm.lstIdleServerManagers.Items.Add(NewServerManagerConnection);
        }
    }
}

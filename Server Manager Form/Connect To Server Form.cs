using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using ProjectEternity.Core.Online;

namespace ServerManagerForm
{
    public partial class ConnectToServerForm : Form
    {
        private readonly ServerManagerForm OwnerForm;

        public ConnectToServerForm()
        {
            InitializeComponent();
        }

        public ConnectToServerForm(ServerManagerForm OwnerForm)
        {
            InitializeComponent();

            this.OwnerForm = OwnerForm;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPEndPoint HostEndPoint = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), (int)txtServerPort.Value);
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
            IOnlineConnection NewServerManagerConnection = OwnerForm.OnlineServerManager.CreateNewConnection(UserClient, HostStream);
            OwnerForm.OnlineServerManager.ConnectToExistingServer(NewServerManagerConnection);
            OwnerForm.lstIdleServers.Items.Add(NewServerManagerConnection);
        }
    }
}

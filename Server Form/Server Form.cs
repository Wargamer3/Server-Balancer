using System;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public partial class ServerForm : Form
    {
        public readonly Server OnlineServer;

        public ServerForm()
        {
            InitializeComponent();

            Dictionary<string, OnlineScript> DicOnlineScripts = new Dictionary<string, OnlineScript>();

            MongoDBManager Database = new MongoDBManager();
            Database.Init();
            //IDataManager Database = new DataManager();

            OnlineServer = new Server(Database, DicOnlineScripts);

            DicOnlineScripts.Add(AskLoginScriptServer.ScriptName, new AskLoginScriptServer(OnlineServer));
            DicOnlineScripts.Add(AskGameDataScriptServer.ScriptName, new AskGameDataScriptServer());
            DicOnlineScripts.Add(AskJoinRoomScriptServer.ScriptName, new AskJoinRoomScriptServerForm(OnlineServer));
            DicOnlineScripts.Add(AskRoomListScriptServer.ScriptName, new AskRoomListScriptServer(OnlineServer));
            DicOnlineScripts.Add(CreateRoomScriptServer.ScriptName, new CreateRoomScriptServerForm(this));
            DicOnlineScripts.Add(SendGameDataScriptServer.ScriptName, new SendGameDataScriptServer(OnlineServer));
            DicOnlineScripts.Add(TransferRoomScriptServer.ScriptName, new TransferRoomScriptServer(OnlineServer));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string PublicIP = new WebClient().DownloadString("http://icanhazip.com").Replace("\n", "").Replace("\r", "");
            OnlineServer.StartListening(PublicIP, (int)txtClientsPort.Value);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            OnlineServer.StopListening();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}

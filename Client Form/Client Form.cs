using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public partial class ClientForm : Form
    {
        private readonly Client OnlineClient;
        public readonly Dictionary<string, RoomInformations> DicAllRoom;
        public PlayerWithID GamePlayer;
        public Player RoomPlayer;
        public TextGame ActiveGame;

        public ClientForm()
        {
            InitializeComponent();

            DicAllRoom = new Dictionary<string, RoomInformations>();
            GamePlayer = null;

            Dictionary<string, OnlineScript> DicOnlineScripts = new Dictionary<string, OnlineScript>();

            DicOnlineScripts.Add(LoginSuccessScriptClient.ScriptName, new LoginSuccessScriptClient(this));
            DicOnlineScripts.Add(SendRoomInformationScriptClient.ScriptName, new SendRoomInformationScriptClient(this));
            DicOnlineScripts.Add(RoomListScriptClient.ScriptName, new RoomListScriptClient(this));
            DicOnlineScripts.Add(PlayerJoinedScriptClient.ScriptName, new PlayerJoinedScriptClient(this));
            DicOnlineScripts.Add(PlayerLeftScriptClient.ScriptName, new PlayerLeftScriptClient(this));
            DicOnlineScripts.Add(JoinRoomLocalScriptClientForm.ScriptName, new JoinRoomLocalScriptClientForm(this));
            DicOnlineScripts.Add(CreateGameScriptClient.ScriptName, new CreateGameScriptClient(this));
            DicOnlineScripts.Add(CreatePlayerScriptClient.ScriptName, new CreatePlayerScriptClient(this));
            DicOnlineScripts.Add(StartGameScriptClientForm.ScriptName, new StartGameScriptClientForm(this));
            DicOnlineScripts.Add(SendPlayerUpdateScriptClient.ScriptName, new SendPlayerUpdateScriptClient(this));

            OnlineClient = new Client(DicOnlineScripts);
        }

        public void UpdateGameUI()
        {
            txtRoomInfo.Text = "";

            foreach (PlayerWithID ActivePlayer in ActiveGame.DicPlayerByID.Values)
            {
                txtRoomInfo.Text += ActivePlayer.ID + ": " + ActivePlayer.Input + System.Environment.NewLine;
            }
        }

        public void UpdateGame()
        {
            if (!ActiveGame.HasGameStarted)
            {
                ActiveGame.Update(0);
                if (ActiveGame.HasGameStarted)
                {
                    OnlineClient.Host.Send(new FinishedLoadingScriptClient());
                }
            }
        }

        public void UpdateRooms(List<RoomInformations> ListRoomUpdates)
        {
            foreach (RoomInformations ActiveRoomUpdate in ListRoomUpdates)
            {
                if (ActiveRoomUpdate.IsDead)
                {
                    DicAllRoom.Remove(ActiveRoomUpdate.RoomID);
                }
                else if (DicAllRoom.ContainsKey(ActiveRoomUpdate.RoomID))
                {
                    DicAllRoom[ActiveRoomUpdate.RoomID] = ActiveRoomUpdate;
                }
                else
                {
                    DicAllRoom.Add(ActiveRoomUpdate.RoomID, ActiveRoomUpdate);
                }
            }

            lstRooms.Items.Clear();
            foreach (RoomInformations ActiveRoom in DicAllRoom.Values)
            {
                if (!ActiveRoom.IsDead)
                {
                    lstRooms.Items.Add(ActiveRoom);
                }
            }
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            string Username = "Test";
            string Password = "";
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                Username = txtUsername.Text;
                Password = txtPassword.Text;
            }

            OnlineClient.Connect(IPAddress.Parse(txtServerIP.Text), (int)txtServerPort.Value);
            OnlineClient.Host.Send(new AskLoginScriptClient(Username, Password));
            gbRooms.Enabled = true;
            gbBehavior.Enabled = false;
        }

        private void btnCreateRoom_Click(object sender, System.EventArgs e)
        {
            gbRooms.Enabled = false;
            gbRoomInfo.Enabled = true;
            btnStartGame.Enabled = true;

            OnlineClient.CreateRoom(txtRoomName.Text);
        }

        private void btnJoinRoom_Click(object sender, System.EventArgs e)
        {
            gbRooms.Enabled = false;
            gbRoomInfo.Enabled = true;
            btnStartGame.Enabled = false;

            if (lstRooms.SelectedIndex >= 0)
            {
                RoomInformations ActiveRoom = (RoomInformations)lstRooms.SelectedItem;
                OnlineClient.JoinRoom(ActiveRoom.RoomID);
            }
        }

        private void btnStartGame_Click(object sender, System.EventArgs e)
        {
            btnStartGame.Enabled = false;
            GamePlayer = null;
            OnlineClient.StartGame();
        }

        private void btnExitRoom_Click(object sender, System.EventArgs e)
        {
            gbRooms.Enabled = true;
            gbRoomInfo.Enabled = false;
            GamePlayer = null;

            txtRoomInfo.Text = "";
            lstRoomPlayers.Items.Clear();

            OnlineClient.Host.Send(new LeaveRoomScriptClient());
            OnlineClient.Host.Send(new AskRoomListScriptClient());
        }

        private void btnCreateSquare_Click(object sender, System.EventArgs e)
        {
            GamePlayer.CreateSquare();
            UpdateGameUI();
            OnlineClient.Host.Send(new SendSquareScriptClient());
        }

        private void btnCreateCircle_Click(object sender, System.EventArgs e)
        {
            GamePlayer.CreateCircle();
            UpdateGameUI();
            OnlineClient.Host.Send(new SendCircleScriptClient());
        }
    }
}

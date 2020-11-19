namespace ClientForm
{
    partial class ClientForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMasters = new System.Windows.Forms.GroupBox();
            this.lstMasters = new System.Windows.Forms.TextBox();
            this.gbBehavior = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.NumericUpDown();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gbRooms = new System.Windows.Forms.GroupBox();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.gbChat = new System.Windows.Forms.GroupBox();
            this.txtChatHistory = new System.Windows.Forms.TextBox();
            this.txtChatBox = new System.Windows.Forms.TextBox();
            this.gbPlayers = new System.Windows.Forms.GroupBox();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.gbRoomInfo = new System.Windows.Forms.GroupBox();
            this.btnExitRoom = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnCreateCircle = new System.Windows.Forms.Button();
            this.btnCreateSquare = new System.Windows.Forms.Button();
            this.lstRoomPlayers = new System.Windows.Forms.ListBox();
            this.txtRoomInfo = new System.Windows.Forms.TextBox();
            this.gbLogs = new System.Windows.Forms.GroupBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.gbMasters.SuspendLayout();
            this.gbBehavior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerPort)).BeginInit();
            this.gbRooms.SuspendLayout();
            this.gbChat.SuspendLayout();
            this.gbPlayers.SuspendLayout();
            this.gbRoomInfo.SuspendLayout();
            this.gbLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMasters
            // 
            this.gbMasters.Controls.Add(this.lstMasters);
            this.gbMasters.Location = new System.Drawing.Point(12, 12);
            this.gbMasters.Name = "gbMasters";
            this.gbMasters.Size = new System.Drawing.Size(145, 115);
            this.gbMasters.TabIndex = 0;
            this.gbMasters.TabStop = false;
            this.gbMasters.Text = "Masters";
            // 
            // lstMasters
            // 
            this.lstMasters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMasters.Location = new System.Drawing.Point(6, 19);
            this.lstMasters.Multiline = true;
            this.lstMasters.Name = "lstMasters";
            this.lstMasters.Size = new System.Drawing.Size(133, 90);
            this.lstMasters.TabIndex = 1;
            // 
            // gbBehavior
            // 
            this.gbBehavior.Controls.Add(this.txtName);
            this.gbBehavior.Controls.Add(this.txtPassword);
            this.gbBehavior.Controls.Add(this.lblPassword);
            this.gbBehavior.Controls.Add(this.txtUsername);
            this.gbBehavior.Controls.Add(this.lblUsername);
            this.gbBehavior.Controls.Add(this.txtServerIP);
            this.gbBehavior.Controls.Add(this.txtServerPort);
            this.gbBehavior.Controls.Add(this.lblServerIP);
            this.gbBehavior.Controls.Add(this.lblServerPort);
            this.gbBehavior.Controls.Add(this.btnConnect);
            this.gbBehavior.Location = new System.Drawing.Point(163, 12);
            this.gbBehavior.Name = "gbBehavior";
            this.gbBehavior.Size = new System.Drawing.Size(409, 77);
            this.gbBehavior.TabIndex = 1;
            this.gbBehavior.TabStop = false;
            this.gbBehavior.Text = "Behavior";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(328, 18);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(79, 20);
            this.txtName.TabIndex = 13;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(243, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(79, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(179, 51);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(243, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(79, 20);
            this.txtUsername.TabIndex = 9;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(179, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "Username:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(66, 18);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(107, 20);
            this.txtServerIP.TabIndex = 4;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(98, 49);
            this.txtServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtServerPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(75, 20);
            this.txtServerPort.TabIndex = 7;
            this.txtServerPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(6, 21);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(54, 13);
            this.lblServerIP.TabIndex = 8;
            this.lblServerIP.Text = "Server IP:";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(6, 51);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(63, 13);
            this.lblServerPort.TabIndex = 5;
            this.lblServerPort.Text = "Server Port:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(328, 46);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // gbRooms
            // 
            this.gbRooms.Controls.Add(this.txtRoomID);
            this.gbRooms.Controls.Add(this.txtRoomName);
            this.gbRooms.Controls.Add(this.lstRooms);
            this.gbRooms.Controls.Add(this.btnJoinRoom);
            this.gbRooms.Controls.Add(this.btnCreateRoom);
            this.gbRooms.Enabled = false;
            this.gbRooms.Location = new System.Drawing.Point(163, 95);
            this.gbRooms.Name = "gbRooms";
            this.gbRooms.Size = new System.Drawing.Size(205, 200);
            this.gbRooms.TabIndex = 2;
            this.gbRooms.TabStop = false;
            this.gbRooms.Text = "Rooms";
            // 
            // txtRoomID
            // 
            this.txtRoomID.Location = new System.Drawing.Point(102, 174);
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.ReadOnly = true;
            this.txtRoomID.Size = new System.Drawing.Size(93, 20);
            this.txtRoomID.TabIndex = 6;
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(3, 174);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(93, 20);
            this.txtRoomName.TabIndex = 5;
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.Location = new System.Drawing.Point(3, 16);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(195, 121);
            this.lstRooms.TabIndex = 4;
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.Location = new System.Drawing.Point(102, 145);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(93, 23);
            this.btnJoinRoom.TabIndex = 3;
            this.btnJoinRoom.Text = "Join Room";
            this.btnJoinRoom.UseVisualStyleBackColor = true;
            this.btnJoinRoom.Click += new System.EventHandler(this.btnJoinRoom_Click);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(3, 145);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(93, 23);
            this.btnCreateRoom.TabIndex = 2;
            this.btnCreateRoom.Text = "Create Room";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // gbChat
            // 
            this.gbChat.Controls.Add(this.txtChatHistory);
            this.gbChat.Controls.Add(this.txtChatBox);
            this.gbChat.Location = new System.Drawing.Point(12, 301);
            this.gbChat.Name = "gbChat";
            this.gbChat.Size = new System.Drawing.Size(776, 115);
            this.gbChat.TabIndex = 3;
            this.gbChat.TabStop = false;
            this.gbChat.Text = "Chat";
            // 
            // txtChatHistory
            // 
            this.txtChatHistory.Location = new System.Drawing.Point(6, 19);
            this.txtChatHistory.Multiline = true;
            this.txtChatHistory.Name = "txtChatHistory";
            this.txtChatHistory.ReadOnly = true;
            this.txtChatHistory.Size = new System.Drawing.Size(764, 64);
            this.txtChatHistory.TabIndex = 1;
            // 
            // txtChatBox
            // 
            this.txtChatBox.Location = new System.Drawing.Point(6, 89);
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.Size = new System.Drawing.Size(764, 20);
            this.txtChatBox.TabIndex = 0;
            // 
            // gbPlayers
            // 
            this.gbPlayers.Controls.Add(this.lstPlayers);
            this.gbPlayers.Location = new System.Drawing.Point(12, 133);
            this.gbPlayers.Name = "gbPlayers";
            this.gbPlayers.Size = new System.Drawing.Size(145, 162);
            this.gbPlayers.TabIndex = 4;
            this.gbPlayers.TabStop = false;
            this.gbPlayers.Text = "Players";
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(6, 19);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(133, 134);
            this.lstPlayers.TabIndex = 5;
            // 
            // gbRoomInfo
            // 
            this.gbRoomInfo.Controls.Add(this.btnExitRoom);
            this.gbRoomInfo.Controls.Add(this.btnStartGame);
            this.gbRoomInfo.Controls.Add(this.btnCreateCircle);
            this.gbRoomInfo.Controls.Add(this.btnCreateSquare);
            this.gbRoomInfo.Controls.Add(this.lstRoomPlayers);
            this.gbRoomInfo.Controls.Add(this.txtRoomInfo);
            this.gbRoomInfo.Enabled = false;
            this.gbRoomInfo.Location = new System.Drawing.Point(374, 95);
            this.gbRoomInfo.Name = "gbRoomInfo";
            this.gbRoomInfo.Size = new System.Drawing.Size(198, 200);
            this.gbRoomInfo.TabIndex = 5;
            this.gbRoomInfo.TabStop = false;
            this.gbRoomInfo.Text = "Room Info";
            // 
            // btnExitRoom
            // 
            this.btnExitRoom.Location = new System.Drawing.Point(99, 143);
            this.btnExitRoom.Name = "btnExitRoom";
            this.btnExitRoom.Size = new System.Drawing.Size(93, 23);
            this.btnExitRoom.TabIndex = 10;
            this.btnExitRoom.Text = "Exit Room";
            this.btnExitRoom.UseVisualStyleBackColor = true;
            this.btnExitRoom.Click += new System.EventHandler(this.btnExitRoom_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(6, 143);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(93, 23);
            this.btnStartGame.TabIndex = 9;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnCreateCircle
            // 
            this.btnCreateCircle.Enabled = false;
            this.btnCreateCircle.Location = new System.Drawing.Point(99, 168);
            this.btnCreateCircle.Name = "btnCreateCircle";
            this.btnCreateCircle.Size = new System.Drawing.Size(93, 23);
            this.btnCreateCircle.TabIndex = 8;
            this.btnCreateCircle.Text = "Create Circle";
            this.btnCreateCircle.UseVisualStyleBackColor = true;
            this.btnCreateCircle.Click += new System.EventHandler(this.btnCreateCircle_Click);
            // 
            // btnCreateSquare
            // 
            this.btnCreateSquare.Enabled = false;
            this.btnCreateSquare.Location = new System.Drawing.Point(6, 168);
            this.btnCreateSquare.Name = "btnCreateSquare";
            this.btnCreateSquare.Size = new System.Drawing.Size(93, 23);
            this.btnCreateSquare.TabIndex = 7;
            this.btnCreateSquare.Text = "Create Square";
            this.btnCreateSquare.UseVisualStyleBackColor = true;
            this.btnCreateSquare.Click += new System.EventHandler(this.btnCreateSquare_Click);
            // 
            // lstRoomPlayers
            // 
            this.lstRoomPlayers.FormattingEnabled = true;
            this.lstRoomPlayers.Location = new System.Drawing.Point(6, 94);
            this.lstRoomPlayers.Name = "lstRoomPlayers";
            this.lstRoomPlayers.Size = new System.Drawing.Size(186, 43);
            this.lstRoomPlayers.TabIndex = 6;
            // 
            // txtRoomInfo
            // 
            this.txtRoomInfo.Enabled = false;
            this.txtRoomInfo.Location = new System.Drawing.Point(6, 19);
            this.txtRoomInfo.Multiline = true;
            this.txtRoomInfo.Name = "txtRoomInfo";
            this.txtRoomInfo.ReadOnly = true;
            this.txtRoomInfo.Size = new System.Drawing.Size(186, 69);
            this.txtRoomInfo.TabIndex = 0;
            // 
            // gbLogs
            // 
            this.gbLogs.Controls.Add(this.txtLogs);
            this.gbLogs.Location = new System.Drawing.Point(578, 12);
            this.gbLogs.Name = "gbLogs";
            this.gbLogs.Size = new System.Drawing.Size(210, 283);
            this.gbLogs.TabIndex = 6;
            this.gbLogs.TabStop = false;
            this.gbLogs.Text = "Logs";
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(6, 19);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.Size = new System.Drawing.Size(198, 258);
            this.txtLogs.TabIndex = 0;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.gbLogs);
            this.Controls.Add(this.gbRoomInfo);
            this.Controls.Add(this.gbPlayers);
            this.Controls.Add(this.gbChat);
            this.Controls.Add(this.gbRooms);
            this.Controls.Add(this.gbBehavior);
            this.Controls.Add(this.gbMasters);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.gbMasters.ResumeLayout(false);
            this.gbMasters.PerformLayout();
            this.gbBehavior.ResumeLayout(false);
            this.gbBehavior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerPort)).EndInit();
            this.gbRooms.ResumeLayout(false);
            this.gbRooms.PerformLayout();
            this.gbChat.ResumeLayout(false);
            this.gbChat.PerformLayout();
            this.gbPlayers.ResumeLayout(false);
            this.gbRoomInfo.ResumeLayout(false);
            this.gbRoomInfo.PerformLayout();
            this.gbLogs.ResumeLayout(false);
            this.gbLogs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMasters;
        private System.Windows.Forms.TextBox lstMasters;
        private System.Windows.Forms.GroupBox gbBehavior;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox gbRooms;
        private System.Windows.Forms.GroupBox gbChat;
        private System.Windows.Forms.TextBox txtChatHistory;
        private System.Windows.Forms.TextBox txtChatBox;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.NumericUpDown txtServerPort;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button btnJoinRoom;
        private System.Windows.Forms.Button btnCreateRoom;
        public System.Windows.Forms.TextBox txtRoomName;
        public System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.GroupBox gbPlayers;
        public System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.GroupBox gbRoomInfo;
        public System.Windows.Forms.TextBox txtRoomInfo;
        public System.Windows.Forms.ListBox lstRooms;
        public System.Windows.Forms.ListBox lstRoomPlayers;
        private System.Windows.Forms.GroupBox gbLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnStartGame;
        public System.Windows.Forms.Button btnCreateCircle;
        public System.Windows.Forms.Button btnCreateSquare;
        private System.Windows.Forms.Button btnExitRoom;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        public System.Windows.Forms.TextBox txtName;
    }
}


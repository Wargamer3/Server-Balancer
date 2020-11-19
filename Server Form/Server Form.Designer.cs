namespace ServerForm
{
    partial class ServerForm
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
            this.gbBehavior = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtClientsPort = new System.Windows.Forms.NumericUpDown();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbClients = new System.Windows.Forms.GroupBox();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.gbRoomInfo = new System.Windows.Forms.GroupBox();
            this.txtRoomInfo = new System.Windows.Forms.TextBox();
            this.gbBehavior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientsPort)).BeginInit();
            this.gbClients.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRoomInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBehavior
            // 
            this.gbBehavior.Controls.Add(this.btnStop);
            this.gbBehavior.Controls.Add(this.txtClientsPort);
            this.gbBehavior.Controls.Add(this.lblClientPort);
            this.gbBehavior.Controls.Add(this.btnStart);
            this.gbBehavior.Location = new System.Drawing.Point(12, 12);
            this.gbBehavior.Name = "gbBehavior";
            this.gbBehavior.Size = new System.Drawing.Size(324, 52);
            this.gbBehavior.TabIndex = 4;
            this.gbBehavior.TabStop = false;
            this.gbBehavior.Text = "Behavior";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(243, 16);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtClientsPort
            // 
            this.txtClientsPort.Location = new System.Drawing.Point(80, 20);
            this.txtClientsPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtClientsPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.txtClientsPort.Name = "txtClientsPort";
            this.txtClientsPort.Size = new System.Drawing.Size(75, 20);
            this.txtClientsPort.TabIndex = 3;
            this.txtClientsPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // lblClientPort
            // 
            this.lblClientPort.AutoSize = true;
            this.lblClientPort.Location = new System.Drawing.Point(6, 22);
            this.lblClientPort.Name = "lblClientPort";
            this.lblClientPort.Size = new System.Drawing.Size(63, 13);
            this.lblClientPort.TabIndex = 3;
            this.lblClientPort.Text = "Clients Port:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(162, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbClients
            // 
            this.gbClients.Controls.Add(this.lstClients);
            this.gbClients.Location = new System.Drawing.Point(12, 70);
            this.gbClients.Name = "gbClients";
            this.gbClients.Size = new System.Drawing.Size(136, 127);
            this.gbClients.TabIndex = 5;
            this.gbClients.TabStop = false;
            this.gbClients.Text = "Clients";
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.Location = new System.Drawing.Point(6, 19);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(124, 95);
            this.lstClients.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstRooms);
            this.groupBox1.Location = new System.Drawing.Point(154, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 127);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rooms";
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.Location = new System.Drawing.Point(3, 16);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(412, 95);
            this.lstRooms.TabIndex = 4;
            // 
            // gbRoomInfo
            // 
            this.gbRoomInfo.Controls.Add(this.txtRoomInfo);
            this.gbRoomInfo.Location = new System.Drawing.Point(581, 70);
            this.gbRoomInfo.Name = "gbRoomInfo";
            this.gbRoomInfo.Size = new System.Drawing.Size(198, 158);
            this.gbRoomInfo.TabIndex = 7;
            this.gbRoomInfo.TabStop = false;
            this.gbRoomInfo.Text = "Room Info";
            // 
            // txtRoomInfo
            // 
            this.txtRoomInfo.Enabled = false;
            this.txtRoomInfo.Location = new System.Drawing.Point(6, 19);
            this.txtRoomInfo.Multiline = true;
            this.txtRoomInfo.Name = "txtRoomInfo";
            this.txtRoomInfo.Size = new System.Drawing.Size(186, 133);
            this.txtRoomInfo.TabIndex = 0;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbRoomInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbClients);
            this.Controls.Add(this.gbBehavior);
            this.Name = "ServerForm";
            this.Text = "Server Form";
            this.gbBehavior.ResumeLayout(false);
            this.gbBehavior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientsPort)).EndInit();
            this.gbClients.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbRoomInfo.ResumeLayout(false);
            this.gbRoomInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBehavior;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown txtClientsPort;
        private System.Windows.Forms.Label lblClientPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbClients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbRoomInfo;
        public System.Windows.Forms.ListBox lstRooms;
        public System.Windows.Forms.TextBox txtRoomInfo;
        public System.Windows.Forms.ListBox lstClients;
    }
}


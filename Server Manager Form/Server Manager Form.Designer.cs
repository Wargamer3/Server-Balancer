namespace ServerManagerForm
{
    partial class ServerManagerForm
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
            this.gbServers = new System.Windows.Forms.GroupBox();
            this.btnRemoveServer = new System.Windows.Forms.Button();
            this.btnActivateServer = new System.Windows.Forms.Button();
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.lblDeadServers = new System.Windows.Forms.Label();
            this.lstDeadServers = new System.Windows.Forms.ListBox();
            this.lblIdleServers = new System.Windows.Forms.Label();
            this.lstIdleServers = new System.Windows.Forms.ListBox();
            this.lblActiveServers = new System.Windows.Forms.Label();
            this.lstActiveServers = new System.Windows.Forms.ListBox();
            this.gbBehavior = new System.Windows.Forms.GroupBox();
            this.txtMastersPort = new System.Windows.Forms.NumericUpDown();
            this.lblMastersPort = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtClientsPort = new System.Windows.Forms.NumericUpDown();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbMasters = new System.Windows.Forms.GroupBox();
            this.lstMasters = new System.Windows.Forms.ListBox();
            this.gbServers.SuspendLayout();
            this.gbBehavior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMastersPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientsPort)).BeginInit();
            this.gbMasters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbServers
            // 
            this.gbServers.Controls.Add(this.btnRemoveServer);
            this.gbServers.Controls.Add(this.btnActivateServer);
            this.gbServers.Controls.Add(this.btnConnectServer);
            this.gbServers.Controls.Add(this.lblDeadServers);
            this.gbServers.Controls.Add(this.lstDeadServers);
            this.gbServers.Controls.Add(this.lblIdleServers);
            this.gbServers.Controls.Add(this.lstIdleServers);
            this.gbServers.Controls.Add(this.lblActiveServers);
            this.gbServers.Controls.Add(this.lstActiveServers);
            this.gbServers.Location = new System.Drawing.Point(12, 70);
            this.gbServers.Name = "gbServers";
            this.gbServers.Size = new System.Drawing.Size(384, 226);
            this.gbServers.TabIndex = 4;
            this.gbServers.TabStop = false;
            this.gbServers.Text = "Servers";
            // 
            // btnRemoveServer
            // 
            this.btnRemoveServer.Location = new System.Drawing.Point(258, 196);
            this.btnRemoveServer.Name = "btnRemoveServer";
            this.btnRemoveServer.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveServer.TabIndex = 11;
            this.btnRemoveServer.Text = "Remove";
            this.btnRemoveServer.UseVisualStyleBackColor = true;
            this.btnRemoveServer.Click += new System.EventHandler(this.btnRemoveServer_Click);
            // 
            // btnActivateServer
            // 
            this.btnActivateServer.Location = new System.Drawing.Point(132, 196);
            this.btnActivateServer.Name = "btnActivateServer";
            this.btnActivateServer.Size = new System.Drawing.Size(120, 23);
            this.btnActivateServer.TabIndex = 10;
            this.btnActivateServer.Text = "Activate";
            this.btnActivateServer.UseVisualStyleBackColor = true;
            this.btnActivateServer.Click += new System.EventHandler(this.btnActivateServer_Click);
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(6, 196);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(120, 23);
            this.btnConnectServer.TabIndex = 9;
            this.btnConnectServer.Text = "Connect";
            this.btnConnectServer.UseVisualStyleBackColor = true;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // lblDeadServers
            // 
            this.lblDeadServers.AutoSize = true;
            this.lblDeadServers.Location = new System.Drawing.Point(258, 27);
            this.lblDeadServers.Name = "lblDeadServers";
            this.lblDeadServers.Size = new System.Drawing.Size(33, 13);
            this.lblDeadServers.TabIndex = 8;
            this.lblDeadServers.Text = "Dead";
            // 
            // lstDeadServers
            // 
            this.lstDeadServers.FormattingEnabled = true;
            this.lstDeadServers.Location = new System.Drawing.Point(258, 43);
            this.lstDeadServers.Name = "lstDeadServers";
            this.lstDeadServers.Size = new System.Drawing.Size(120, 147);
            this.lstDeadServers.TabIndex = 7;
            // 
            // lblIdleServers
            // 
            this.lblIdleServers.AutoSize = true;
            this.lblIdleServers.Location = new System.Drawing.Point(132, 27);
            this.lblIdleServers.Name = "lblIdleServers";
            this.lblIdleServers.Size = new System.Drawing.Size(24, 13);
            this.lblIdleServers.TabIndex = 6;
            this.lblIdleServers.Text = "Idle";
            // 
            // lstIdleServers
            // 
            this.lstIdleServers.FormattingEnabled = true;
            this.lstIdleServers.Location = new System.Drawing.Point(132, 43);
            this.lstIdleServers.Name = "lstIdleServers";
            this.lstIdleServers.Size = new System.Drawing.Size(120, 147);
            this.lstIdleServers.TabIndex = 5;
            // 
            // lblActiveServers
            // 
            this.lblActiveServers.AutoSize = true;
            this.lblActiveServers.Location = new System.Drawing.Point(6, 27);
            this.lblActiveServers.Name = "lblActiveServers";
            this.lblActiveServers.Size = new System.Drawing.Size(37, 13);
            this.lblActiveServers.TabIndex = 4;
            this.lblActiveServers.Text = "Active";
            // 
            // lstActiveServers
            // 
            this.lstActiveServers.FormattingEnabled = true;
            this.lstActiveServers.Location = new System.Drawing.Point(6, 43);
            this.lstActiveServers.Name = "lstActiveServers";
            this.lstActiveServers.Size = new System.Drawing.Size(120, 147);
            this.lstActiveServers.TabIndex = 3;
            // 
            // gbBehavior
            // 
            this.gbBehavior.Controls.Add(this.txtMastersPort);
            this.gbBehavior.Controls.Add(this.lblMastersPort);
            this.gbBehavior.Controls.Add(this.btnStop);
            this.gbBehavior.Controls.Add(this.txtClientsPort);
            this.gbBehavior.Controls.Add(this.lblClientPort);
            this.gbBehavior.Controls.Add(this.btnStart);
            this.gbBehavior.Location = new System.Drawing.Point(12, 12);
            this.gbBehavior.Name = "gbBehavior";
            this.gbBehavior.Size = new System.Drawing.Size(481, 52);
            this.gbBehavior.TabIndex = 3;
            this.gbBehavior.TabStop = false;
            this.gbBehavior.Text = "Behavior";
            // 
            // txtMastersPort
            // 
            this.txtMastersPort.Location = new System.Drawing.Point(235, 20);
            this.txtMastersPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtMastersPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.txtMastersPort.Name = "txtMastersPort";
            this.txtMastersPort.Size = new System.Drawing.Size(75, 20);
            this.txtMastersPort.TabIndex = 5;
            this.txtMastersPort.Value = new decimal(new int[] {
            8081,
            0,
            0,
            0});
            // 
            // lblMastersPort
            // 
            this.lblMastersPort.AutoSize = true;
            this.lblMastersPort.Location = new System.Drawing.Point(161, 22);
            this.lblMastersPort.Name = "lblMastersPort";
            this.lblMastersPort.Size = new System.Drawing.Size(69, 13);
            this.lblMastersPort.TabIndex = 6;
            this.lblMastersPort.Text = "Masters Port:";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(400, 16);
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
            this.btnStart.Location = new System.Drawing.Point(319, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbMasters
            // 
            this.gbMasters.Controls.Add(this.lstMasters);
            this.gbMasters.Location = new System.Drawing.Point(402, 70);
            this.gbMasters.Name = "gbMasters";
            this.gbMasters.Size = new System.Drawing.Size(94, 226);
            this.gbMasters.TabIndex = 5;
            this.gbMasters.TabStop = false;
            this.gbMasters.Text = "Masters";
            // 
            // lstMasters
            // 
            this.lstMasters.FormattingEnabled = true;
            this.lstMasters.Location = new System.Drawing.Point(6, 19);
            this.lstMasters.Name = "lstMasters";
            this.lstMasters.Size = new System.Drawing.Size(82, 199);
            this.lstMasters.TabIndex = 12;
            // 
            // ServerManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 308);
            this.Controls.Add(this.gbMasters);
            this.Controls.Add(this.gbServers);
            this.Controls.Add(this.gbBehavior);
            this.Name = "ServerManagerForm";
            this.Text = "Server Manager";
            this.gbServers.ResumeLayout(false);
            this.gbServers.PerformLayout();
            this.gbBehavior.ResumeLayout(false);
            this.gbBehavior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMastersPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientsPort)).EndInit();
            this.gbMasters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbServers;
        private System.Windows.Forms.Button btnRemoveServer;
        private System.Windows.Forms.Button btnActivateServer;
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.Label lblDeadServers;
        private System.Windows.Forms.ListBox lstDeadServers;
        private System.Windows.Forms.Label lblIdleServers;
        private System.Windows.Forms.Label lblActiveServers;
        private System.Windows.Forms.ListBox lstActiveServers;
        private System.Windows.Forms.GroupBox gbBehavior;
        private System.Windows.Forms.NumericUpDown txtMastersPort;
        private System.Windows.Forms.Label lblMastersPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown txtClientsPort;
        private System.Windows.Forms.Label lblClientPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbMasters;
        public System.Windows.Forms.ListBox lstMasters;
        public System.Windows.Forms.ListBox lstIdleServers;
    }
}


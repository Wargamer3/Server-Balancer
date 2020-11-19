namespace MasterForm
{
    partial class MasterForm
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
            this.txtMastersPort = new System.Windows.Forms.NumericUpDown();
            this.lblMastersPort = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtClientsPort = new System.Windows.Forms.NumericUpDown();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbMasters = new System.Windows.Forms.GroupBox();
            this.btnRemoveMaster = new System.Windows.Forms.Button();
            this.btnActivateMaster = new System.Windows.Forms.Button();
            this.btnConnectMaster = new System.Windows.Forms.Button();
            this.lblDeadMasters = new System.Windows.Forms.Label();
            this.lstDeadMasters = new System.Windows.Forms.ListBox();
            this.lblIdleMasters = new System.Windows.Forms.Label();
            this.lstIdleMasters = new System.Windows.Forms.ListBox();
            this.lblActiveMasters = new System.Windows.Forms.Label();
            this.lstActiveMasters = new System.Windows.Forms.ListBox();
            this.gbServerManagers = new System.Windows.Forms.GroupBox();
            this.btnRemoveServerManager = new System.Windows.Forms.Button();
            this.btnActivateServerManager = new System.Windows.Forms.Button();
            this.btnConnectServerManager = new System.Windows.Forms.Button();
            this.lblDeadServerManagers = new System.Windows.Forms.Label();
            this.lstDeadServerManagers = new System.Windows.Forms.ListBox();
            this.lblIdleServerManagers = new System.Windows.Forms.Label();
            this.lstIdleServerManagers = new System.Windows.Forms.ListBox();
            this.lblActiveServerManagers = new System.Windows.Forms.Label();
            this.lstActiveServerManagers = new System.Windows.Forms.ListBox();
            this.gbBehavior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMastersPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientsPort)).BeginInit();
            this.gbMasters.SuspendLayout();
            this.gbServerManagers.SuspendLayout();
            this.SuspendLayout();
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
            this.gbBehavior.TabIndex = 0;
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
            this.lblMastersPort.Location = new System.Drawing.Point(161, 21);
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
            this.lblClientPort.Location = new System.Drawing.Point(6, 21);
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
            this.gbMasters.Controls.Add(this.btnRemoveMaster);
            this.gbMasters.Controls.Add(this.btnActivateMaster);
            this.gbMasters.Controls.Add(this.btnConnectMaster);
            this.gbMasters.Controls.Add(this.lblDeadMasters);
            this.gbMasters.Controls.Add(this.lstDeadMasters);
            this.gbMasters.Controls.Add(this.lblIdleMasters);
            this.gbMasters.Controls.Add(this.lstIdleMasters);
            this.gbMasters.Controls.Add(this.lblActiveMasters);
            this.gbMasters.Controls.Add(this.lstActiveMasters);
            this.gbMasters.Location = new System.Drawing.Point(12, 70);
            this.gbMasters.Name = "gbMasters";
            this.gbMasters.Size = new System.Drawing.Size(384, 226);
            this.gbMasters.TabIndex = 2;
            this.gbMasters.TabStop = false;
            this.gbMasters.Text = "Masters";
            // 
            // btnRemoveMaster
            // 
            this.btnRemoveMaster.Location = new System.Drawing.Point(258, 196);
            this.btnRemoveMaster.Name = "btnRemoveMaster";
            this.btnRemoveMaster.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveMaster.TabIndex = 11;
            this.btnRemoveMaster.Text = "Remove";
            this.btnRemoveMaster.UseVisualStyleBackColor = true;
            this.btnRemoveMaster.Click += new System.EventHandler(this.btnRemoveMaster_Click);
            // 
            // btnActivateMaster
            // 
            this.btnActivateMaster.Location = new System.Drawing.Point(132, 196);
            this.btnActivateMaster.Name = "btnActivateMaster";
            this.btnActivateMaster.Size = new System.Drawing.Size(120, 23);
            this.btnActivateMaster.TabIndex = 10;
            this.btnActivateMaster.Text = "Activate";
            this.btnActivateMaster.UseVisualStyleBackColor = true;
            this.btnActivateMaster.Click += new System.EventHandler(this.btnActivateMaster_Click);
            // 
            // btnConnectMaster
            // 
            this.btnConnectMaster.Location = new System.Drawing.Point(6, 196);
            this.btnConnectMaster.Name = "btnConnectMaster";
            this.btnConnectMaster.Size = new System.Drawing.Size(120, 23);
            this.btnConnectMaster.TabIndex = 9;
            this.btnConnectMaster.Text = "Connect";
            this.btnConnectMaster.UseVisualStyleBackColor = true;
            this.btnConnectMaster.Click += new System.EventHandler(this.btnConnectMaster_Click);
            // 
            // lblDeadMasters
            // 
            this.lblDeadMasters.AutoSize = true;
            this.lblDeadMasters.Location = new System.Drawing.Point(258, 27);
            this.lblDeadMasters.Name = "lblDeadMasters";
            this.lblDeadMasters.Size = new System.Drawing.Size(33, 13);
            this.lblDeadMasters.TabIndex = 8;
            this.lblDeadMasters.Text = "Dead";
            // 
            // lstDeadMasters
            // 
            this.lstDeadMasters.FormattingEnabled = true;
            this.lstDeadMasters.Location = new System.Drawing.Point(258, 43);
            this.lstDeadMasters.Name = "lstDeadMasters";
            this.lstDeadMasters.Size = new System.Drawing.Size(120, 147);
            this.lstDeadMasters.TabIndex = 7;
            // 
            // lblIdleMasters
            // 
            this.lblIdleMasters.AutoSize = true;
            this.lblIdleMasters.Location = new System.Drawing.Point(132, 27);
            this.lblIdleMasters.Name = "lblIdleMasters";
            this.lblIdleMasters.Size = new System.Drawing.Size(24, 13);
            this.lblIdleMasters.TabIndex = 6;
            this.lblIdleMasters.Text = "Idle";
            // 
            // lstIdleMasters
            // 
            this.lstIdleMasters.FormattingEnabled = true;
            this.lstIdleMasters.Location = new System.Drawing.Point(132, 43);
            this.lstIdleMasters.Name = "lstIdleMasters";
            this.lstIdleMasters.Size = new System.Drawing.Size(120, 147);
            this.lstIdleMasters.TabIndex = 5;
            // 
            // lblActiveMasters
            // 
            this.lblActiveMasters.AutoSize = true;
            this.lblActiveMasters.Location = new System.Drawing.Point(6, 27);
            this.lblActiveMasters.Name = "lblActiveMasters";
            this.lblActiveMasters.Size = new System.Drawing.Size(37, 13);
            this.lblActiveMasters.TabIndex = 4;
            this.lblActiveMasters.Text = "Active";
            // 
            // lstActiveMasters
            // 
            this.lstActiveMasters.FormattingEnabled = true;
            this.lstActiveMasters.Location = new System.Drawing.Point(6, 43);
            this.lstActiveMasters.Name = "lstActiveMasters";
            this.lstActiveMasters.Size = new System.Drawing.Size(120, 147);
            this.lstActiveMasters.TabIndex = 3;
            // 
            // gbServerManagers
            // 
            this.gbServerManagers.Controls.Add(this.btnRemoveServerManager);
            this.gbServerManagers.Controls.Add(this.btnActivateServerManager);
            this.gbServerManagers.Controls.Add(this.btnConnectServerManager);
            this.gbServerManagers.Controls.Add(this.lblDeadServerManagers);
            this.gbServerManagers.Controls.Add(this.lstDeadServerManagers);
            this.gbServerManagers.Controls.Add(this.lblIdleServerManagers);
            this.gbServerManagers.Controls.Add(this.lstIdleServerManagers);
            this.gbServerManagers.Controls.Add(this.lblActiveServerManagers);
            this.gbServerManagers.Controls.Add(this.lstActiveServerManagers);
            this.gbServerManagers.Location = new System.Drawing.Point(402, 70);
            this.gbServerManagers.Name = "gbServerManagers";
            this.gbServerManagers.Size = new System.Drawing.Size(384, 226);
            this.gbServerManagers.TabIndex = 12;
            this.gbServerManagers.TabStop = false;
            this.gbServerManagers.Text = "Server Managers";
            // 
            // btnRemoveServerManager
            // 
            this.btnRemoveServerManager.Location = new System.Drawing.Point(258, 196);
            this.btnRemoveServerManager.Name = "btnRemoveServerManager";
            this.btnRemoveServerManager.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveServerManager.TabIndex = 11;
            this.btnRemoveServerManager.Text = "Remove";
            this.btnRemoveServerManager.UseVisualStyleBackColor = true;
            this.btnRemoveServerManager.Click += new System.EventHandler(this.btnRemoveServerManager_Click);
            // 
            // btnActivateServerManager
            // 
            this.btnActivateServerManager.Location = new System.Drawing.Point(132, 196);
            this.btnActivateServerManager.Name = "btnActivateServerManager";
            this.btnActivateServerManager.Size = new System.Drawing.Size(120, 23);
            this.btnActivateServerManager.TabIndex = 10;
            this.btnActivateServerManager.Text = "Activate";
            this.btnActivateServerManager.UseVisualStyleBackColor = true;
            this.btnActivateServerManager.Click += new System.EventHandler(this.btnActivateServerManager_Click);
            // 
            // btnConnectServerManager
            // 
            this.btnConnectServerManager.Location = new System.Drawing.Point(6, 196);
            this.btnConnectServerManager.Name = "btnConnectServerManager";
            this.btnConnectServerManager.Size = new System.Drawing.Size(120, 23);
            this.btnConnectServerManager.TabIndex = 9;
            this.btnConnectServerManager.Text = "Connect";
            this.btnConnectServerManager.UseVisualStyleBackColor = true;
            this.btnConnectServerManager.Click += new System.EventHandler(this.btnConnectServerManager_Click);
            // 
            // lblDeadServerManagers
            // 
            this.lblDeadServerManagers.AutoSize = true;
            this.lblDeadServerManagers.Location = new System.Drawing.Point(258, 27);
            this.lblDeadServerManagers.Name = "lblDeadServerManagers";
            this.lblDeadServerManagers.Size = new System.Drawing.Size(33, 13);
            this.lblDeadServerManagers.TabIndex = 8;
            this.lblDeadServerManagers.Text = "Dead";
            // 
            // lstDeadServerManagers
            // 
            this.lstDeadServerManagers.FormattingEnabled = true;
            this.lstDeadServerManagers.Location = new System.Drawing.Point(258, 43);
            this.lstDeadServerManagers.Name = "lstDeadServerManagers";
            this.lstDeadServerManagers.Size = new System.Drawing.Size(120, 147);
            this.lstDeadServerManagers.TabIndex = 7;
            // 
            // lblIdleServerManagers
            // 
            this.lblIdleServerManagers.AutoSize = true;
            this.lblIdleServerManagers.Location = new System.Drawing.Point(132, 27);
            this.lblIdleServerManagers.Name = "lblIdleServerManagers";
            this.lblIdleServerManagers.Size = new System.Drawing.Size(24, 13);
            this.lblIdleServerManagers.TabIndex = 6;
            this.lblIdleServerManagers.Text = "Idle";
            // 
            // lstIdleServerManagers
            // 
            this.lstIdleServerManagers.FormattingEnabled = true;
            this.lstIdleServerManagers.Location = new System.Drawing.Point(132, 43);
            this.lstIdleServerManagers.Name = "lstIdleServerManagers";
            this.lstIdleServerManagers.Size = new System.Drawing.Size(120, 147);
            this.lstIdleServerManagers.TabIndex = 5;
            // 
            // lblActiveServerManagers
            // 
            this.lblActiveServerManagers.AutoSize = true;
            this.lblActiveServerManagers.Location = new System.Drawing.Point(6, 27);
            this.lblActiveServerManagers.Name = "lblActiveServerManagers";
            this.lblActiveServerManagers.Size = new System.Drawing.Size(37, 13);
            this.lblActiveServerManagers.TabIndex = 4;
            this.lblActiveServerManagers.Text = "Active";
            // 
            // lstActiveServerManagers
            // 
            this.lstActiveServerManagers.FormattingEnabled = true;
            this.lstActiveServerManagers.Location = new System.Drawing.Point(6, 43);
            this.lstActiveServerManagers.Name = "lstActiveServerManagers";
            this.lstActiveServerManagers.Size = new System.Drawing.Size(120, 147);
            this.lstActiveServerManagers.TabIndex = 3;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 307);
            this.Controls.Add(this.gbServerManagers);
            this.Controls.Add(this.gbMasters);
            this.Controls.Add(this.gbBehavior);
            this.Name = "MasterForm";
            this.Text = "Master";
            this.gbBehavior.ResumeLayout(false);
            this.gbBehavior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMastersPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientsPort)).EndInit();
            this.gbMasters.ResumeLayout(false);
            this.gbMasters.PerformLayout();
            this.gbServerManagers.ResumeLayout(false);
            this.gbServerManagers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBehavior;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbMasters;
        private System.Windows.Forms.Label lblDeadMasters;
        private System.Windows.Forms.ListBox lstDeadMasters;
        private System.Windows.Forms.Label lblIdleMasters;
        private System.Windows.Forms.Label lblActiveMasters;
        private System.Windows.Forms.ListBox lstActiveMasters;
        private System.Windows.Forms.Button btnActivateMaster;
        private System.Windows.Forms.Button btnConnectMaster;
        private System.Windows.Forms.Button btnRemoveMaster;
        private System.Windows.Forms.NumericUpDown txtClientsPort;
        private System.Windows.Forms.Label lblClientPort;
        private System.Windows.Forms.GroupBox gbServerManagers;
        private System.Windows.Forms.Button btnRemoveServerManager;
        private System.Windows.Forms.Button btnActivateServerManager;
        private System.Windows.Forms.Button btnConnectServerManager;
        private System.Windows.Forms.Label lblDeadServerManagers;
        private System.Windows.Forms.ListBox lstDeadServerManagers;
        private System.Windows.Forms.Label lblIdleServerManagers;
        private System.Windows.Forms.Label lblActiveServerManagers;
        private System.Windows.Forms.ListBox lstActiveServerManagers;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown txtMastersPort;
        private System.Windows.Forms.Label lblMastersPort;
        public System.Windows.Forms.ListBox lstIdleMasters;
        public System.Windows.Forms.ListBox lstIdleServerManagers;
    }
}


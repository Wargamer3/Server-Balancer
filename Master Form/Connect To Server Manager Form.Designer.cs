namespace MasterForm
{
    partial class ConnectToServerManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbServerManagerInformations = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerManagerPort = new System.Windows.Forms.NumericUpDown();
            this.lblServerManagerPort = new System.Windows.Forms.Label();
            this.txtServerManagerIP = new System.Windows.Forms.TextBox();
            this.lblServerManagerIP = new System.Windows.Forms.Label();
            this.gbServerManagerInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerManagerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gbServerManagerInformations
            // 
            this.gbServerManagerInformations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbServerManagerInformations.Controls.Add(this.btnCancel);
            this.gbServerManagerInformations.Controls.Add(this.btnConnect);
            this.gbServerManagerInformations.Controls.Add(this.txtServerManagerPort);
            this.gbServerManagerInformations.Controls.Add(this.lblServerManagerPort);
            this.gbServerManagerInformations.Controls.Add(this.txtServerManagerIP);
            this.gbServerManagerInformations.Controls.Add(this.lblServerManagerIP);
            this.gbServerManagerInformations.Location = new System.Drawing.Point(6, 6);
            this.gbServerManagerInformations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbServerManagerInformations.Name = "gbServerManagerInformations";
            this.gbServerManagerInformations.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbServerManagerInformations.Size = new System.Drawing.Size(241, 92);
            this.gbServerManagerInformations.TabIndex = 0;
            this.gbServerManagerInformations.TabStop = false;
            this.gbServerManagerInformations.Text = "Server Manager Informations";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(161, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(6, 62);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServerManagersPort
            // 
            this.txtServerManagerPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerManagerPort.Location = new System.Drawing.Point(160, 37);
            this.txtServerManagerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtServerManagerPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.txtServerManagerPort.Name = "txtServerManagersPort";
            this.txtServerManagerPort.Size = new System.Drawing.Size(75, 20);
            this.txtServerManagerPort.TabIndex = 6;
            this.txtServerManagerPort.Value = new decimal(new int[] {
            8081,
            0,
            0,
            0});
            // 
            // lblServerManagerPort
            // 
            this.lblServerManagerPort.AutoSize = true;
            this.lblServerManagerPort.Location = new System.Drawing.Point(132, 21);
            this.lblServerManagerPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerManagerPort.Name = "lblServerManagerPort";
            this.lblServerManagerPort.Size = new System.Drawing.Size(105, 13);
            this.lblServerManagerPort.TabIndex = 1;
            this.lblServerManagerPort.Text = "Server Manager Port";
            // 
            // txtServerManagerIP
            // 
            this.txtServerManagerIP.Location = new System.Drawing.Point(3, 37);
            this.txtServerManagerIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtServerManagerIP.Name = "txtServerManagerIP";
            this.txtServerManagerIP.Size = new System.Drawing.Size(118, 20);
            this.txtServerManagerIP.TabIndex = 1;
            // 
            // lblServerManagerIP
            // 
            this.lblServerManagerIP.AutoSize = true;
            this.lblServerManagerIP.Location = new System.Drawing.Point(3, 22);
            this.lblServerManagerIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerManagerIP.Name = "lblServerManagerIP";
            this.lblServerManagerIP.Size = new System.Drawing.Size(96, 13);
            this.lblServerManagerIP.TabIndex = 1;
            this.lblServerManagerIP.Text = "Server Manager IP";
            // 
            // ConnectToServerManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 105);
            this.Controls.Add(this.gbServerManagerInformations);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ConnectToServerManagerForm";
            this.Text = "Connect To ServerManager";
            this.gbServerManagerInformations.ResumeLayout(false);
            this.gbServerManagerInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerManagerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbServerManagerInformations;
        private System.Windows.Forms.TextBox txtServerManagerIP;
        private System.Windows.Forms.Label lblServerManagerIP;
        private System.Windows.Forms.Label lblServerManagerPort;
        private System.Windows.Forms.NumericUpDown txtServerManagerPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConnect;
    }
}
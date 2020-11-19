namespace ServerManagerForm
{
    partial class ConnectToServerForm
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
            this.gbServerInformations = new System.Windows.Forms.GroupBox();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.NumericUpDown();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbServerInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gbServerInformations
            // 
            this.gbServerInformations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbServerInformations.Controls.Add(this.btnCancel);
            this.gbServerInformations.Controls.Add(this.btnConnect);
            this.gbServerInformations.Controls.Add(this.txtServerPort);
            this.gbServerInformations.Controls.Add(this.lblServerPort);
            this.gbServerInformations.Controls.Add(this.txtServerIP);
            this.gbServerInformations.Controls.Add(this.lblServerIP);
            this.gbServerInformations.Location = new System.Drawing.Point(12, 12);
            this.gbServerInformations.Name = "gbServerInformations";
            this.gbServerInformations.Size = new System.Drawing.Size(460, 177);
            this.gbServerInformations.TabIndex = 0;
            this.gbServerInformations.TabStop = false;
            this.gbServerInformations.Text = "Server Informations";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(6, 43);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(103, 25);
            this.lblServerIP.TabIndex = 1;
            this.lblServerIP.Text = "Server IP";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(6, 71);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(232, 31);
            this.txtServerIP.TabIndex = 1;
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(267, 43);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(123, 25);
            this.lblServerPort.TabIndex = 1;
            this.lblServerPort.Text = "Server Port";
            // 
            // txtServersPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(272, 74);
            this.txtServerPort.Margin = new System.Windows.Forms.Padding(6);
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
            this.txtServerPort.Name = "txtServersPort";
            this.txtServerPort.Size = new System.Drawing.Size(150, 31);
            this.txtServerPort.TabIndex = 6;
            this.txtServerPort.Value = new decimal(new int[] {
            8081,
            0,
            0,
            0});
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(9, 111);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(150, 44);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(301, 117);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 44);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Connect_To_Server_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 201);
            this.Controls.Add(this.gbServerInformations);
            this.Name = "Connect_To_Server_Form";
            this.Text = "Connect To Server";
            this.gbServerInformations.ResumeLayout(false);
            this.gbServerInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbServerInformations;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.NumericUpDown txtServerPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConnect;
    }
}
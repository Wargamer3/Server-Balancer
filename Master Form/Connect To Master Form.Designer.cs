namespace MasterForm
{
    partial class ConnectToMasterForm
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
            this.gbMasterInformations = new System.Windows.Forms.GroupBox();
            this.lblMasterIP = new System.Windows.Forms.Label();
            this.txtMasterIP = new System.Windows.Forms.TextBox();
            this.lblMasterPort = new System.Windows.Forms.Label();
            this.txtMasterPort = new System.Windows.Forms.NumericUpDown();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbMasterInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasterPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMasterInformations
            // 
            this.gbMasterInformations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMasterInformations.Controls.Add(this.btnCancel);
            this.gbMasterInformations.Controls.Add(this.btnConnect);
            this.gbMasterInformations.Controls.Add(this.txtMasterPort);
            this.gbMasterInformations.Controls.Add(this.lblMasterPort);
            this.gbMasterInformations.Controls.Add(this.txtMasterIP);
            this.gbMasterInformations.Controls.Add(this.lblMasterIP);
            this.gbMasterInformations.Location = new System.Drawing.Point(12, 12);
            this.gbMasterInformations.Name = "gbMasterInformations";
            this.gbMasterInformations.Size = new System.Drawing.Size(460, 177);
            this.gbMasterInformations.TabIndex = 0;
            this.gbMasterInformations.TabStop = false;
            this.gbMasterInformations.Text = "Master Informations";
            // 
            // lblMasterIP
            // 
            this.lblMasterIP.AutoSize = true;
            this.lblMasterIP.Location = new System.Drawing.Point(6, 43);
            this.lblMasterIP.Name = "lblMasterIP";
            this.lblMasterIP.Size = new System.Drawing.Size(103, 25);
            this.lblMasterIP.TabIndex = 1;
            this.lblMasterIP.Text = "Master IP";
            // 
            // txtMasterIP
            // 
            this.txtMasterIP.Location = new System.Drawing.Point(6, 71);
            this.txtMasterIP.Name = "txtMasterIP";
            this.txtMasterIP.Size = new System.Drawing.Size(232, 31);
            this.txtMasterIP.TabIndex = 1;
            // 
            // lblMasterPort
            // 
            this.lblMasterPort.AutoSize = true;
            this.lblMasterPort.Location = new System.Drawing.Point(267, 43);
            this.lblMasterPort.Name = "lblMasterPort";
            this.lblMasterPort.Size = new System.Drawing.Size(123, 25);
            this.lblMasterPort.TabIndex = 1;
            this.lblMasterPort.Text = "Master Port";
            // 
            // txtMastersPort
            // 
            this.txtMasterPort.Location = new System.Drawing.Point(272, 74);
            this.txtMasterPort.Margin = new System.Windows.Forms.Padding(6);
            this.txtMasterPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtMasterPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.txtMasterPort.Name = "txtMastersPort";
            this.txtMasterPort.Size = new System.Drawing.Size(150, 31);
            this.txtMasterPort.TabIndex = 6;
            this.txtMasterPort.Value = new decimal(new int[] {
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
            // Connect_To_Master_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 201);
            this.Controls.Add(this.gbMasterInformations);
            this.Name = "Connect_To_Master_Form";
            this.Text = "Connect To Master";
            this.gbMasterInformations.ResumeLayout(false);
            this.gbMasterInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasterPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMasterInformations;
        private System.Windows.Forms.TextBox txtMasterIP;
        private System.Windows.Forms.Label lblMasterIP;
        private System.Windows.Forms.Label lblMasterPort;
        private System.Windows.Forms.NumericUpDown txtMasterPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConnect;
    }
}
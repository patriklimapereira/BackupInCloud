namespace patrikInstallGUI {
    partial class patrikInstallGUIForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(patrikInstallGUIForm));
            this.btnInstall = new System.Windows.Forms.Button();
            this.gBDadosDoBanco = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.tbDataBase = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.rtbDisplayOperation = new System.Windows.Forms.RichTextBox();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnCopyClipboard = new System.Windows.Forms.Button();
            this.gBDadosDoBanco.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInstall.Location = new System.Drawing.Point(6, 80);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(91, 31);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "&install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // gBDadosDoBanco
            // 
            this.gBDadosDoBanco.BackColor = System.Drawing.Color.Transparent;
            this.gBDadosDoBanco.Controls.Add(this.btnTest);
            this.gBDadosDoBanco.Controls.Add(this.lblDataBase);
            this.gBDadosDoBanco.Controls.Add(this.tbDataBase);
            this.gBDadosDoBanco.Controls.Add(this.lblPassword);
            this.gBDadosDoBanco.Controls.Add(this.tbPassword);
            this.gBDadosDoBanco.Controls.Add(this.lblUser);
            this.gBDadosDoBanco.Controls.Add(this.tbUserName);
            this.gBDadosDoBanco.Controls.Add(this.lblPort);
            this.gBDadosDoBanco.Controls.Add(this.tbPort);
            this.gBDadosDoBanco.Controls.Add(this.lblServerName);
            this.gBDadosDoBanco.Controls.Add(this.tbServer);
            this.gBDadosDoBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gBDadosDoBanco.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBDadosDoBanco.ForeColor = System.Drawing.Color.Black;
            this.gBDadosDoBanco.Location = new System.Drawing.Point(12, 10);
            this.gBDadosDoBanco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBDadosDoBanco.Name = "gBDadosDoBanco";
            this.gBDadosDoBanco.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBDadosDoBanco.Size = new System.Drawing.Size(1159, 45);
            this.gBDadosDoBanco.TabIndex = 4;
            this.gBDadosDoBanco.TabStop = false;
            this.gBDadosDoBanco.Text = "Parameter of conection of the RDMS";
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(1077, 14);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(71, 23);
            this.btnTest.TabIndex = 11;
            this.btnTest.Text = "&test";
            this.btnTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBase.ForeColor = System.Drawing.Color.Black;
            this.lblDataBase.Location = new System.Drawing.Point(690, 20);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(97, 15);
            this.lblDataBase.TabIndex = 9;
            this.lblDataBase.Text = "database:";
            // 
            // tbDataBase
            // 
            this.tbDataBase.BackColor = System.Drawing.Color.Black;
            this.tbDataBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDataBase.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataBase.ForeColor = System.Drawing.Color.Lime;
            this.tbDataBase.Location = new System.Drawing.Point(790, 20);
            this.tbDataBase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDataBase.Name = "tbDataBase";
            this.tbDataBase.Size = new System.Drawing.Size(280, 13);
            this.tbDataBase.TabIndex = 8;
            this.tbDataBase.Text = "patrikFullManagerBackupDllDataBase";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(501, 20);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(97, 15);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "password:";
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.Black;
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.Lime;
            this.tbPassword.Location = new System.Drawing.Point(605, 20);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(76, 13);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.Text = "root";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(338, 19);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(57, 15);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "user:";
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.Color.Black;
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserName.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.ForeColor = System.Drawing.Color.Lime;
            this.tbUserName.Location = new System.Drawing.Point(397, 20);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(90, 13);
            this.tbUserName.TabIndex = 4;
            this.tbUserName.Text = "postgres";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.Black;
            this.lblPort.Location = new System.Drawing.Point(215, 19);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(57, 15);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "port:";
            // 
            // tbPort
            // 
            this.tbPort.BackColor = System.Drawing.Color.Black;
            this.tbPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPort.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.ForeColor = System.Drawing.Color.Lime;
            this.tbPort.Location = new System.Drawing.Point(279, 20);
            this.tbPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(45, 13);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "5432";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.ForeColor = System.Drawing.Color.Black;
            this.lblServerName.Location = new System.Drawing.Point(7, 19);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(77, 15);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "server:";
            // 
            // tbServer
            // 
            this.tbServer.BackColor = System.Drawing.Color.Black;
            this.tbServer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbServer.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServer.ForeColor = System.Drawing.Color.Lime;
            this.tbServer.Location = new System.Drawing.Point(81, 20);
            this.tbServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(128, 13);
            this.tbServer.TabIndex = 0;
            this.tbServer.Text = "localhost";
            // 
            // rtbDisplayOperation
            // 
            this.rtbDisplayOperation.BackColor = System.Drawing.Color.Black;
            this.rtbDisplayOperation.ForeColor = System.Drawing.Color.Lime;
            this.rtbDisplayOperation.Location = new System.Drawing.Point(217, 80);
            this.rtbDisplayOperation.Name = "rtbDisplayOperation";
            this.rtbDisplayOperation.ReadOnly = true;
            this.rtbDisplayOperation.Size = new System.Drawing.Size(954, 293);
            this.rtbDisplayOperation.TabIndex = 7;
            this.rtbDisplayOperation.Text = "";
            // 
            // btnUninstall
            // 
            this.btnUninstall.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnUninstall.Location = new System.Drawing.Point(105, 80);
            this.btnUninstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(108, 31);
            this.btnUninstall.TabIndex = 10;
            this.btnUninstall.Text = "&uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnCopyClipboard
            // 
            this.btnCopyClipboard.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCopyClipboard.Location = new System.Drawing.Point(1002, 378);
            this.btnCopyClipboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            this.btnCopyClipboard.Size = new System.Drawing.Size(169, 31);
            this.btnCopyClipboard.TabIndex = 11;
            this.btnCopyClipboard.Text = "&copy Clipboard";
            this.btnCopyClipboard.UseVisualStyleBackColor = true;
            this.btnCopyClipboard.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // patrikInstallGUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1185, 417);
            this.Controls.Add(this.btnCopyClipboard);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.rtbDisplayOperation);
            this.Controls.Add(this.gBDadosDoBanco);
            this.Controls.Add(this.btnInstall);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "patrikInstallGUIForm";
            this.Opacity = 0.92D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "patrikFullManagerBackupService";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.patrikInstallGUIForm_FormClosed);
            this.Load += new System.EventHandler(this.patrikInstallGUIForm_Load);
            this.gBDadosDoBanco.ResumeLayout(false);
            this.gBDadosDoBanco.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.GroupBox gBDadosDoBanco;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.TextBox tbDataBase;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.RichTextBox rtbDisplayOperation;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCopyClipboard;
    }
}


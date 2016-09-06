namespace patrikSystemBackupGUI
{
    partial class patrikSystemBackupGUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.fbdLocalDoArquivo = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlCordenadasBackup = new System.Windows.Forms.Panel();
            this.lblExtensaoDoBaclup = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQuantidadeDeUltimasVersoes = new System.Windows.Forms.Label();
            this.cbQuantidadeDeUltimasVersoes = new System.Windows.Forms.ComboBox();
            this.ckManterUltimasVersões = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnProcurarDestino = new System.Windows.Forms.Button();
            this.tbOrigem = new System.Windows.Forms.TextBox();
            this.btnProcurarOrigem = new System.Windows.Forms.Button();
            this.tbDestino = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlCordenadasBackup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(334, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCordenadasBackup
            // 
            this.pnlCordenadasBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCordenadasBackup.Controls.Add(this.lblExtensaoDoBaclup);
            this.pnlCordenadasBackup.Controls.Add(this.panel1);
            this.pnlCordenadasBackup.Controls.Add(this.comboBox1);
            this.pnlCordenadasBackup.Controls.Add(this.btnProcurarDestino);
            this.pnlCordenadasBackup.Controls.Add(this.tbOrigem);
            this.pnlCordenadasBackup.Controls.Add(this.btnProcurarOrigem);
            this.pnlCordenadasBackup.Controls.Add(this.tbDestino);
            this.pnlCordenadasBackup.Location = new System.Drawing.Point(12, 131);
            this.pnlCordenadasBackup.Name = "pnlCordenadasBackup";
            this.pnlCordenadasBackup.Size = new System.Drawing.Size(600, 138);
            this.pnlCordenadasBackup.TabIndex = 5;
            // 
            // lblExtensaoDoBaclup
            // 
            this.lblExtensaoDoBaclup.AutoSize = true;
            this.lblExtensaoDoBaclup.Location = new System.Drawing.Point(154, 107);
            this.lblExtensaoDoBaclup.Name = "lblExtensaoDoBaclup";
            this.lblExtensaoDoBaclup.Size = new System.Drawing.Size(106, 13);
            this.lblExtensaoDoBaclup.TabIndex = 3;
            this.lblExtensaoDoBaclup.Text = "Extensão do Backup";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblQuantidadeDeUltimasVersoes);
            this.panel1.Controls.Add(this.cbQuantidadeDeUltimasVersoes);
            this.panel1.Controls.Add(this.ckManterUltimasVersões);
            this.panel1.Location = new System.Drawing.Point(362, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 107);
            this.panel1.TabIndex = 11;
            // 
            // lblQuantidadeDeUltimasVersoes
            // 
            this.lblQuantidadeDeUltimasVersoes.AutoSize = true;
            this.lblQuantidadeDeUltimasVersoes.Location = new System.Drawing.Point(143, 59);
            this.lblQuantidadeDeUltimasVersoes.Name = "lblQuantidadeDeUltimasVersoes";
            this.lblQuantidadeDeUltimasVersoes.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidadeDeUltimasVersoes.TabIndex = 2;
            this.lblQuantidadeDeUltimasVersoes.Text = "Quantidade";
            // 
            // cbQuantidadeDeUltimasVersoes
            // 
            this.cbQuantidadeDeUltimasVersoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbQuantidadeDeUltimasVersoes.FormattingEnabled = true;
            this.cbQuantidadeDeUltimasVersoes.Location = new System.Drawing.Point(16, 55);
            this.cbQuantidadeDeUltimasVersoes.Name = "cbQuantidadeDeUltimasVersoes";
            this.cbQuantidadeDeUltimasVersoes.Size = new System.Drawing.Size(121, 21);
            this.cbQuantidadeDeUltimasVersoes.TabIndex = 1;
            // 
            // ckManterUltimasVersões
            // 
            this.ckManterUltimasVersões.AutoSize = true;
            this.ckManterUltimasVersões.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckManterUltimasVersões.Location = new System.Drawing.Point(16, 23);
            this.ckManterUltimasVersões.Name = "ckManterUltimasVersões";
            this.ckManterUltimasVersões.Size = new System.Drawing.Size(146, 17);
            this.ckManterUltimasVersões.TabIndex = 0;
            this.ckManterUltimasVersões.Text = "Manter Ultimas Versões ?";
            this.ckManterUltimasVersões.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // btnProcurarDestino
            // 
            this.btnProcurarDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarDestino.Location = new System.Drawing.Point(250, 58);
            this.btnProcurarDestino.Name = "btnProcurarDestino";
            this.btnProcurarDestino.Size = new System.Drawing.Size(75, 23);
            this.btnProcurarDestino.TabIndex = 9;
            this.btnProcurarDestino.Text = "Destino";
            this.btnProcurarDestino.UseVisualStyleBackColor = true;
            this.btnProcurarDestino.Click += new System.EventHandler(this.btnProcurarDestino_Click);
            // 
            // tbOrigem
            // 
            this.tbOrigem.Location = new System.Drawing.Point(19, 15);
            this.tbOrigem.Name = "tbOrigem";
            this.tbOrigem.Size = new System.Drawing.Size(216, 20);
            this.tbOrigem.TabIndex = 6;
            // 
            // btnProcurarOrigem
            // 
            this.btnProcurarOrigem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarOrigem.Location = new System.Drawing.Point(250, 13);
            this.btnProcurarOrigem.Name = "btnProcurarOrigem";
            this.btnProcurarOrigem.Size = new System.Drawing.Size(75, 23);
            this.btnProcurarOrigem.TabIndex = 8;
            this.btnProcurarOrigem.Text = "Origem";
            this.btnProcurarOrigem.UseVisualStyleBackColor = true;
            this.btnProcurarOrigem.Click += new System.EventHandler(this.btnProcurarOrigem_Click);
            // 
            // tbDestino
            // 
            this.tbDestino.Location = new System.Drawing.Point(19, 60);
            this.tbDestino.Name = "tbDestino";
            this.tbDestino.Size = new System.Drawing.Size(216, 20);
            this.tbDestino.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Location = new System.Drawing.Point(215, 287);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(77, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // patrikSystemBackupGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 322);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pnlCordenadasBackup);
            this.Controls.Add(this.button1);
            this.Name = "patrikSystemBackupGUI";
            this.Text = "Form1";
            this.pnlCordenadasBackup.ResumeLayout(false);
            this.pnlCordenadasBackup.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog fbdLocalDoArquivo;
        private System.Windows.Forms.Panel pnlCordenadasBackup;
        private System.Windows.Forms.Button btnProcurarDestino;
        private System.Windows.Forms.TextBox tbOrigem;
        private System.Windows.Forms.Button btnProcurarOrigem;
        private System.Windows.Forms.TextBox tbDestino;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblExtensaoDoBaclup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuantidadeDeUltimasVersoes;
        private System.Windows.Forms.ComboBox cbQuantidadeDeUltimasVersoes;
        private System.Windows.Forms.CheckBox ckManterUltimasVersões;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}


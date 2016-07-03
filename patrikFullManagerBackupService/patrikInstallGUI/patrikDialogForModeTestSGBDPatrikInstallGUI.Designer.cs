namespace patrikInstallGUI {
    partial class patrikDialogForModeTestSGBDPatrikInstallGUI {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(patrikDialogForModeTestSGBDPatrikInstallGUI));
            this.rtbMsgErrorShowHere = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.BtnCopytoClipBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbMsgErrorShowHere
            // 
            this.rtbMsgErrorShowHere.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMsgErrorShowHere.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rtbMsgErrorShowHere.Location = new System.Drawing.Point(0, 0);
            this.rtbMsgErrorShowHere.Margin = new System.Windows.Forms.Padding(10);
            this.rtbMsgErrorShowHere.Name = "rtbMsgErrorShowHere";
            this.rtbMsgErrorShowHere.ReadOnly = true;
            this.rtbMsgErrorShowHere.Size = new System.Drawing.Size(773, 390);
            this.rtbMsgErrorShowHere.TabIndex = 0;
            this.rtbMsgErrorShowHere.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(672, 410);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // BtnCopytoClipBoard
            // 
            this.BtnCopytoClipBoard.Location = new System.Drawing.Point(580, 410);
            this.BtnCopytoClipBoard.Name = "BtnCopytoClipBoard";
            this.BtnCopytoClipBoard.Size = new System.Drawing.Size(75, 23);
            this.BtnCopytoClipBoard.TabIndex = 1;
            this.BtnCopytoClipBoard.Text = "Clipboard";
            this.BtnCopytoClipBoard.UseVisualStyleBackColor = true;
            this.BtnCopytoClipBoard.Click += new System.EventHandler(this.BtnCopytoClipBoard_Click);
            // 
            // dialogForModeTestSGBDPatrikInstallGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 445);
            this.Controls.Add(this.BtnCopytoClipBoard);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rtbMsgErrorShowHere);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dialogForModeTestSGBDPatrikInstallGUI";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMsgErrorShowHere;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button BtnCopytoClipBoard;
    }
}
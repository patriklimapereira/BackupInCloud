namespace patrikInstallFileSilentFull {
    partial class instalIcones {
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
            this.btnStartJobs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartJobs
            // 
            this.btnStartJobs.Location = new System.Drawing.Point(191, 183);
            this.btnStartJobs.Name = "btnStartJobs";
            this.btnStartJobs.Size = new System.Drawing.Size(75, 23);
            this.btnStartJobs.TabIndex = 0;
            this.btnStartJobs.Text = "start";
            this.btnStartJobs.UseVisualStyleBackColor = true;
            this.btnStartJobs.Click += new System.EventHandler(this.btnStartJobs_Click);
            // 
            // instalIcones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 218);
            this.Controls.Add(this.btnStartJobs);
            this.Name = "instalIcones";
            this.Text = "Icon Agil";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartJobs;
    }
}


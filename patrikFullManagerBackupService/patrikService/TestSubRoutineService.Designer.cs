namespace patrikService {
    partial class TestSubRoutineService {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param text="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSimulationRoutine = new System.Windows.Forms.Button();
            this.btnConnectOnedriver = new System.Windows.Forms.Button();
            this.tabControlTest = new System.Windows.Forms.TabControl();
            this.tpOneDriver = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCompress = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlTest.SuspendLayout();
            this.tpOneDriver.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 217);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1165, 119);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btnSimulationRoutine
            // 
            this.btnSimulationRoutine.Location = new System.Drawing.Point(21, 18);
            this.btnSimulationRoutine.Name = "btnSimulationRoutine";
            this.btnSimulationRoutine.Size = new System.Drawing.Size(127, 23);
            this.btnSimulationRoutine.TabIndex = 5;
            this.btnSimulationRoutine.Text = " Routine";
            this.btnSimulationRoutine.UseVisualStyleBackColor = true;
            this.btnSimulationRoutine.Click += new System.EventHandler(this.btnRoutine_Click);
            // 
            // btnConnectOnedriver
            // 
            this.btnConnectOnedriver.Location = new System.Drawing.Point(19, 17);
            this.btnConnectOnedriver.Name = "btnConnectOnedriver";
            this.btnConnectOnedriver.Size = new System.Drawing.Size(75, 23);
            this.btnConnectOnedriver.TabIndex = 6;
            this.btnConnectOnedriver.Text = "Connect";
            this.btnConnectOnedriver.UseVisualStyleBackColor = true;
            this.btnConnectOnedriver.Click += new System.EventHandler(this.btnConnectOnedriver_Click);
            // 
            // tabControlTest
            // 
            this.tabControlTest.Controls.Add(this.tpOneDriver);
            this.tabControlTest.Controls.Add(this.tabPage2);
            this.tabControlTest.Location = new System.Drawing.Point(600, 18);
            this.tabControlTest.Name = "tabControlTest";
            this.tabControlTest.SelectedIndex = 0;
            this.tabControlTest.Size = new System.Drawing.Size(586, 175);
            this.tabControlTest.TabIndex = 8;
            // 
            // tpOneDriver
            // 
            this.tpOneDriver.Controls.Add(this.btnConnectOnedriver);
            this.tpOneDriver.Location = new System.Drawing.Point(4, 22);
            this.tpOneDriver.Name = "tpOneDriver";
            this.tpOneDriver.Padding = new System.Windows.Forms.Padding(3);
            this.tpOneDriver.Size = new System.Drawing.Size(578, 149);
            this.tpOneDriver.TabIndex = 0;
            this.tpOneDriver.Text = "OneDriver";
            this.tpOneDriver.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCompress);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 149);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(6, 18);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(75, 23);
            this.btnCompress.TabIndex = 0;
            this.btnCompress.Text = "compress";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // TestSubRoutineService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControlTest);
            this.Controls.Add(this.btnSimulationRoutine);
            this.Controls.Add(this.richTextBox1);
            this.Name = "TestSubRoutineService";
            this.Text = "TestSubRoutineService";
            this.tabControlTest.ResumeLayout(false);
            this.tpOneDriver.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSimulationRoutine;
        private System.Windows.Forms.Button btnConnectOnedriver;
        private System.Windows.Forms.TabControl tabControlTest;
        private System.Windows.Forms.TabPage tpOneDriver;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button button1;
    }
}
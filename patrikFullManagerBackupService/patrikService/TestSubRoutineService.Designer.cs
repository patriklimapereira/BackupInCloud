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
            this.intelligenceRoutines = new System.Windows.Forms.TabControl();
            this.tpOneDriver = new System.Windows.Forms.TabPage();
            this.btnSelect = new System.Windows.Forms.Button();
            this.listFolder = new System.Windows.Forms.Button();
            this.SevenZip = new System.Windows.Forms.TabPage();
            this.btnTestCompressFile = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.RoutineMoveFilesAndHash = new System.Windows.Forms.TabPage();
            this.testGenerateForFileHash = new System.Windows.Forms.Button();
            this.RDMS = new System.Windows.Forms.TabPage();
            this.testQueryP2 = new System.Windows.Forms.Button();
            this.testeQueryParameter = new System.Windows.Forms.Button();
            this.testQuery = new System.Windows.Forms.Button();
            this.testRDMS = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.validateGetNameDateTimeHash = new System.Windows.Forms.Button();
            this.geral = new System.Windows.Forms.TabPage();
            this.returnDate = new System.Windows.Forms.Button();
            this.ddlInsert = new System.Windows.Forms.Button();
            this.intelligenceRoutines.SuspendLayout();
            this.tpOneDriver.SuspendLayout();
            this.SevenZip.SuspendLayout();
            this.RoutineMoveFilesAndHash.SuspendLayout();
            this.RDMS.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.geral.SuspendLayout();
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
            // intelligenceRoutines
            // 
            this.intelligenceRoutines.Controls.Add(this.tpOneDriver);
            this.intelligenceRoutines.Controls.Add(this.SevenZip);
            this.intelligenceRoutines.Controls.Add(this.RoutineMoveFilesAndHash);
            this.intelligenceRoutines.Controls.Add(this.RDMS);
            this.intelligenceRoutines.Controls.Add(this.tabPage1);
            this.intelligenceRoutines.Controls.Add(this.geral);
            this.intelligenceRoutines.Location = new System.Drawing.Point(600, 18);
            this.intelligenceRoutines.Name = "intelligenceRoutines";
            this.intelligenceRoutines.SelectedIndex = 0;
            this.intelligenceRoutines.Size = new System.Drawing.Size(586, 175);
            this.intelligenceRoutines.TabIndex = 8;
            // 
            // tpOneDriver
            // 
            this.tpOneDriver.Controls.Add(this.btnSelect);
            this.tpOneDriver.Controls.Add(this.listFolder);
            this.tpOneDriver.Controls.Add(this.btnConnectOnedriver);
            this.tpOneDriver.Location = new System.Drawing.Point(4, 22);
            this.tpOneDriver.Name = "tpOneDriver";
            this.tpOneDriver.Padding = new System.Windows.Forms.Padding(3);
            this.tpOneDriver.Size = new System.Drawing.Size(578, 149);
            this.tpOneDriver.TabIndex = 0;
            this.tpOneDriver.Text = "OneDriver";
            this.tpOneDriver.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(220, 17);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "ExecuteReader";
            this.btnSelect.UseMnemonic = false;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // listFolder
            // 
            this.listFolder.Location = new System.Drawing.Point(121, 17);
            this.listFolder.Name = "listFolder";
            this.listFolder.Size = new System.Drawing.Size(75, 23);
            this.listFolder.TabIndex = 7;
            this.listFolder.Text = "listFolder";
            this.listFolder.UseVisualStyleBackColor = true;
            this.listFolder.Click += new System.EventHandler(this.listFolder_Click);
            // 
            // SevenZip
            // 
            this.SevenZip.Controls.Add(this.btnTestCompressFile);
            this.SevenZip.Controls.Add(this.btnCompress);
            this.SevenZip.Location = new System.Drawing.Point(4, 22);
            this.SevenZip.Name = "SevenZip";
            this.SevenZip.Padding = new System.Windows.Forms.Padding(3);
            this.SevenZip.Size = new System.Drawing.Size(578, 149);
            this.SevenZip.TabIndex = 1;
            this.SevenZip.Text = "7zip";
            this.SevenZip.UseVisualStyleBackColor = true;
            // 
            // btnTestCompressFile
            // 
            this.btnTestCompressFile.Location = new System.Drawing.Point(120, 17);
            this.btnTestCompressFile.Name = "btnTestCompressFile";
            this.btnTestCompressFile.Size = new System.Drawing.Size(75, 23);
            this.btnTestCompressFile.TabIndex = 1;
            this.btnTestCompressFile.Text = "testCompress";
            this.btnTestCompressFile.UseVisualStyleBackColor = true;
            this.btnTestCompressFile.Click += new System.EventHandler(this.btnTestCompressFile_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(16, 17);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(75, 23);
            this.btnCompress.TabIndex = 0;
            this.btnCompress.Text = "compress";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // RoutineMoveFilesAndHash
            // 
            this.RoutineMoveFilesAndHash.Controls.Add(this.testGenerateForFileHash);
            this.RoutineMoveFilesAndHash.Location = new System.Drawing.Point(4, 22);
            this.RoutineMoveFilesAndHash.Name = "RoutineMoveFilesAndHash";
            this.RoutineMoveFilesAndHash.Size = new System.Drawing.Size(578, 149);
            this.RoutineMoveFilesAndHash.TabIndex = 2;
            this.RoutineMoveFilesAndHash.Text = "RoutineMoveFilesAndHash";
            this.RoutineMoveFilesAndHash.UseVisualStyleBackColor = true;
            // 
            // testGenerateForFileHash
            // 
            this.testGenerateForFileHash.Location = new System.Drawing.Point(26, 19);
            this.testGenerateForFileHash.Name = "testGenerateForFileHash";
            this.testGenerateForFileHash.Size = new System.Drawing.Size(75, 23);
            this.testGenerateForFileHash.TabIndex = 0;
            this.testGenerateForFileHash.Text = "testHash";
            this.testGenerateForFileHash.UseVisualStyleBackColor = true;
            this.testGenerateForFileHash.Click += new System.EventHandler(this.testGenerateForFileHash_Click);
            // 
            // RDMS
            // 
            this.RDMS.Controls.Add(this.ddlInsert);
            this.RDMS.Controls.Add(this.testQueryP2);
            this.RDMS.Controls.Add(this.testeQueryParameter);
            this.RDMS.Controls.Add(this.testQuery);
            this.RDMS.Controls.Add(this.testRDMS);
            this.RDMS.Location = new System.Drawing.Point(4, 22);
            this.RDMS.Name = "RDMS";
            this.RDMS.Padding = new System.Windows.Forms.Padding(3);
            this.RDMS.Size = new System.Drawing.Size(578, 149);
            this.RDMS.TabIndex = 3;
            this.RDMS.Text = "RDMS";
            this.RDMS.UseVisualStyleBackColor = true;
            // 
            // testQueryP2
            // 
            this.testQueryP2.Location = new System.Drawing.Point(320, 18);
            this.testQueryP2.Name = "testQueryP2";
            this.testQueryP2.Size = new System.Drawing.Size(75, 23);
            this.testQueryP2.TabIndex = 3;
            this.testQueryP2.Text = "testQueryP2";
            this.testQueryP2.UseVisualStyleBackColor = true;
            this.testQueryP2.Click += new System.EventHandler(this.testQueryP2_Click);
            // 
            // testeQueryParameter
            // 
            this.testeQueryParameter.Location = new System.Drawing.Point(223, 18);
            this.testeQueryParameter.Name = "testeQueryParameter";
            this.testeQueryParameter.Size = new System.Drawing.Size(75, 23);
            this.testeQueryParameter.TabIndex = 2;
            this.testeQueryParameter.Text = "testeQueryParameter";
            this.testeQueryParameter.UseVisualStyleBackColor = true;
            this.testeQueryParameter.Click += new System.EventHandler(this.testeQueryParameter_Click);
            // 
            // testQuery
            // 
            this.testQuery.Location = new System.Drawing.Point(120, 18);
            this.testQuery.Name = "testQuery";
            this.testQuery.Size = new System.Drawing.Size(75, 23);
            this.testQuery.TabIndex = 1;
            this.testQuery.Text = "testQuery";
            this.testQuery.UseVisualStyleBackColor = true;
            this.testQuery.Click += new System.EventHandler(this.testQuery_Click);
            // 
            // testRDMS
            // 
            this.testRDMS.Location = new System.Drawing.Point(15, 18);
            this.testRDMS.Name = "testRDMS";
            this.testRDMS.Size = new System.Drawing.Size(75, 23);
            this.testRDMS.TabIndex = 0;
            this.testRDMS.Text = "testRDMS";
            this.testRDMS.UseVisualStyleBackColor = true;
            this.testRDMS.Click += new System.EventHandler(this.testRDMS_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.validateGetNameDateTimeHash);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 149);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "intelligenceRoutines";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // validateGetNameDateTimeHash
            // 
            this.validateGetNameDateTimeHash.Location = new System.Drawing.Point(23, 22);
            this.validateGetNameDateTimeHash.Name = "validateGetNameDateTimeHash";
            this.validateGetNameDateTimeHash.Size = new System.Drawing.Size(184, 23);
            this.validateGetNameDateTimeHash.TabIndex = 0;
            this.validateGetNameDateTimeHash.Text = "validateGetNameDateTimeHash";
            this.validateGetNameDateTimeHash.UseVisualStyleBackColor = true;
            this.validateGetNameDateTimeHash.Click += new System.EventHandler(this.validateGetNameDateTimeHash_Click);
            // 
            // geral
            // 
            this.geral.Controls.Add(this.returnDate);
            this.geral.Location = new System.Drawing.Point(4, 22);
            this.geral.Name = "geral";
            this.geral.Padding = new System.Windows.Forms.Padding(3);
            this.geral.Size = new System.Drawing.Size(578, 149);
            this.geral.TabIndex = 5;
            this.geral.Text = "geral";
            this.geral.UseVisualStyleBackColor = true;
            // 
            // returnDate
            // 
            this.returnDate.Location = new System.Drawing.Point(22, 28);
            this.returnDate.Name = "returnDate";
            this.returnDate.Size = new System.Drawing.Size(75, 23);
            this.returnDate.TabIndex = 0;
            this.returnDate.Text = "button1";
            this.returnDate.UseVisualStyleBackColor = true;
            this.returnDate.Click += new System.EventHandler(this.returnDate_Click);
            // 
            // ddlInsert
            // 
            this.ddlInsert.Location = new System.Drawing.Point(433, 18);
            this.ddlInsert.Name = "ddlInsert";
            this.ddlInsert.Size = new System.Drawing.Size(75, 23);
            this.ddlInsert.TabIndex = 4;
            this.ddlInsert.Text = "Insert";
            this.ddlInsert.UseVisualStyleBackColor = true;
            this.ddlInsert.Click += new System.EventHandler(this.ddlInsert_Click);
            // 
            // TestSubRoutineService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 362);
            this.Controls.Add(this.intelligenceRoutines);
            this.Controls.Add(this.btnSimulationRoutine);
            this.Controls.Add(this.richTextBox1);
            this.Name = "TestSubRoutineService";
            this.Text = "TestSubRoutineService";
            this.intelligenceRoutines.ResumeLayout(false);
            this.tpOneDriver.ResumeLayout(false);
            this.SevenZip.ResumeLayout(false);
            this.RoutineMoveFilesAndHash.ResumeLayout(false);
            this.RDMS.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.geral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSimulationRoutine;
        private System.Windows.Forms.Button btnConnectOnedriver;
        private System.Windows.Forms.TabControl intelligenceRoutines;
        private System.Windows.Forms.TabPage tpOneDriver;
        private System.Windows.Forms.TabPage SevenZip;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnTestCompressFile;
        private System.Windows.Forms.TabPage RoutineMoveFilesAndHash;
        private System.Windows.Forms.Button testGenerateForFileHash;
        private System.Windows.Forms.TabPage RDMS;
        private System.Windows.Forms.Button testRDMS;
        private System.Windows.Forms.Button testQuery;
        private System.Windows.Forms.Button testeQueryParameter;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button validateGetNameDateTimeHash;
        private System.Windows.Forms.Button listFolder;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TabPage geral;
        private System.Windows.Forms.Button returnDate;
        private System.Windows.Forms.Button testQueryP2;
        private System.Windows.Forms.Button ddlInsert;
    }
}
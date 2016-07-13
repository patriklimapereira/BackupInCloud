namespace patrikSystemBackup {
    partial class ProjectInstaller {
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ProcesBackupService = new System.ServiceProcess.ServiceProcessInstaller();
            this.PatrikSystemBackup = new System.ServiceProcess.ServiceInstaller();
            // 
            // ProcesBackupService
            // 
            this.ProcesBackupService.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.ProcesBackupService.Password = null;
            this.ProcesBackupService.Username = null;
            // 
            // PatrikSystemBackup
            // 
            this.PatrikSystemBackup.DisplayName = "PatrikSystemBackup";
            this.PatrikSystemBackup.ServiceName = "PatrikSystemBackup";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ProcesBackupService,
            this.PatrikSystemBackup});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ProcesBackupService;
        private System.ServiceProcess.ServiceInstaller PatrikSystemBackup;
    }
}
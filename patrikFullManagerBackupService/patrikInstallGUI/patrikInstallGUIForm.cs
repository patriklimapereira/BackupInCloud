using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using patrikDll;
using PatrikSystemPersistence;
using System;
using System.Threading;
using System.Diagnostics;
using System.Security.Principal;



namespace patrikInstallGUI {
    public partial class patrikInstallGUIForm : Form {
        public patrikInstallGUIForm() {
            InitializeComponent();
        }


        private void patrikInstallGUIForm_Load(object sender, EventArgs e) {
            /*   WindowsIdentity wi = WindowsIdentity.GetCurrent();
               WindowsPrincipal wp = new WindowsPrincipal(wi);
               bool isAdministrator = wp.IsInRole(WindowsBuiltInRole.Administrator);
               if (isAdministrator == false) {
                   RunAsAdministrator();
               }*/

        }

        static void RunAsAdministrator() {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Verb = "runas";
            try {
                Process.Start(proc);

            } catch (Win32Exception error) {
                //faz porra nenhuma  mas filtra parao excption full                        
            } catch (Exception error) {
                MessageBox.Show("Elevação de administrador para o  usuario corrente falhou.\n O Sistema sera finalizado, Se o Erro persistir efetue um screenshot desta tela e envie ao desenvolvedor\n" +
               "Message:\n" + error.Message + "\n__________________________________________________________________\n" +
               "Source:\n" + error.Source + "\n__________________________________________________________________\n" +
               "StackTrace:\n" + error.StackTrace, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }


        private void purifyInputLabelOfConfigurationOfTheRDMS() {
            tbServer.Text = tbServer.Text.Trim();
            tbPort.Text = tbPort.Text.Trim();
            tbDataBase.Text = tbDataBase.Text.Trim();

        }
        private void btnInstall_Click(object sender, EventArgs e) {
           
            String auxMsg;
            this.purifyInputLabelOfConfigurationOfTheRDMS();
            this.rtbDisplayOperation.Clear();

            auxMsg = this.validatesLabelConfigurationDataBase();
            if (auxMsg != "ok") {
                MessageBox.Show("this problems in parameter of configuration of the dataBase were found :\n" + auxMsg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if (UtilPatrikInstallGUI.createDirectories(this.rtbDisplayOperation) != true) {
                if (WorkerDirectory.directoryExist(UtilPatrikInstallGUI.FMBSDirectoryPatrikFullManagerBackupService[0]) == true) {
                    this.uninstallSystem("error");
                }
            } else if (UtilPatrikInstallGUI.createFiles(this.rtbDisplayOperation) != true) {
                this.uninstallSystem("error");

            } else if (UtilPatrikInstallGUI.installConfigurationDataBase(tbServer.Text, tbPort.Text, tbUserName.Text, tbPassword.Text, tbDataBase.Text, this.rtbDisplayOperation) != "ok") {
                this.uninstallSystem("error");
                /*routine try drop dataBase*/
            } else if (true == true) {
                /*create in future register service */
            }
        }

        private void routineForExclusionAll(object sender, EventArgs e) {
            if (WorkerDirectory.directoryExist(UtilPatrikInstallGUI.FMBSDirectoryPatrikFullManagerBackupService[0]) == true) {
                /*routine verify after*/
                this.uninstallSystem();
            }
        }

        private bool uninstallSystem(string error = "") {
            String serverName, port, userName, password, databaseName;
            bool modeDevelopment = true;
            String auxMsg;
            this.purifyInputLabelOfConfigurationOfTheRDMS();
            /*create in future unregister service */
            if (true != true) {
                /*future implementation*/

            } else if (UtilPatrikInstallGUI.unistallConfigurationDataBase(tbServer.Text, tbPort.Text, tbUserName.Text, tbPassword.Text, tbDataBase.Text, this.rtbDisplayOperation, error) != "ok") {
                /*future implementation */
            } else if (UtilPatrikInstallGUI.unistalldirectoriesAndFiles(this.rtbDisplayOperation, error) != true) {
                /*future implementation*/
            }
            WorkerFile.writeFile(Util.psGETCURRENTDIRECTORY, UtilPatrikInstallGUI.psFilesLocalInstall[0], rtbDisplayOperation.Text, true);
            return true;

        }

        private void btnUninstall_Click(object sender, EventArgs e) {
            this.rtbDisplayOperation.Clear();
            this.uninstallSystem(); 
        }

        private string validatesLabelConfigurationDataBase() {
            this.purifyInputLabelOfConfigurationOfTheRDMS();
            String auxString = "ok";         
            if (tbServer.Text.Length == 0) {
                auxString = "O campo " + lblServerName.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                tbServer.Focus();
            } else {
                if (tbPort.Text.Length == 0) {
                    auxString = "O campo " + lblPort.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                    tbPort.Focus();
                } else {
                    if (tbPassword.Text.Length == 0) {
                        auxString = "O campo " + lblUser.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                        tbUserName.Focus();
                    } else {
                        if (tbDataBase.Text.Length == 0) {
                            auxString = "O campo " + lblDataBase.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                            tbDataBase.Focus();
                        }
                    }
                }
            }
            return auxString;
        }


        private void btnTest_Click(object sender, EventArgs e) {
            string result;
            this.purifyInputLabelOfConfigurationOfTheRDMS();
            result = this.validatesLabelConfigurationDataBase();
            if (result != "ok") {
                MessageBox.Show("Error in value informed for to acess database", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                result = UtilPatrikInstallGUI.testConnectionsRDMS(tbServer.Text, tbPort.Text, tbUserName.Text, tbPassword.Text, tbDataBase.Text);
                switch (result) {
                    case "ok":
                        MessageBox.Show("The configuration of the database is ok!!!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        Form f = new patrikDialogForModeTestSGBDPatrikInstallGUI();
                        f.Text = "Erro to acess database";
                        f.Controls["rtbMsgErrorShowHere"].Text = result;
                        f.ShowDialog(this);
                        break;
                }
            }

        }

     

        private void patrikInstallGUIForm_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e) {
            Clipboard.SetText(this.rtbDisplayOperation.Text);
        }
    }


}



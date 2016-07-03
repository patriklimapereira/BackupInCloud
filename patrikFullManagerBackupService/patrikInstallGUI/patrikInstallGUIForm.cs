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



namespace patrikInstallGUI
{
    public partial class patrikInstallGUIForm : Form
    {
        public patrikInstallGUIForm()
        {
            InitializeComponent();
        }


        private void patrikInstallGUIForm_Load(object sender, EventArgs e)
        {
            /*   WindowsIdentity wi = WindowsIdentity.GetCurrent();
               WindowsPrincipal wp = new WindowsPrincipal(wi);
               bool isAdministrator = wp.IsInRole(WindowsBuiltInRole.Administrator);
               if (isAdministrator == false) {
                   RunAsAdministrator();
               }*/

        }

        static void RunAsAdministrator()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Verb = "runas";
            try
            {
                Process.Start(proc);

            }
            catch (Win32Exception error)
            {
                //faz porra nenhuma  mas filtra parao excption full                        
            }
            catch (Exception error)
            {
                MessageBox.Show("Elevação de administrador para o  usuario corrente falhou.\n O Sistema sera finalizado, Se o Erro persistir efetue um screenshot desta tela e envie ao desenvolvedor\n" +
               "Message:\n" + error.Message + "\n__________________________________________________________________\n" +
               "Source:\n" + error.Source + "\n__________________________________________________________________\n" +
               "StackTrace:\n" + error.StackTrace, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            /*Criação dos diretorios*/
            /*flag marca se deu ruim ou não se TRUE = problemas || se FALSE = tudoOK*/
            bool deuRuim = false;
            String deuOk = "ok";

            deuRuim = !FunctionForInstalation.createDiretorios(this.rtbDisplayOperation);
           
            /*deuRuim = false; utilizado para testar rotina de desistalação*/
            if (deuRuim == true)
            {
                if (WorkDirectory.directoryExist(Util.FMBSDirectoryPatrikFullManagerBackupService[0]) == true)
                {
                    rotinaParaExclusaoDaPorraToda(sender, e);
                }
            }
            else
            {
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "end-install:directory ", 700, this.rtbDisplayOperation);
                /*inicio da rotina de instalação dos arquivos*/
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "begin-install:files", 300, this.rtbDisplayOperation);
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "criação dos arquivos", 300, this.rtbDisplayOperation);
                /*for para criar os arquivos*/
                for (int i = 0; i < Util.FMBSFilePatrikFullManagerBackupService.Count && deuRuim == false; i++)
                {
                    Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "create - \"" + Util.FMBSFilePatrikFullManagerBackupService[i] + "\" : ", 600, this.rtbDisplayOperation, String.Empty);
                    switch (Util.FMBSInstalarFile(Util.FMBSDirectoryPatrikFullManagerBackupService[i], Util.FMBSFilePatrikFullManagerBackupService[i]))
                    {
                        case 1:
                            Util.psMsgAtrasoRefresh("ok", 400, this.rtbDisplayOperation);
                            break;
                        case 3:
                            Util.psMsgAtrasoRefresh("fail - file already exist", 400, this.rtbDisplayOperation);
                            break;
                        case 0:
                            Util.psMsgAtrasoRefresh("fail - Erro na criação do arquivo", 700, this.rtbDisplayOperation);
                            deuRuim = true;
                            break;
                    }
                }

                if (deuRuim == false)
                {
                    /*end for para criar os arquivos*/
                    Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "end-install:files ", 700, this.rtbDisplayOperation);
                    String dadosDoSGBDAndBanco = tbSever.Text + Util.psSeparator[1] + tbPort.Text + Util.psSeparator[1] + tbUser.Text + Util.psSeparator[1] + tbPassword.Text + Util.psSeparator[1] + tbDataBase.Text;
                    Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "begin-install:configuration database", 600, this.rtbDisplayOperation);
                    Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "registrando configuração de acesso ao banco de dados", 400, this.rtbDisplayOperation);
                    deuOk = this.bancoDeDadosConfiguradoCorretamente();
                    if (deuOk == "ok")
                    {
                        deuRuim = !WorkFile.writeFile(false, Util.FMBSDirectoryPatrikFullManagerBackupService[0], Util.FMBSFilePatrikFullManagerBackupService[1], dadosDoSGBDAndBanco, false);
                        if (deuRuim == false)
                        {
                            Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "configurações de acesso ao banco de dados registradas com sucesso", 400, this.rtbDisplayOperation);
                            Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "end-install:configuration database", 700, this.rtbDisplayOperation);


                        }
                        else
                        {
                            Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "psErro no registro de configuração de acesso ao banco de dados", 400, this.rtbDisplayOperation);
                            rotinaParaExclusaoDaPorraToda(sender, e);
                        }
                        /* inserir aqui rotina para  registrar o serviço*/

                    }
                    else
                    {
                        Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "Detectado configurações inconsistente nos parametros de acesso ao banco de dados", 400, this.rtbDisplayOperation);
                        Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + deuOk.Replace("\n", " "), 400, this.rtbDisplayOperation);
                        rotinaParaExclusaoDaPorraToda(sender, e);

                    }
                }
                else
                {
                    rotinaParaExclusaoDaPorraToda(sender, e);
                }
            }
        }

        private void rotinaParaExclusaoDaPorraToda(object sender, EventArgs e)
        {
            if (WorkDirectory.directoryExist(Util.FMBSDirectoryPatrikFullManagerBackupService[0]) == true)
            {
                Console.Write("\a");
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "Existiu um psErro durante a operação", 400, this.rtbDisplayOperation);
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "O sistema sera desistalado", 700, this.rtbDisplayOperation);
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "Rotina de desistalação ativada", 1000, this.rtbDisplayOperation);
                btnUninstall_Click(sender, e);
            }
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            bool deuRuim = false;
            /* verifica se o diretorio existe com base no diretorio mestre do sistema*/
            if (WorkDirectory.directoryExist(Util.FMBSDirectoryPatrikFullManagerBackupService[0]) == true)
            {
                /*rotina para serviçp*/
                /*rotina excluir banco*/
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "begin delete: directory and files ", 100, this.rtbDisplayOperation);
                System.Threading.Thread.Sleep(600);
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "delete \"" + Util.FMBSDirectoryPatrikFullManagerBackupService[0] + "\" : ", 600, this.rtbDisplayOperation, "");
                deuRuim = WorkDirectory.deleteDirectory(Util.FMBSDirectoryPatrikFullManagerBackupService[0]);
                if (deuRuim == true)
                {
                    Util.psMsgAtrasoRefresh("ok ", 600, this.rtbDisplayOperation);
                }
                else
                {
                    Util.psMsgAtrasoRefresh("fail ", 600, this.rtbDisplayOperation);
                }
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "end delete: directory and files ", 600, this.rtbDisplayOperation);

            }
            else
            {
                Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "O sistema não se encontra instalado, logo não se pode desistalá-lo", 600, this.rtbDisplayOperation);

            }
            Util.psMsgAtrasoRefresh("[" + Util.psRetornaTimeString() + "]" + " - " + "Arquivo de log \"" + Util.psFiles[0] + "\" gravado em   " + Util.psGETCURRENTDIRECTORY, 600, this.rtbDisplayOperation);
            WorkFile.writeFile(true, Util.psGETCURRENTDIRECTORY, Util.psFiles[0], rtbDisplayOperation.Text, true);





        }

        private string bancoDeDadosConfiguradoCorretamente()
        {
            String serverName, port, userName, password, databaseName, auxString;
            MessageBox.Show("test");

            serverName = tbSever.Text.Trim();
            port = tbPort.Text.Trim();
            userName = tbUser.Text;
            password = tbPassword.Text;
            databaseName = tbDataBase.Text.Trim();

            if (serverName.Length == 0)
            {
                auxString = "O campo " + lblServerName.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                tbSever.Focus();
            }
            else
            {
                if (port.Length == 0)
                {
                    auxString = "O campo " + lblPort.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                    tbPort.Focus();

                }
                else
                {
                    if (userName.Length == 0)
                    {
                        auxString = "O campo " + lblUser.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                        tbUser.Focus();
                    }
                    else
                    {
                        if (databaseName.Length == 0)
                        {
                            auxString = "O campo " + lblDataBase.Text.Replace(":", String.Empty) + " se encontra sem preenchimento.";
                            tbDataBase.Focus();
                        }
                        else
                        {
                            return WorkPostgreSQL.configurationIsOk(serverName, port, userName, password, databaseName);
                        }
                    }
                }
            }
            return auxString;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            String resultado = bancoDeDadosConfiguradoCorretamente();
            switch (resultado)
            {
                case "ok":
                    MessageBox.Show("A configuração do banco de dados esta correta!!!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    Form f = new dialogoDeTestSGBDPatrikInstallGUIForm();
                    f.Text = "Erro ao acessar o  banco de dados";
                    f.Controls["rtbDialogoDeErro"].Text = resultado;
                    f.ShowDialog(this);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new dialogoDeTestSGBDPatrikInstallGUIForm();
            f.Text = "Erro acesso banco de Dados";
            f.Controls["rtbDialogoDeErro"].Text = "ola";
            f.ShowDialog(this);
        }

        private void patrikInstallGUIForm_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }
    }


}



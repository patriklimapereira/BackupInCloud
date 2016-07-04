using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patrikDll;
using System.Windows.Forms;
using PatrikSystemPersistence;

namespace patrikInstallGUI {
   public class UtilpatrikInstallGUIForm {
        private static readonly int showTextHeaderInDisplay = 2;
        private static readonly int showInstructionsExecutedInDisplay = 2;

        public static string formatStringLog( String msg , string command, string result = "") {
                  return "[" + Util.psReturnTimeString() + "]" + "\t" + msg + ":->" + command + ( result == "" ? String.Empty : ":" + result);     
                  
        }
        public static bool createDirectories(RichTextBox rtb) {
            msgDelayRefresh(formatStringLog("begin-install", "directory"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            /*for for to create directories*/
            for (int i = 0; i < Util.FMBSDirectoryPatrikFullManagerBackupService.Count; i++) {

                switch (toInstallDirectory(Util.FMBSDirectoryPatrikFullManagerBackupService[i])) {
                    case 1:
                        msgDelayRefresh(formatStringLog("create" , Util.FMBSDirectoryPatrikFullManagerBackupService[i] , "ok"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 3:
                        msgDelayRefresh(formatStringLog("create" , Util.FMBSDirectoryPatrikFullManagerBackupService[i] , "fail - directory already exist"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 0:
                        msgDelayRefresh(formatStringLog("create", Util.FMBSDirectoryPatrikFullManagerBackupService[i] + "Fail - Error  in creation the directory"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        return false;
                }
            }
            msgDelayRefresh(formatStringLog("end-install","directory "), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return true;
        }



        public static bool createFiles(RichTextBox rtb) {
            /*begin routine of instalation of the files*/
            msgDelayRefresh(formatStringLog("begin-install","files"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

            /*for for to create the files*/
            for (int i = 0; i < Util.FMBSFilePatrikFullManagerBackupService.Count; i++) {
                switch (toInstallFiles(Util.FMBSDirectoryPatrikFullManagerBackupService[i], Util.FMBSFilePatrikFullManagerBackupService[i])) {
                    case 1:
                        msgDelayRefresh(formatStringLog("create" ,Util.FMBSFilePatrikFullManagerBackupService[i] , "ok"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 3:
                        msgDelayRefresh(formatStringLog("create" , Util.FMBSDirectoryPatrikFullManagerBackupService[i] , "fail - file already exist"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 0:
                        msgDelayRefresh(formatStringLog("create" , Util.FMBSDirectoryPatrikFullManagerBackupService[i] , "fail - erro in creation the file"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        return false;
                                   }
            }
            msgDelayRefresh(formatStringLog("end-install","files"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return true;
        }

        public static bool unistalldirectoriesAndFiles(RichTextBox rtb, string erro = "") {
            if (WorkDirectory.directoryExist(Util.FMBSDirectoryPatrikFullManagerBackupService[0]) == true) {
                msgDelayRefresh(formatStringLog( "begin-unistall"+(erro == "" ? String.Empty : "-"+erro), "directoriesAndfiles"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

                /*check method deleteDirectory in future - possible problems lock file or directories because open in windowns or other OS*/
                if (false == (WorkDirectory.deleteDirectory(Util.FMBSDirectoryPatrikFullManagerBackupService[0]))) {
                    msgDelayRefresh(formatStringLog("delete", "deleteRootDirectory", "fail - erro to delete root  directory" + Util.FMBSDirectoryPatrikFullManagerBackupService[0]), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                }
                msgDelayRefresh(formatStringLog("delete", "deleteRootDirectory", "ok - " + Util.FMBSDirectoryPatrikFullManagerBackupService[0]), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
            }
            msgDelayRefresh(formatStringLog("end-unistall" + (erro == "" ? String.Empty : "-"+erro), "directoriesAndfiles"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return true;
        }

        public static string installConfigurationDataBase(String sever, String port, String userName, String password, String dataBase, RichTextBox rtb) {
            String dataBaseCreateIsOk = "ok";
            msgDelayRefresh(formatStringLog("begin-install","configuration dataBase"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            dataBaseCreateIsOk = testConnectionsRDMS(sever, port, userName, password, dataBase);
            if(dataBaseCreateIsOk != "ok") {
                msgDelayRefresh(formatStringLog("test-connetion-dataBase", "fail - " +dataBaseCreateIsOk), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                return dataBaseCreateIsOk;
            }
            msgDelayRefresh(formatStringLog("test-connetion-dataBase", dataBaseCreateIsOk), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
            /*write file routine acess database*/
            msgDelayRefresh(formatStringLog("end-install","configuration dataBase"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return dataBaseCreateIsOk;
        }

        public static string testConnectionsRDMS(string sever, string port, string userName, string password, string dataBase) {
                     return WorkPostgreSQL.configurationIsOk(sever, port, userName, password, dataBase);
        }

        public static string unistallConfigurationDataBase(String sever, String port, String userName, String password, String dataBase, RichTextBox rtb, string erro = "") {
            String dataBaseCreateIsOk = "ok";
            msgDelayRefresh(formatStringLog(String.Concat("begin-unistall",(erro == "" ? String.Empty : "-"+erro)), "remove configuration dataBase "), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
             /*remove file routine acess database*/
            msgDelayRefresh(formatStringLog(String.Concat("end-unistall", (erro == "" ? String.Empty : "-" + erro)), "remove configuration dataBase "), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return dataBaseCreateIsOk;

        }

        public static bool recordLog(RichTextBox rtb, string erro = "") {
            msgDelayRefresh(formatStringLog(String.Concat("begin-register-unistall",  (erro == "" ? String.Empty : "-" + erro)) ,  "file log"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            WorkFile.writeFile(true, Util.psGETCURRENTDIRECTORY, Util.psFiles[0], rtb.Text, true);

            /*future routine case to ococcur erro in method   WorkFile.writeFile*/

            msgDelayRefresh(formatStringLog( String.Concat ("logfile", "\"", Util.psFiles[0], "\""), "record in ", Util.psGETCURRENTDIRECTORY), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
   
            msgDelayRefresh(formatStringLog(String.Concat("end-register-unistall", (erro == "" ? String.Empty : "-" + erro)), "file log"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
                    
            return true;
        }

        public static void msgDelayRefresh(string msg, int delay, RichTextBox rtb, String quebra = "\n") {
            rtb.Text += msg + quebra;
            rtb.SelectionStart = rtb.Text.Length;
            rtb.ScrollToCaret();/*move for down scroll bar*/
            System.Threading.Thread.Sleep(delay);
            rtb.Refresh();

        }

        /*metodos usados somente no instalador*/
        public static int toInstallDirectory(String stringDiretorio) {
            try {
                if (WorkDirectory.directoryExist(stringDiretorio) == true) {
                    return 3;
                }
                return Convert.ToInt32(WorkDirectory.createDirectory(stringDiretorio)); /* 1 criou e 0 não criou*/

            } catch (Exception error) {
                /*acerta os parametros dos metodos*/
                Util.psErro(Util.psErroWhatsToDo[0], false, Util.psGETCURRENTDIRECTORY, Util.psFiles[0], "public static int toInstallDirectory(String stringDiretorio){", error.Message + Util.psSeparator[2] + error.Source + Util.psSeparator[2] + error.StackTrace);
                return 0;
            }
        }

        /*metodos usados somente no instalador*/
        public static int toInstallFiles(String stringDiretorio, String stringArquivo) {
            try {
                if (WorkFile.fileExist(stringDiretorio, stringArquivo) == true) {
                    return 3;
                }
                return Convert.ToInt32(WorkFile.createEmptyFile(stringDiretorio, stringArquivo)); /* 1 criou e 0 não criou*/
            } catch (Exception error) {
                /*acerta os parametros dos metodos*/
                Util.psErro(Util.psErroWhatsToDo[0], false, Util.psGETCURRENTDIRECTORY, Util.psFiles[0], "public static int toInstallFiles(String stringDiretorio, String stringArquivo) {", error.Message + Util.psSeparator[2] + error.Source + Util.psSeparator[2] + error.StackTrace);
                return 0;
            }
        }

    }


}






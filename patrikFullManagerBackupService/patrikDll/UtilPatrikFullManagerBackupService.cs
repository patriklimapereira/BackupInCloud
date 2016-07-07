using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patrikDll;
using System.Windows.Forms;
using PatrikSystemPersistence;
using System.IO;

namespace patrikDll {
    public class UtilPatrikFullManagerBackupService {
        private static readonly int showTextHeaderInDisplay = 2;
        private static readonly int showInstructionsExecutedInDisplay = 2;
       private static readonly List<string> files = new List<string> { "psFailInstall.cma" };

        public static readonly string FMBSSystemName = "patrikFullManagerBackupService";
        public static readonly string FMBSSystemNamePrefixo = "psPatrikFullManagerBackupService";
        public static readonly string FMBSImg = "picture";
        public static readonly string FMBSTemp = "temp";
        public static readonly List<string> FMBSDirectoryPatrikFullManagerBackupService = new List<string>{  Util.psPROGRAMFILES + Util.psBAR_URL_SO + FMBSSystemNamePrefixo,
                                                                                             Util.psPROGRAMFILES + Util.psBAR_URL_SO + FMBSSystemNamePrefixo + Util.psBAR_URL_SO + FMBSImg,
                                                                                             Util.psPROGRAMFILES + Util.psBAR_URL_SO + FMBSSystemNamePrefixo + Util.psBAR_URL_SO + FMBSTemp,
        };

        public static readonly List<string> FMBSFilePatrikFullManagerBackupService = new List<string>{"psFILE_LOGpatrikFullManagerBackupService.cma",
                                                                                         "psCONFIGURATIONSGBDpatrikFullManagerBackupService.cma"
        };

        public static readonly List<string> psFilesLocalInstall = new List<String> { "log" };

        public static string formatStringLog(String msg, string command, string result = "") {
            return "[" + Util.psReturnTimeString() + "]" + "\t" + msg + ":->" + command + (result == "" ? String.Empty : ":" + result);

        }
        public static bool createDirectories(RichTextBox rtb) {
            msgDelayRefresh(formatStringLog("begin-install", "directory"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            /*for for to create directories*/
            for (int i = 0; i < UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService.Count; i++) {
                

                switch (toInstallDirectory(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[i])) {
                    case 1:
                        msgDelayRefresh(formatStringLog("create", UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[i], "ok"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 3:
                        msgDelayRefresh(formatStringLog("create", UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[i], "fail - directory already exist"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 0:
                        msgDelayRefresh(formatStringLog("create", UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[i] + "Fail - Error  in creation the directory"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        return false;
                }
            }
            msgDelayRefresh(formatStringLog("end-install", "directory "), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return true;
        }



      

        public static bool unistalldirectoriesAndFiles(RichTextBox rtb, string erro = "") {
            msgDelayRefresh(formatStringLog("begin-unistall" + (erro == "" ? String.Empty : "-" + erro), "directories And files"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

            if (WorkDirectory.directoryExist(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0]) == true) {                

                /*check method deleteDirectory in future - possible problems lock file or directories because open in windowns or other OS*/
                if (false == (WorkDirectory.deleteDirectory(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0]))) {

                    msgDelayRefresh(formatStringLog("delete", "deleteRootDirectory", "fail - erro to delete root  directory" + UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0]), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                }
                msgDelayRefresh(formatStringLog("delete", "deleteRootDirectory", "ok - " + UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0]), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);

                msgDelayRefresh(formatStringLog("end-unistall" + (erro == "" ? String.Empty : "-" + erro), "directoriesAndfiles"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

            }else {
                erro = "error";
                msgDelayRefresh(formatStringLog("end-unistall" + (erro == "" ? String.Empty : "-" + erro), "no unistall the directories and files no exists"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
               

            }
   
            return true;
        }

        public static string installConfigurationDataBase(String server, String port, String userName, String password, String dataBase, RichTextBox rtb) {
            String dataBaseCreateIsOk = "ok";
            String line = "";
          
            msgDelayRefresh(formatStringLog("begin-install", "configuration dataBase"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            dataBaseCreateIsOk = testConnectionsRDMS(server, port, userName, password, dataBase);
            if (dataBaseCreateIsOk != "ok") {
                msgDelayRefresh(formatStringLog("test-connetion-dataBase", "fail - " + dataBaseCreateIsOk), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                return dataBaseCreateIsOk;
            }

            line = server + ";" + port + ";" + userName + ";" + password + ";" + dataBase;
       
            msgDelayRefresh(formatStringLog("test-connetion-dataBase", dataBaseCreateIsOk), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
            if(   WorkFile.writeFile(FMBSDirectoryPatrikFullManagerBackupService[0], FMBSFilePatrikFullManagerBackupService[1], line , false) == false) {      
                msgDelayRefresh(formatStringLog("registration-database", "fail - error recording of file width the configutarion"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                return null;
            }
            msgDelayRefresh(formatStringLog("registration-database", "ok"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);

            msgDelayRefresh(formatStringLog("end-install", "configuration dataBase"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return dataBaseCreateIsOk;
        }

        public static string testConnectionsRDMS(string sever, string port, string userName, string password, string dataBase) {
            return WorkPostgreSQL.configurationIsOk(sever, port, userName, password, dataBase);
        }

        public static string unistallConfigurationDataBase(String sever, String port, String userName, String password, String dataBase, RichTextBox rtb, string erro = "") {
            String dataBaseCreateIsOk = "ok";

            msgDelayRefresh(formatStringLog(String.Concat("begin-unistall", (erro == "" ? String.Empty : "-" + erro)), "remove configuration dataBase "), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

            if (WorkFile.fileExist( FMBSFilePatrikFullManagerBackupService[0], FMBSFilePatrikFullManagerBackupService[1]) == false ){

                msgDelayRefresh(formatStringLog("delete-file", "file not exist, not is necessary to remove file"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

             }else if (WorkFile.deleteFile(FMBSFilePatrikFullManagerBackupService[0], FMBSFilePatrikFullManagerBackupService[1]) == false) {

                msgDelayRefresh(formatStringLog("begin-delete-file", "error to remover file of configuration"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
                


                return null;
            }

            msgDelayRefresh(formatStringLog(String.Concat("end-unistall", (erro == "" ? String.Empty : "-" + erro)), "remove configuration dataBase "), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

            return dataBaseCreateIsOk;

        }

        public static bool recordLog(RichTextBox rtb, string erro = "") {
            msgDelayRefresh(formatStringLog(String.Concat("begin-register-unistall", (erro == "" ? String.Empty : "-" + erro)), "file log"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

            WorkFile.writeFile(Util.psGETCURRENTDIRECTORY, files[0], rtb.Text, true);

            /*future routine case to ococcur erro in method   WorkFile.writeFile*/

            msgDelayRefresh(formatStringLog(String.Concat("logfile", "\"", files[0], "\""), "record in ", Util.psGETCURRENTDIRECTORY), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);

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


        public static int toInstallDirectory(String directory) {
            try {
                if (WorkDirectory.directoryExist(directory) == true) {
                    return 3;
                }
                return Convert.ToInt32(WorkDirectory.createDirectory(directory)); /* 1 create and 0 not create*/

            } catch (Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method",  "public static int toInstallDirectory(String directory)" } });
                listError.Add(new string[1, 2] { { "directory", directory } });         
                Util.psError(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return -1;
            }
        }


        public static int toInstallFiles(String directory, String file) {
            try {
                if (WorkFile.fileExist(directory, file) == true) {
                    return 3;
                }
                return Convert.ToInt32(WorkFile.createEmptyFile(directory, file)); /* 1 criou e 0 não criou*/
            } catch (Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", " public static int toInstallFiles(String directory, String file) " } });
                listError.Add(new string[1, 2] { { "directory", directory } });
                listError.Add(new string[1, 2] { { "file", file } });
                Util.psError(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return -1;
            }
        }

        public static bool createFiles(RichTextBox rtb) {
            /*begin routine of instalation of the files*/
            msgDelayRefresh(formatStringLog("begin-install", "files"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);

            /*for for to create the files*/
            for (int i = 0; i < UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService.Count; i++) {
                switch (toInstallFiles(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[i])) {
                    case 1:
                        msgDelayRefresh(formatStringLog("create", UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[i], "ok"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 3:
                        msgDelayRefresh(formatStringLog("create", UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[i], "fail - file already exist"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        break;
                    case 0:
                        msgDelayRefresh(formatStringLog("create", UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[i], "fail - erro in creation the file"), Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb);
                        return false;
                }
            }
            msgDelayRefresh(formatStringLog("end-install", "files"), Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            return true;
        }

    }


}






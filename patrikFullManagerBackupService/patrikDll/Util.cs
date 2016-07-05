using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace patrikDll {
    public struct StringDatetime {
        public string first;
        public DateTime second;
    };
    public class Util {
        /*begin commons features SOs*/
        public static readonly string psBAR_URL_SO = "\\";
        /*end commons features SOs*/

        /*begin features commons a systens*/
        public static readonly string psPROGRAMFILES = "C:" + psBAR_URL_SO + "Users" + psBAR_URL_SO + "patrik" + psBAR_URL_SO + "Desktop" + psBAR_URL_SO + "allProjectsVisualStudio" + psBAR_URL_SO + "BackupInCloud" + psBAR_URL_SO + "patrikFullManagerBackupService" + psBAR_URL_SO + "pseudoProgramFiles"; /* Environment.GetEnvironmentVariable("PROGRAMFILES");*/
        public static readonly string psGETCURRENTDIRECTORY = Directory.GetCurrentDirectory();

        public static readonly string psFORMATODEDATAEHORA = "dd-MM-yyyy HH-mm-ss"; /*brazilian format date and hour  in future create list or vector whith several country*/
        public static readonly int[] psErroWhatsToDo = new int[] { 0, 1, 3 };

        public static readonly List<string> psSeparator = new List<string> { "\u1F337", "\u27B3", "\u1F381", "\u1F3E9", "\u273F" };
        public static readonly List<string[,]> psSeparator2 = new List<string[,]> { new string[1, 4] { {    "\u1F337"   ,   " 🌷"   ,   " \n"   ,   "!\u2764Sissa127\u00F8\u07C9Almond Joy" } }, new string[1, 4] { {    "\u27B3"    ,   "➳" ,   ";" ,   "!\u2764Sissa127\u00F8\u07C9Aplets & Cotlets"   } } };/*in return method or error*/


        public static readonly List<string> psFiles = new List<string> { "psFailInstall.cma" };

        public static readonly int pstimeDelay = 1; /*delay time in milliseconds*/


        /*end das cacteristicas comuns a todos os sistemas*/


        /*begin caracteristicas comuns a patrikFullManagerBackupService*//*verificar possibilidade de delete*/
        public static readonly string FMBSSystemName = "patrikFullManagerBackupService";
        public static readonly string FMBSSystemNamePrefixo = "psPatrikFullManagerBackupService";
        public static readonly string FMBSImg = "picture";
        public static readonly string FMBSTemp = "temp";
        public static readonly List<string> FMBSDirectoryPatrikFullManagerBackupService = new List<string>{psPROGRAMFILES + psBAR_URL_SO + FMBSSystemNamePrefixo,
                                                                                              psPROGRAMFILES + psBAR_URL_SO + FMBSSystemNamePrefixo + psBAR_URL_SO + FMBSImg,
                                                                                              psPROGRAMFILES + psBAR_URL_SO + FMBSSystemNamePrefixo + psBAR_URL_SO + FMBSTemp,
        };

        public static readonly List<string> FMBSFilePatrikFullManagerBackupService = new List<string>{"psFILE_LOGpatrikFullManagerBackupService.cma",
                                                                                         "psCONFIGURATIONSGBDpatrikFullManagerBackupService.cma",
                                                                                         "psCargaInicialSGBDpatrikFullManagerBackupService.cma"

        };


        public static string psReturnTimeString() {
            return DateTime.Now.ToString(psFORMATODEDATAEHORA).ToString();
        }

        /*end caracteristicas comuns a patrikFullManagerBackupService*/












        /*metodo de gravação de log de psErro com possibilidade de envio de e-mail*/
        public static void psErro(int codeError, bool useSeparator, String fileLocal, String fileName, String method, String error = "") {
            if (codeError == psErroWhatsToDo[0]) {
                WorkFile.writeFile(false, fileLocal, fileName, "[" + Util.psReturnTimeString() + "]" + Util.psSeparator[2] + ((useSeparator == true) ? error.Replace("\n", Util.psSeparator[0]) : error), true);
            } else {
                if (codeError == psErroWhatsToDo[1]) {
                    //  send mail construir metodo ainda
                    Console.WriteLine("send e-mail");
                } else
                    // send mail construir metodo ainda
                    Console.WriteLine("send e-mail");
                Util.psErro(psErroWhatsToDo[0], useSeparator, fileLocal, fileName, method, error);

            }
        }


        public static readonly int ERRO_REGISTRY_LOG = 0;
        public static readonly int ERROR_SEND_EMAIL = 1;

        public static void error(int codeError, String method, String error = "") {
            if (Util.ERRO_REGISTRY_LOG == codeError) {
                // WorkFile.writeFile(true, Util.FILE_LOG, Util.FILE_LOCAL, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " ʘ " + Util.replaceString(error, "\n", "߷"));
            } else
                if (Util.ERROR_SEND_EMAIL == codeError) {
                //  send Mail
                Console.WriteLine("send e-mail");
            } else {
                Console.WriteLine("send e-mail");
            }

        }
        public static readonly string BAR_URL_SO = "\\";
        public static readonly string FILE_LOG = "patrikSystemBackupLog.cma";
        public static readonly string CONFIGURATION = "patrikSystemBackupConfiguration.cma";
        public static readonly string CONFIGURATION_FILE_BACKUP_EXISTS = "patrikSystemBackupExist.cma";
        public static readonly string FILE_LOCAL = Environment.GetEnvironmentVariable("PROGRAMFILES") + BAR_URL_SO + "patrikSystemBackup";
        public static readonly string FILE_LOCAL_TEMP = Environment.GetEnvironmentVariable("PROGRAMFILES") + BAR_URL_SO + "patrikSystemBackup" + BAR_URL_SO + "temp";
        //Environment.GetEnvironmentVariable("TEMP")

        public static readonly string FILE_DATABASE = Environment.GetEnvironmentVariable("PROGRAMFILES") + BAR_URL_SO + "patrikSystemBackup.cma";



        public static string replaceCaracter(string value, string exit, string enter) {
            return value.Replace(exit, enter);

        }

    }

}






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

        /*begin features commons a patriksystens*/
        public static readonly string psPROGRAMFILES = "C:" + Util.psBAR_URL_SO + "Users" + Util.psBAR_URL_SO + "patrik" + Util.psBAR_URL_SO + "Desktop" + Util.psBAR_URL_SO + "allProjectsVisualStudio" + Util.psBAR_URL_SO + "BackupInCloud" + Util.psBAR_URL_SO + "patrikFullManagerBackupService" + Util.psBAR_URL_SO + "pseudoProgramFiles"; /* Environment.GetEnvironmentVariable("PROGRAMFILES");*/
        public static readonly string psGETCURRENTDIRECTORY = Directory.GetCurrentDirectory();
        public static readonly string psFORMATDATATIME = "dd-MM-yyyy HH-mm-ss"; /*brazilian format date and hour  in future create list or vector whith several country*/



        /*in return method or error*/
        public static readonly List<string[,]> psSeparator2 = new List<string[,]> { new string[1, 4] { {    "\u1F337"   ,   " 🌷"   ,   " \n"   ,   "!\u2764Sissa127\u00F8\u07C9Almond Joy" } },
            new string[1, 4] { {    "\u27B3"    ,   "➳" ,   ";" ,   "!\u2764Sissa127\u00F8\u07C9Aplets & Cotlets"   } } };

        /*delay time in milliseconds*/
        public static readonly int pstimeDelay = 1;


    
       



        public static string psReturnTimeString() {
            return DateTime.Now.ToString(psFORMATDATATIME).ToString();
        }

        public static string purifyErrorMethod(string valueStringForPurification) {
            /*after implements nissa123*/
            return valueStringForPurification.Replace(psSeparator2[0][2, 0], psSeparator2[0][0, 0]).Replace(psSeparator2[1][2, 0], psSeparator2[1][0, 0]);
        }

     




        public static void psError(String local , String name ,  List<string[,]> listError ,  Exception error = null ) {

            MessageBox.Show("Erro");
            int j = 0;
            String errorString = "";
            /*other form very elegant https://msdn.microsoft.com/en-us/library/system.exception.data(v=vs.110).aspx */
            foreach (string[,] i in listError) {
                errorString += String.Concat(i[j, 0],"\t = \t" ,i[j, 0], "\n");
                j++;
            }
            if (error != null) {
                errorString += String.Concat("error.GetType()", error.GetType(), "\n");
                errorString += String.Concat("error.HelpLink", error.HelpLink, "\n");
                errorString += String.Concat("error.HResult", error.HResult, "\n");
                errorString += String.Concat("error.InnerException", error.InnerException, "\n");
                errorString += String.Concat("error.Message", error.Message, "\n");
                errorString += String.Concat("error.Source", error.StackTrace, "\n");
                errorString += String.Concat("error.TargetSite", error.TargetSite, "\n");
                errorString += String.Concat("error.ToString()", error.ToString(), "\n");
            }
            errorString  = purifyErrorMethod(errorString);
            WorkFile.writeFile(local, name, errorString);
            /*after implements routine send mail*/
            MessageBox.Show("send e-mail to create this routine");     
                        

            }



        /*end features commons a patriksystens*/


        /*after to remove is need for to compiler a class inteligence*/
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






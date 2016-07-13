using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patrikSystemBackupDll {
    public struct StringDatetime {
        public string first;
        public DateTime second;
    };
      
    public class Util {

        public static readonly string BAR_URL_SO = "\\";
        public static readonly string FILE_LOG = "patrikSystemBackupLog.cma";
        public static readonly string CONFIGURATION = "patrikSystemBackupConfiguration.cma";
        public static readonly string CONFIGURATION_FILE_BACKUP_EXISTS = "patrikSystemBackupExist.cma";
        public static readonly string FILE_LOCAL = Environment.GetEnvironmentVariable("PROGRAMFILES") + BAR_URL_SO + "patrikSystemBackup";
        public static readonly string FILE_LOCAL_TEMP = Environment.GetEnvironmentVariable("PROGRAMFILES") + BAR_URL_SO + "patrikSystemBackup" + BAR_URL_SO + "temp"; 
        //Environment.GetEnvironmentVariable("TEMP")

        public static readonly string FILE_DATABASE = Environment.GetEnvironmentVariable("PROGRAMFILES") + BAR_URL_SO + "patrikSystemBackup.cma";       

        public static readonly int ERRO_REGISTRY_LOG = 0;
        public static readonly  int ERROR_SEND_EMAIL = 1;

        public static string replaceCaracter (string value, string exit, string enter){
             return value.Replace(exit, enter );          

        }
        public static void error(int codeError, String method, String error="") {
            if (Util.ERRO_REGISTRY_LOG == codeError) {
                WorkFile.writeFile(true, Util.FILE_LOG, Util.FILE_LOCAL, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " ʘ " + Util.replaceCaracter(error, "\n", "߷"));
            } 
            else
                if (Util.ERROR_SEND_EMAIL== codeError) {
                     //  send Mail
                        Console.WriteLine("send e-mail");
                }else{
                    Console.WriteLine("send e-mail");
                } 
             
            }
            
            
        }
      
    }


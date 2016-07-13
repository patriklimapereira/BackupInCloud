using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace patrikSystemBackupDll {
    public class WorkFile {
        public static bool writeFile(bool flag, String fileName, String local, String valueString) {
            try {
                StreamWriter file;
                file = new StreamWriter(Path.Combine(Util.FILE_LOCAL, Util.FILE_LOG), true);
                file.WriteLine(valueString);
                file.Flush();
                file.Close();
                file.Dispose();
            }
            catch (Exception e) {
                String method = "public static bool writeFile(bool flag, String fileName, String local, String valueString)" +
                  "flag = " + flag +
                 " fileName =" + fileName +
                  "local =" + local +
                   "valueString =" + valueString;
                Util.error(Util.ERRO_REGISTRY_LOG, method, e.ToString());
                return false;
            }
            return true;
        }


      public static string[] readFileLines(String local,String fileName ) {
               try {
                    return System.IO.File.ReadAllLines(Path.Combine(local, fileName));
                }
                catch (Exception e) {
                    return null; // colocar tratamento padrão de exceção
                }
           


        }




        private static bool fileExist(String fileName, String local) {
            return File.Exists(Path.Combine(local, fileName));
        }


    }
}

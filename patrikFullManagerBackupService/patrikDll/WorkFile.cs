using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace patrikDll {
    public class WorkFile {
        public static bool writeFile( String local,String name, String valueString,  bool addAndNoReplaceTheFile = true) {
            try {
                StreamWriter file;
                file = new StreamWriter(Path.Combine(local, name), addAndNoReplaceTheFile);              
                file.WriteLine(valueString);         
                file.Flush();
                file.Close();
                file.Dispose();
            }
            catch (Exception error){
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static bool writeFile(bool flag, String name, String local, String valueString)" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "name", name } });
                listError.Add(new string[1, 2] { { "valueString", valueString } });
                listError.Add(new string[1, 2] { { "addAndNoReplaceTheFile",  addAndNoReplaceTheFile.ToString() } });
                Util.psError(local, name, listError, error);

         

                return false;
            }
            return true;
        }


      public static string[] readFileLines(String local,String fileName ) {
               try {
                    return File.ReadAllLines(Path.Combine(local, fileName));
                }
                catch (Exception error) {
                   String method = "public static string[] readFileLines(String local,String name ) {" +
                   Util.psSeparator[3] + "local=" + local +
                   Util.psSeparator[3] + "name =" + fileName;
                   Util.psErro(Util.psErroWhatsToDo[0], true,Util.FMBSDirectoryPatrikFullManagerBackupService[0], Util.FMBSFilePatrikFullManagerBackupService[0], method, error.ToString());
                   return null;
                }
         }                

       public static bool fileExist( String local,String fileName) {
            return File.Exists(Path.Combine(local, fileName));
        }

       public static bool createEmptyFile (String local,String fileName){
           try {
               File.Create(Path.Combine(local, fileName)).Close();                        
               return true;
           }catch (Exception error){
               String method = "public static bool createEmptyFile (String local,String name){" +
               Util.psSeparator[3] + "local=" + local +
               Util.psSeparator[3] + "name =" + fileName;
               Util.psErro(Util.psErroWhatsToDo[0],true ,Util.FMBSDirectoryPatrikFullManagerBackupService[0], Util.FMBSFilePatrikFullManagerBackupService[0], method, error.Message + Util.psSeparator[2] + error.Source + Util.psSeparator[2] + error.StackTrace);
               return false;
           }
              
       }


    }
}

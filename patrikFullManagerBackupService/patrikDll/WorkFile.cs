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
                Util.psError(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[0], listError, error);

         

                return false;
            }
            return true;
        }


      public static string[] readFileLines(String local,String name ) {
               try {
                    return File.ReadAllLines(Path.Combine(local, name));
                }
                catch (Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static string[] readFileLines(String local,String name )" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "name", name } });                
                Util.psError(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return null;
                }
         }                

       public static bool fileExist( String local,String name) {
            return File.Exists(Path.Combine(local, name));
        }

       public static bool createEmptyFile (String local,String name){
           try {
               File.Create(Path.Combine(local, name)).Close();                        
               return true;
           }catch (Exception error){

                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static bool createEmptyFile (String local,String name)" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "name", name } });
                Util.psError(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return false;
           }
              
       }


    }
}

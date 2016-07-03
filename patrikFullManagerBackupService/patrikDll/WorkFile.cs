using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace patrikDll {
    public class WorkFile {
        public static bool writeFile(bool quebraDeLinhaPadrao, String local,String fileName, String valueString,  bool acrescentarENaoSubstituirOArquivo = true) {
            try {
                StreamWriter file;
                file = new StreamWriter(Path.Combine(local, fileName), acrescentarENaoSubstituirOArquivo);
                if(quebraDeLinhaPadrao == true) {
                    file.WriteLine(valueString );
                } else {
                    file.Write(valueString + Util.psSeparator[3]);
                }
              
                file.Flush();
                file.Close();
                file.Dispose();
            }
            catch (Exception error){
                String method = "public static bool writeFile(bool flag, String fileName, String local, String valueString)" +
                Util.psSeparator[3] + "fileName =" + fileName +
                Util.psSeparator[3] + "local =" + local +
                Util.psSeparator[3] + "valueString =" + valueString +
                Util.psSeparator[3] + "acrescentarENaoSubstituirOArquivo =" + acrescentarENaoSubstituirOArquivo;
                Util.psErro(Util.psErroWhatsToDo[0],true ,Util.FMBSDirectoryPatrikFullManagerBackupService[0], Util.FMBSFilePatrikFullManagerBackupService[0], method, error.ToString());
       
                return false;
            }
            return true;
        }


      public static string[] readFileLines(String local,String fileName ) {
               try {
                    return File.ReadAllLines(Path.Combine(local, fileName));
                }
                catch (Exception error) {
                   String method = "public static string[] readFileLines(String local,String fileName ) {" +
                   Util.psSeparator[3] + "local=" + local +
                   Util.psSeparator[3] + "fileName =" + fileName;
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
               String method = "public static bool createEmptyFile (String local,String fileName){" +
               Util.psSeparator[3] + "local=" + local +
               Util.psSeparator[3] + "fileName =" + fileName;
               Util.psErro(Util.psErroWhatsToDo[0],true ,Util.FMBSDirectoryPatrikFullManagerBackupService[0], Util.FMBSFilePatrikFullManagerBackupService[0], method, error.Message + Util.psSeparator[2] + error.Source + Util.psSeparator[2] + error.StackTrace);
               return false;
           }
              
       }


    }
}

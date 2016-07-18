using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace patrikDll {
    public class WorkerFile {
        public static bool writeFile(String local, String name, String valueString, bool addAndNoReplaceTheFile = true) {
            try {
                StreamWriter file;
                file = new StreamWriter(Path.Combine(local, name), addAndNoReplaceTheFile);
                file.WriteLine(valueString);
                file.Flush();
                file.Close();
                file.Dispose();
            } catch(Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static bool writeFile(bool flag, String text, String local, String valueString)" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "text", name } });
                listError.Add(new string[1, 2] { { "valueString", valueString } });
                listError.Add(new string[1, 2] { { "addAndNoReplaceTheFile", addAndNoReplaceTheFile.ToString() } });
                Util.psError(UtilPatrikInstallGUI.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikInstallGUI.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return false;
            }
            return true;
        }


        public static string[] readFileLines(String local, String name) {
            try {
                return File.ReadAllLines(Path.Combine(local, name));
            } catch(Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static string[] readFileLines(String local,String text )" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "text", name } });
                Util.psError(UtilPatrikInstallGUI.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikInstallGUI.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return null;
            }
        }

        /*not implements routine of registre erro*/
        public static byte[] readFileBytes(String local, String name) {
            try {
                return File.ReadAllBytes(Path.Combine(local, name));
            } catch(Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static string[] readFileLines(String local,String text )" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "text", name } });
                Util.psError(UtilPatrikInstallGUI.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikInstallGUI.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return null;
            }
        }

        /*not implements routine of registre erro*/
        public static Stream readFileStream(String local, String name) {
            try {
                return new MemoryStream(readFileBytes(local, name));
            } catch(Exception error) {
                return null;
            }

        }
        public static bool fileExist(String local, String name) {
            return File.Exists(Path.Combine(local, name));
        }

        public static bool createEmptyFile(String local, String name) {
            try {
                File.Create(Path.Combine(local, name)).Close();
                return true;
            } catch(Exception error) {

                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static bool createEmptyFile (String local,String text)" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "text", name } });
                Util.psError(UtilPatrikInstallGUI.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikInstallGUI.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return false;
            }

        }


        public static bool deleteFile(String local, String name) {
            try {
                File.Delete(Path.Combine(local, name));
                return true;
            } catch(Exception error) {

                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static bool deleteFile(String local, String text)" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { { "text", name } });
                Util.psError(UtilPatrikInstallGUI.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikInstallGUI.FMBSFilePatrikFullManagerBackupService[0], listError, error);
                return false;
            }

        }

        public static bool copySplitFile(String localOrigin, String nameOrigin, String localDestiny, String nameDestiny) {
            try {

                return true;

            } catch(Exception error) {
                return false;
            }


        }
    }
}

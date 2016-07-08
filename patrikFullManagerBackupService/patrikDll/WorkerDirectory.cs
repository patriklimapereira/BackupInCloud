using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace patrikDll {
    public class WorkerDirectory {
        public static bool directoryExist(String local) {
            return Directory.Exists(local);
        }
        public static bool createDirectory(String local) {
            try {
                Directory.CreateDirectory(local);
                return true;
            }
            catch (Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static bool directoryExist(String local)" } });
                listError.Add(new string[1, 2] { { "local", local} });
              
                Util.psError(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[0], listError, error);
               
                return false;
            }
        }
        public static bool deleteDirectory(String local, bool toActiveRecursion = true) {
            try {
                Directory.Delete(local, toActiveRecursion);
                return true;
            }
            catch (Exception error) {
                List<string[,]> listError = new List<string[,]> { };
                listError.Add(new string[1, 2] { { "method", "public static bool directoryExist(String local)" } });
                listError.Add(new string[1, 2] { { "local", local } });
                listError.Add(new string[1, 2] { {"toActiveRecursion", toActiveRecursion.ToString()} });

                Util.psError(UtilPatrikFullManagerBackupService.FMBSDirectoryPatrikFullManagerBackupService[0], UtilPatrikFullManagerBackupService.FMBSFilePatrikFullManagerBackupService[0], listError, error);

                return false;


            }
        }
    }
}
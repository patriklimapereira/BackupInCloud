using System;
using System.IO;
using System.Diagnostics;

namespace patrikDll {
    public class WorkDirectory {
        public static bool directoryExist(String local) {
            return Directory.Exists(local);
        }
        public static bool createDirectory(String local) {
            try {
                Directory.CreateDirectory(local);
                return true;
            }
            catch (Exception error) {
                String method = "private static bool createDirectory(String local){" +
                Util.psSeparator[3] + "local=" + local;
                Util.psErro(Util.psErroWhatsToDo[0],true, Util.FMBSDirectoryPatrikFullManagerBackupService[0], Util.FMBSFilePatrikFullManagerBackupService[0], method, error.Message + Util.psSeparator[2] + error.Source + Util.psSeparator[2] + error.StackTrace);
                return false;
            }
        }
        public static bool deleteDirectory(String local, bool toActiveRecursion = true) {
            try {
                Directory.Delete(local, toActiveRecursion);
                return true;
            }
            catch (Exception error) {
                String method = "private static bool createDirectory(String local){" +
                Util.psSeparator[3] + "local=" + local +
                Util.psSeparator[3] + "toActiveRecursion =" + toActiveRecursion;
                Util.psErro(Util.psErroWhatsToDo[0], true, Util.FMBSDirectoryPatrikFullManagerBackupService[0], Util.FMBSFilePatrikFullManagerBackupService[0], method, error.Message + Util.psSeparator[2] + error.Source + Util.psSeparator[2] + error.StackTrace);
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace patrikSystemBackupDll {
     public  class WorkDirectory {

        public static bool directoryExist(String local) {

            return Directory.Exists(local);

        }

           public static bool createDirectory(String local) {
            try {
                Directory.CreateDirectory(local);
                return true;
            }
            catch (Exception e) {
                String method = "private static bool createDirectory(String local)";

                Util.error(Util.ERRO_REGISTRY_LOG,method , e.ToString());
               
                
                return false;
            }
        }
    }



}


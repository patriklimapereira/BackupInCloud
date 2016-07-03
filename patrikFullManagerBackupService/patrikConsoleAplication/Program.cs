using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patrikDll;
using PatrikSystemPersistence;
using System.IO;
using System.Diagnostics;

namespace patrikConsoleAplication {
    class Program {
        public static void Main(string[] args) {

           


            Console.ReadLine();
          /*  DateTime timeAtual = DateTime.Now;
            string[] lines = WorkFile.readFileLines(Util.FILE_LOCAL, Util.CONFIGURATION_FILE_BACKUP_EXISTS);
            foreach (string line in lines) {
                String[] vectorData = line.Split(';');

                if (vectorData[2] == "1") {
                    vectorData[0] += "\\" + DateTime.Now.ToString("yyyy", CultureInfo.InvariantCulture);
                    if (vectorData[3] == "1") {
                        vectorData[0] += "\\" + DateTime.Now.Year + "." + DateTime.Now.ToString("MM", CultureInfo.InvariantCulture);
                    }
                }
                /*zip errado*/

               /* if (WorkDirectory.directoryExist(vectorData[0])) {
                    List<StringDatetime> StringDatetimeList = Intelligence.getFileNameDateCreate(vectorData[0], 1, false, 0, vectorData[4]);
                    TimeSpan ts = timeAtual - StringDatetimeList[0].second;
                    if (ts.Days < 1) { /**futuramente usarui escolhara object time de verificacao */

                 /*       Console.WriteLine("Backup feito");
                      
                    } else {
                        Console.WriteLine("nao feito");
                    }
                } else {
                    Console.WriteLine("ola");
                }
            }*/


            
          /*  string s, d;
            string local = "\\\\srv-erp\\EL\\Backup\\Almox_patri";
            List<StringDatetime> listStringDatetime = Intelligence.getFileNameDateCreate(local, 15, false, (int)Intelligence.searchDateFile.GetCreationTime, "*.rar");
            if (listStringDatetime != null && listStringDatetime.Count != 0) {
                foreach (StringDatetime unitStringDatetime in listStringDatetime) {
                    s = Path.Combine(local, unitStringDatetime.first);
                    d = Path.Combine("C:\\Users\\patrik\\Desktop\\destino", unitStringDatetime.first);
                    if (File.Exists(d) == false) {
                        File.Copy(s, d);
                    } else {
                        switch (Intelligence.FileEquals(s, d)) {
                            case 0: File.Copy(s, d, true);
                                break;
                            case 2:
                                File.Copy(s, Intelligence.copyDuplicateNewName(d));
                                break;
                        }
                    }

                }
            } else {
                //criar tratamento de psErro  
            }*/


        }
    }
}

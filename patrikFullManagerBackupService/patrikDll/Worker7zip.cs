using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static patrikDll.Util;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using System.Text;

namespace patrikDll {

    


    public static class Worker7zip {

        public const int IDS_METHOD_STORE = 0;
        public const int IDS_METHOD_FASTEST = 1;
        public const int IDS_METHOD_FAST = 3;
        public const int IDS_METHOD_NORMAL = 5;
        public const int IDS_METHOD_MAXIMUM = 7;
        public const int IDS_METHOD_ULTRA = 9;
        const  int AMOUNT_OF_LINES = 1;
        const int AMOUNT_OF_COLUNMS = 2;
        public static readonly List<IntString> error7zip = new List<IntString>() {
            new IntString(){number = 0, text = "No error" },
            new IntString(){number = 1, text = "Warning (Non fatal error(s)). For example, one or more files were locked by some other application, so they were not compressed" },
            new IntString(){number = 2, text = "Fatal error" },
            new IntString(){number = 7, text = "Command line error" },
            new IntString(){number = 8, text = "Not enough memory for operation" },
            new IntString(){number = 255, text = "User stopped the process" }
        };

        public const string easteregges = "eu gostava de você... queria algo mais serios com você... infelizmente ao saber que gostava de você... sua atitude foi me desprezar!!!!!! será por isso que você esta sozinha!!!!";

        public static Dictionary<string, string> typeFormatCompress= new Dictionary<string, string>() { { "7zip", "7z"}, { "zip", "zip" }, };
       
                
        public static string generateValuePartsForMultiplesVolumes  ( string StrTxt){
            try {
                if (String.Empty == StrTxt) {
                    return null;
                }
                var txt = StrTxt;
                String space = "k ";
                String parameter = "-v";
                String legthFilesCompact = "";
                int multipleLengthTamanho = 10;

                foreach (var decimalValue in txt) {

                    legthFilesCompact += parameter + ((int)decimalValue) * multipleLengthTamanho + space;
                }
                                return legthFilesCompact;
                Debug.WriteLine( legthFilesCompact);

            }catch ( Exception error) {
                return null;
            }
         }
        public static int add(String origin, String destiny, String nameOriginal, String nameCompress, String formatCompress = "7z", int levelCompress = 9 /*ultra*/, bool multipleFiles = false, string leghtVolumesAtK = "1440k") {
           String space = " ";
            String operation = "a";       
            String o =    Path.Combine(origin, nameOriginal);
            String d =  Path.Combine(destiny, nameCompress);
            String execute = operation + space + String.Concat("-t", formatCompress) + space + d + space + o + space + String.Concat("-mx", levelCompress) + space + "-y" + space + generateValuePartsForMultiplesVolumes(easteregges); ;
            Debug.WriteLine(execute);
            Debug.WriteLine("7za.exe " +execute);
            /*routine of error*/
            return executeStringIn7zip(execute); 
        }

        public static int test (String destiny,  String nameCompress, String mask = "*", String recursive = "r" ) {
            String operation = "t";
            String space = " ";
            String d = Path.Combine(destiny, nameCompress);
            String execute = operation + space + d + space + mask + space + recursive;
            return executeStringIn7zip(execute);

        }

        private static int executeStringIn7zip(String execute) {
            int  code =  -1;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "7zip\\7za.exe";
           psi.Arguments = execute;
            psi.WindowStyle = ProcessWindowStyle.Normal;

            //C: \Users\patrik\Desktop\allProjectsVisualStudio\BackupInCloud\patrikFullManagerBackupService\patrikService\bin\Debug\7zip
              MessageBox.Show(Util.psGETCURRENTDIRECTORY);


             Process processforExecuted = Process.Start(psi);


            processforExecuted.WaitForExit();

            MessageBox.Show(processforExecuted.ExitCode.ToString());
            code =  processforExecuted.ExitCode;
            processforExecuted.Dispose();
            processforExecuted = null;
            psi = null;
            return code;
        }
    }
}

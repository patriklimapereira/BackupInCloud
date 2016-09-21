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
        const int AMOUNT_OF_LINES = 1;
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

        const long flavia = 1021089711810597;

        public static Dictionary<string, string> typeFormatCompress = new Dictionary<string, string>() { { "7zip", "7z" }, { "zip", "zip" } };


        public static string generateValuePartsForMultiplesVolumes(string value) {
            try {
                if (String.Empty == value) {
                    return null;
                }
                String spaceK = "k";
                String space = " ";
                String parameter = "-v";
                String legthFilesCompact = "";
                int multipleLengthTamanho = 10;

                foreach (var decimalValue in value) {
                    legthFilesCompact += parameter + ((int)decimalValue) * multipleLengthTamanho + spaceK + space;
                }
                return legthFilesCompact;


            } catch (Exception error) {
                /*after implementation*/
                MessageBox.Show("/*after implementation*/");
                return null;
            }
        }
        public static long add(String origin, String destiny, String nameOriginal, String nameCompress, string formatCompress, long leghtVolumesAtK = 0, int levelCompress = 9) {
              try {
                String space = " ", operation = "a", spaceK = "k ", parameter = "-v", strMultipleFiles = "", execute;
                String o = "\"" + Path.Combine(origin, nameOriginal) + "\"";
                String d = "\"" + Path.Combine(destiny, nameCompress) + String.Concat(".", typeFormatCompress[formatCompress]) + "\"";

                switch (leghtVolumesAtK) {
                    case 0:
                        strMultipleFiles = "";
                        break;
                    case flavia:
                        strMultipleFiles = generateValuePartsForMultiplesVolumes(easteregges);
                        break;
                    default:
                        strMultipleFiles = parameter + leghtVolumesAtK.ToString() + spaceK;
                        break;

                }
                execute = operation + space + String.Concat("-t", typeFormatCompress[formatCompress]) + space + d + space + o + space + String.Concat("-mx", levelCompress) + space + "-y" + space + strMultipleFiles;
                Debug.WriteLine("7za.exe " + execute);
                /*routine of error*/
                return executeStringIn7zip(execute);
            } catch (Exception erro) {
                MessageBox.Show("/*after implementation*/");
                return Util.psMaxValueLong;
            }
        }

        public static long test(String destiny, String nameCompress, string extension, String mask = "*", String recursive = "r") {
            try {
                String operation = "t", space = " ", d, execute;

                if (WorkerFile.fileExist(destiny, String.Concat(nameCompress, ".", "001"))) {
                    d = "\"" + Path.Combine(destiny, String.Concat(nameCompress, ".", "001")) + "\"";
                } else {
                    d = "\"" + Path.Combine(destiny, nameCompress + "." + typeFormatCompress[extension]) + "\"";
                }
                execute = operation + space + d + space + mask + space + recursive;
                Debug.WriteLine("7za.exe " + execute);
                return executeStringIn7zip(execute);
            } catch (Exception error) {
                MessageBox.Show("Error");
                return Util.psMaxValueLong;
            }
        }

        private static long executeStringIn7zip(String execute) {
            try {
                ProcessStartInfo psi = new ProcessStartInfo();
                Process processforExecuted;
                psi.FileName = "7zip\\7za.exe";
                psi.Arguments = execute;
                psi.WindowStyle = ProcessWindowStyle.Minimized;
                processforExecuted = Process.Start(psi);
                processforExecuted.WaitForExit();
                if (processforExecuted.ExitCode != 0) {
                    MessageBox.Show("----------------------erro de code\n" + processforExecuted.ExitCode.ToString());
                }
                return processforExecuted.ExitCode;                
            } catch (Exception error) {
                MessageBox.Show("Error");
                return Util.psMaxValueLong;
            }
        }
    }
}

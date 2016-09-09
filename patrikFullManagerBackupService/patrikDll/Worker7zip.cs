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

        const long  flavia =   1021089711810597;

        public static Dictionary<string, string> typeFormatCompress= new Dictionary<string, string>() { { "7zip", "7z"}, { "zip", "zip" } };
       
                
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
                

            }catch ( Exception error) {
                /*after implementation*/
                return null;
            }
         }
        public static long add(String origin, String destiny, String nameOriginal, String nameCompress,  string  formatCompress ,  long leghtVolumesAtK = 0, int levelCompress = 9 ) {

          /*after implements validation de formatCompress*/
           String space = " ";
           String operation = "a";   
           String spaceK = "k ";
           String parameter = "-v";           
           String o =  "\""+  Path.Combine(origin, nameOriginal)+ "\"";
           String d = "\""+ Path.Combine(destiny, nameCompress)+ String.Concat(".",typeFormatCompress["7zip"] )+"\"";
           String strMultipleFiles;
                           
            switch (leghtVolumesAtK) {
                case  0:
                    strMultipleFiles  = "";
                    break;
                case flavia:  
                      strMultipleFiles  = generateValuePartsForMultiplesVolumes(easteregges);
                    break;                 
                default:
                     strMultipleFiles =  parameter+leghtVolumesAtK.ToString()+spaceK;
                    break;

            }

          

            String execute = operation + space + String.Concat("-t", typeFormatCompress["7zip"]) + space + d + space + o + space + String.Concat("-mx", levelCompress) + space + "-y" + space +strMultipleFiles;
            Debug.WriteLine(execute);
            Debug.WriteLine("7za.exe " +execute);
            /*routine of error*/
            return executeStringIn7zip(execute); 
        }

        public static int test (String destiny,  String nameCompress, String mask = "*", String recursive = "r" ) {
            String operation = "t";
            String space = " ";
           String d = "";
            if( WorkerFile.fileExist(destiny, String.Concat(nameCompress, ".", "001"))) {
                 d = "\""+ Path.Combine(destiny, String.Concat(nameCompress, ".", "001"))+ "\"";
            }else {
                 d = "\""+ Path.Combine(destiny, nameCompress+ ".7z")+ "\"";
            }
        
           
            String execute = operation + space + d + space + mask + space + recursive;

            Debug.WriteLine("7za.exe " + execute);

            
            return executeStringIn7zip(execute);

        }

        private static int executeStringIn7zip(String execute) {
            int  code =  -1;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "7zip\\7za.exe";
            psi.Arguments = execute;
            psi.WindowStyle = ProcessWindowStyle.Normal;

            //C: \Users\patrik\Desktop\allProjectsVisualStudio\BackupInCloud\patrikFullManagerBackupService\patrikService\bin\Debug\7zip
      //        MessageBox.Show(Util.psGETCURRENTDIRECTORY);


             Process processforExecuted = Process.Start(psi);


            processforExecuted.WaitForExit();

           // MessageBox.Show(processforExecuted.ExitCode.ToString());

            if(processforExecuted.ExitCode != 0 ) {
                 MessageBox.Show("erro de codde\n" +processforExecuted.ExitCode.ToString() );
            } 

            Debug.WriteLine("\n\n\n\n\n\n\n\n\n = processforExecuted.ExitCode.ToString()");

            code =  processforExecuted.ExitCode;
            processforExecuted.Dispose();
            processforExecuted = null;
            psi = null;
            return code;
        }
    }
}

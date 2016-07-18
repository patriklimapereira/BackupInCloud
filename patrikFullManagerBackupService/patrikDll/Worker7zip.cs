using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static patrikDll.Util;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace patrikDll {

    


    public static class Worker7zip {

        public const  int IDS_METHOD_STORE = 0;
        public  const int IDS_METHOD_FASTEST = 1;
        public  const int IDS_METHOD_FAST = 3;
        public  const int IDS_METHOD_NORMAL = 5;
        public  const int IDS_METHOD_MAXIMUM = 7;
        public  const int IDS_METHOD_ULTRA = 9;
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

        public  static  readonly string zip = "zip";
        public static readonly string sevenZip = "7z";
                
        public static int add(String origin, String destiny, String nameOriginal, String nameCompress, bool testIntegrityOfArchive = true, String formatCompress = "7zip", int  levelCompress = 9 /*ultra*/, bool multipleFiles = false, int maxLeghtSinglesFiles = 1) {
           String operation = "a";
           String o =    Path.Combine(origin, nameOriginal);
           String d =  Path.Combine(destiny, nameCompress); 7z t archive.zip *.doc
           String execute = operation + " " + d + " " + o


          //testIntegrityOfArchive == true ? operation = "t" : ;



            //  MessageBox.Show(execute);
            Debug.WriteLine(execute);
            //String.Concat(sevenZip, operation,  )

            return executeStringIn7zip(execute); 
        }

        private static int executeStringIn7zip(String execute) {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "libs\\7za.exe";
                          psi.Arguments = execute;
            psi.WindowStyle = ProcessWindowStyle.Normal;


            MessageBox.Show(Util.psGETCURRENTDIRECTORY);
          

            Process processforExecuted = Process.Start(psi);


            processforExecuted.WaitForExit();

            MessageBox.Show(processforExecuted.ExitCode.ToString());
            return processforExecuted.ExitCode;
        }
    }
}

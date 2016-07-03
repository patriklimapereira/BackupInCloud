using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patrikDll;
using System.Windows.Forms;

namespace patrikInstallGUI
{
    class FunctionForInstalation
    {
        private static readonly int showTextHeaderInDisplay = 2;
        private static readonly int showInstructionsExecutedInDisplay = 2;

        public string formatStringLog(string msg)
        {
            return "[" + Util.psRetornaTimeString() + "]" + ": " + msg;
        }
        public static bool createDiretorios(RichTextBox rtb)
        {
            Util.psMsgAtrasoRefresh("begin-install->directory", Util.pstimeDelay * showTextHeaderInDisplay, rtb);
            /*for for to create directories*/
            for (int i = 0; i < Util.FMBSDirectoryPatrikFullManagerBackupService.Count; i++) {
                Util.psMsgAtrasoRefresh("create " + Util.FMBSDirectoryPatrikFullManagerBackupService[i] + "-> ", Util.pstimeDelay * showInstructionsExecutedInDisplay, rtb, String.Empty);
                switch (Util.FMBSInstalarDiretorios(Util.FMBSDirectoryPatrikFullManagerBackupService[i])) {
                    case 1:
                        Util.psMsgAtrasoRefresh("ok", 400, rtb);
                        break;
                    case 3:
                        Util.psMsgAtrasoRefresh("fail - directory already exist", 400, rtb);
                        break;
                    case 0:
                        Util.psMsgAtrasoRefresh("fail - Erro na criação do directory", 700, rtb);
                        return false;
                }
            }
            return true;
        }



    }
}

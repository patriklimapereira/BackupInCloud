using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using patrikDll;
namespace patrikService {

    public partial class TestSubRoutineService : Form {
        public TestSubRoutineService() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
          
            DateTime timeAtual = DateTime.Now;
            String[] vectorData =  {"\\\\srv-app-01\\EL\\BACKUP\\PROTOCOLO"/* "C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\origin"*/,
                "C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\destiny",
            "",
            "",
            "rar"};

            String x = "";
            if(WorkerDirectory.directoryExist(vectorData[0])) {
                List<StringDateTime> StringDatetimeList = Intelligence.getFileNameDateCreate(vectorData[0], 30, false, 0, vectorData[4]);
            
           
                TimeSpan ts = timeAtual - StringDatetimeList[0].dateAndHour;
                if(ts.Days < 1) { /**futuramente usarui escolhara object time de verificacao*/

                       Console.WriteLine("Backup feito");
                     
                    } else {
                        Console.WriteLine("nao feito");
                    }
                } else {
                    Console.WriteLine("ola");
                }

        }
    }
}

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
using System.Diagnostics;
using Microsoft.OneDrive.Sdk;
using System.IO;
using static patrikDll.Worker7zip;
using static patrikDll.Util;


using System.IO.Compression;

namespace patrikService {

    public partial class TestSubRoutineService : Form {
        private const string msaClientId = "3e776a02-19a4-481c-92f0-61832a8ba791";
        private const string msaReturnUrl = "https://login.live.com/oauth20_desktop.srf";
        /*temp*/
        private string folderRootIndDriverForPatrikFullManagerBackupService = "patrikFullManagerBackupService";

        private static readonly string[] scopes = { "onedrive.readwrite", "wl.offline_access", "wl.signin" };


        private IOneDriveClient oneDriveClient { get; set; }
        public TestSubRoutineService() {
            InitializeComponent();
        }



        private async void btnConnect_Click(object sender, EventArgs e) {
            try {
                this.oneDriveClient = await WorkerOnedrive.signIn(msaClientId, msaReturnUrl, scopes);
            } catch(Exception exception) {
                MessageBox.Show(exception.ToString());
            }
        }

        private void btnRoutineBackup_Click(object sender, EventArgs e) {
            DateTime timeAtual = DateTime.Now;
            String[] vectorData =  {"C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\origin",
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

        private void button1_Click(object sender, EventArgs e) {


        }
        private async void btnConnectOnedriver_Click(object sender, EventArgs e) {
            await connectOnedriver();
        }
        private async Task<bool> connectOnedriver() {
            try {
                this.oneDriveClient = await WorkerOnedrive.signIn(msaClientId, msaReturnUrl, scopes);
                return true;
            } catch(Exception exception) {
                MessageBox.Show(exception.ToString());
                return false;
            }
        }

        private void btnRoutine_Click(object sender, EventArgs e) {
            DateTime timeAtual = DateTime.Now;
            String[] vectorData =  {"C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\origin",
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

        private void button1_Click_1(object sender, EventArgs e) {
            String a = "C:\\a\\BlueStacks2_native.exe";
            String b = "C:\\b\\sss.zip";
            // System.IO.File.Copy(a, b);
            ZipFile.CreateFromDirectory(a, b);

        }

        private void btnCompress_Click(object sender, EventArgs e) {
           String origin = "C:\\Users\\patrik\\Desktop";
           String destiny = "C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\destiny";
            String nameOriginal = "192.168.11.4_04_20160613_120000.avi";
             String nameCompress = "192.168.11.4_04_20160613_120000.7z";
            //  bool testIntegrityOfArchive
            //  ue, String formatCompress = "7zip", int levelCompress = 9 /*ultra*/, bool multipleFiles = false, int maxLeghtSinglesFiles = 1) {
            add(origin, destiny, nameOriginal, nameCompress);


             
        }
    }
}
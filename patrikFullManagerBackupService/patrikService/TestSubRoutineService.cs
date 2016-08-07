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
using static patrikDll.WorkerFile;
using static patrikDll.WorkPostgreSQL;
using NpgsqlTypes;
using System.IO;




using System.IO.Compression;
using Npgsql;

namespace patrikService {

    public partial class TestSubRoutineService : Form {
       private  String server = "172.16.250.130";
       private  String port ="5432";
       private   String user =   "postgres";
       private   String password = "root";
       private   String dataBase = "backupInCloudWebUI_development";
       
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
            /*String[] vectorData =  {"C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\origin",
                "C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\destiny",
            "",
            "",
            "rar"};

            String x = "";
            if(WorkerDirectory.directoryExist(vectorData[0])) {
               List<TextDateTimeHash> StringDatetimeList = Intelligence.getFileNameDateCreateHash(vectorData[0], 30, false, 0, vectorData[4]);


                TimeSpan ts = timeAtual - StringDatetimeList[0].dateAndHour;
                if(ts.Days < 1) { /**futuramente usarui escolhara object time de verificacao*/

                /*    Console.WriteLine("Backup feito");

                } else {
                    Console.WriteLine("nao feito");
                }
            } else {
                Console.WriteLine("ola");
            }*/
        }

        private void button1_Click(object sender, EventArgs e) {


        }
        private async void btnConnectOnedriver_Click(object sender, EventArgs e) {
           Debug.WriteLine (await connectOnedriver());
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
            /*after implements hour server database*/
            DateTime timeAtual = DateTime.Now;
            int amount = 5;
            String query = @"select b.id as id_backup, b.origin, b.destiny, e.id as id_extension , e.name from backups b, extensions e where e.id = b.extension_id ";
            string stringConnection  = WorkPostgreSQL.getStringConection (server, port,  user, password, dataBase);  
            List<ColumnValueType> listParameterColumnValueType = new List<ColumnValueType>();
            listParameterColumnValueType.Add(new  ColumnValueType{column= "origin", dataType =NpgsqlDbType.Varchar, value ="C:\\patrikFullManagerBackupService\\o" });
            listParameterColumnValueType.Add(new  ColumnValueType{column= "name", dataType =NpgsqlDbType.Varchar, value ="rar" });
            NpgsqlDataReader dr =  WorkPostgreSQL.select(stringConnection,query, listParameterColumnValueType);   
            while (dr.Read()) {
            String x =     dr["name"].ToString();   
                
                
            }       
                        
           


           /* String[] vectorData =  {"C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\origin",
                "C:\\Users\\patrik\\Desktop\\allProjectsVisualStudio\\BackupInCloud\\patrikFullManagerBackupService\\destiny",
            "",
            "",
            "rar"};*/

   
           /* if(WorkerDirectory.directoryExist(vectorData[0])) {
                List<TextDateTimeHash> StringDatetimeList = Intelligence.getFileNameDateCreateHash(vectorData[0], 30, false, 0, vectorData[4]);


                TimeSpan ts = timeAtual - StringDatetimeList[0].dateAndHour;
                if(ts.Days < 1) { /**futuramente usarui escolhara object time de verificacao*/

                   /* Console.WriteLine("Backup feito");

                } else {
                    Console.WriteLine("nao feito");
                }
            } else {
                Console.WriteLine("ola");
            }*/

            
        }

  

        private void btnCompress_Click(object sender, EventArgs e) {
            String origin = "C:\\patrikFullManagerBackupService\\o";
            String destiny = "C:\\patrikFullManagerBackupService\\d";
            String nameOriginal = "192.168.11.4_04_20160613_120000.avi";
            String nameCompress = "192.168.11.4_04_20160613_120000.7z";
            add(origin, destiny, nameOriginal, nameCompress);



           


             
        }

      

        private void btnTestCompressFile_Click(object sender, EventArgs e) {
            String origin = "C:\\patrikFullManagerBackupService\\o";
            String destiny = "C:\\patrikFullManagerBackupService\\d";
            String nameOriginal = "192.168.11.4_04_20160613_120000.avi";
            String nameCompress = "192.168.11.4_04_20160613_120000.7z";
            test(destiny, nameCompress);
        }

        private void testGenerateForFileHash_Click(object sender, EventArgs e) {
            String local  = "C:\\patrikFullManagerBackupService\\o";
         
            String name = "Telefones.xlsx";

             Debug.WriteLine (getSha1ToFile(local, name));
            MessageBox.Show(getSha1ToFile(local, name)); 
       
        }

        private void testRDMS_Click(object sender, EventArgs e) {   
           
            
            Debug.WriteLine (WorkPostgreSQL.configurationIsOk ("172.16.250.130","5432","postgres","root", "backupInCloudWebUI_development"));
            MessageBox.Show(WorkPostgreSQL.configurationIsOk ("172.16.250.130","5432","postgres","root", "backupInCloudWebUI_development"));
        }

        private void testQuery_Click(object sender, EventArgs e) {
            String query = "select b.id, b.origin, b.destiny, e.id, e.name from backups b, extensions e where e.id = b.extension_id";
             string stringConnection  = WorkPostgreSQL.getStringConection (server, port,  user, password, dataBase);    
           

            NpgsqlDataReader dr =  WorkPostgreSQL.select(stringConnection,query);
          
            String aux = "";
            for (int i = 0; i < dr.FieldCount; i++) {

                aux += dr.GetName(i) + "\t";
            }
           
            while (dr.Read()) {

                aux += "\n";
                 for (int i = 0; i < dr.FieldCount; i++) {

                     aux += dr[i].ToString() + "\t";
                }
               
            }
          //  dbPatrikFullManagerBackupDllDataBase.conn.Close();

            MessageBox.Show(aux, "");
        }

        private void testeQueryParameter_Click(object sender, EventArgs e) {
            String query = @"select b.id as id_backup, b.origin, b.destiny, e.id as id_extension , e.name from backups b, extensions e where e.id = b.extension_id and b.origin from backups b, extensions e where e.id = b.extension_id and b.origin = :origin and e.name = :name";
             string stringConnection  = WorkPostgreSQL.getStringConection (server, port,  user, password, dataBase);  
             List<ColumnValueType> listParameterColumnValueType = new List<ColumnValueType>();
             listParameterColumnValueType.Add(new  ColumnValueType{column= "origin", dataType =NpgsqlDbType.Varchar, value ="C:\\patrikFullManagerBackupService\\o" });
             listParameterColumnValueType.Add(new  ColumnValueType{column= "name", dataType =NpgsqlDbType.Varchar, value ="rar" });
           

               /* public struct ColumnValueType {
        public String column;
        public NpgsqlDbType dataType;
        public Object value;
        
    };*/

            NpgsqlDataReader dr =  WorkPostgreSQL.select(stringConnection,query, listParameterColumnValueType);
          
            String aux = "";
            for (int i = 0; i < dr.FieldCount; i++) {

                aux += dr.GetName(i) + "\t";
            }
           
            while (dr.Read()) {

                aux += "\n";
                 for (int i = 0; i < dr.FieldCount; i++) {

                     aux += dr[i].ToString() + "\t";
                }
               
            }
          //  dbPatrikFullManagerBackupDllDataBase.conn.Close();

            MessageBox.Show(aux, "");

        } 

        private void validateGetNameDateTimeHash_Click(object sender, EventArgs e) {
           List<TextDateTimeHash> listNameDateListHash = Intelligence.getFileNameDateCreateHash("M:\\o", (int) Intelligence.searchDateFile.GetCreationTime, "exe");
            String aux = "";
             if (listNameDateListHash != null && listNameDateListHash.Count != 0) {
                foreach (TextDateTimeHash unitNameDateListHash in listNameDateListHash) {
                  aux += unitNameDateListHash.text + "\t";
                  aux += unitNameDateListHash.dateAndHour.ToString() + "\t";
                   aux += unitNameDateListHash.hash + "\t\n";

                }

               Debug.WriteLine(aux);

               MessageBox.Show(aux);
            }
                 
           

        // public static List<TextDateTimeHash> getFileNameDateCreateHash(String sourceDirectory, int numberGetNameAndDatatime, bool ascendingIsTheQuestion, int typeSearchDateFile = 0 /*default datetime creation*/, string extension = "*") {
        }
    }
}
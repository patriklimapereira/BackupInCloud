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
using System.Diagnostics;
using System.Threading;
using System.Globalization;




using System.IO.Compression;
using Npgsql;

namespace patrikService {

    public partial class TestSubRoutineService : Form {
        private String server = "192.168.79.130";
        private String port = "5432";
        private String user = "postgres";
        private String password = "root";
        private String dataBase = "backupInCloudWebUI_development";

        private const string msaClientId = "3e776a02-19a4-481c-92f0-61832a8ba791";
        private const string msaReturnUrl = "https://login.live.com/oauth20_desktop.srf";
        /*temp*/
        private string folderRootIndDriverForPatrikFullManagerBackupService = "patrikFullManagerBackupService";
        //   private string separatorFolderBackupInOneDriver = "#-+-#";

        private static readonly string[] scopes = { "onedrive.readwrite", "wl.offline_access", "wl.signin" };


        private IOneDriveClient oneDriveClient { get; set; }
        public TestSubRoutineService() {
            InitializeComponent();
        }



        private async void btnConnect_Click(object sender, EventArgs e) {
            try {
                this.oneDriveClient = await WorkerOnedrive.signIn(msaClientId, msaReturnUrl, scopes);
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
        }


        private async void listFolder_Click(object sender, EventArgs e) {

            bool x = await WorkerOnedrive.selectFolder(this.oneDriveClient, Path.Combine(folderRootIndDriverForPatrikFullManagerBackupService, "patrikFullManagerBackupService"));
        }


        private async void btnSelect_Click(object sender, EventArgs e) {
            String x = await WorkerOnedrive.searchFolder(this.oneDriveClient, Path.Combine(folderRootIndDriverForPatrikFullManagerBackupService, "c6asa.txt"));
            MessageBox.Show(x);
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
               List<localTextDateTimeHashExtension> StringDatetimeList = Intelligence.getFileNameDateCreateHash(vectorData[0], 30, false, 0, vectorData[4]);


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
            Debug.WriteLine(await connectOnedriver());
        }
        private async Task<bool> connectOnedriver() {
            try {
                this.oneDriveClient = await WorkerOnedrive.signIn(msaClientId, msaReturnUrl, scopes);
                return true;
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
                return false;
            }
        }

        private void btnRoutine_Click(object sender, EventArgs e) {
            /*after implements hour server database*/
            DateTime timeAtual = DateTime.Now;
            /*return list folder of the database*/
            String query = @"select b.id as id_backup, b.origin, b.destiny, e.id as id_extension , e.name from backups b, extensions e where e.id = b.extension_id;";
            String stringConnection = WorkPostgreSQL.getStringConection(server, port, user, password, dataBase);
            List<ColumnValueType> listParameterColumnValueType = new List<ColumnValueType>();
            NpgsqlDataReader drBackupsExtensions = WorkPostgreSQL.ExecuteReader(stringConnection, query);
            /*line directory backup*/
            while (drBackupsExtensions.Read()) {
                List<localTextDateTimeHashExtension> listLocalNameDateListHashExtension = Intelligence.getFileNameDateCreateHash((string)drBackupsExtensions["origin"], (int)Intelligence.searchDateFile.GetCreationTime, (String)drBackupsExtensions["name"]);
                if (listLocalNameDateListHashExtension == null) {/*directory  o  not exist*/
                    MessageBox.Show("after implements directory  origem  not existe ");
                } else if (!WorkerDirectory.directoryExist((string)drBackupsExtensions["destiny"])) {
                    MessageBox.Show("after implements directory  destiny not existe ");
                } else if (listLocalNameDateListHashExtension.Count <= 0) {
                    MessageBox.Show("after implements directory   empty ");
                } else {
                 //   try {
                        long errorCodeExecuteNonQueryPorraLoka;
                        NpgsqlConnection conn = WorkPostgreSQL.getConnection(stringConnection);
                        int j = 0, i = 0;
                        List<ColumnValueType> listHashFileDateTimeCreation = new List<ColumnValueType>();
                        query = @"drop table if exists temp_list_local_name_datetime_list_hash_extension_from_database;";
                        query += @"create table temp_list_local_name_datetime_list_hash_extension_from_database(date_and_hour timestamp, hash  varchar, name varchar );";
                        errorCodeExecuteNonQueryPorraLoka = WorkPostgreSQL.ExecuteNonQueryPorraLoka(ref conn, query);
                        WorkPostgreSQL.endConnection(ref conn);
                        listLocalNameDateListHashExtension = listLocalNameDateListHashExtension.Where(a => a.dateAndHour >= timeAtual.AddDays(-1005)).OrderBy(s => s.dateAndHour).ToList();
                        /*verify table create*/
                        if (errorCodeExecuteNonQueryPorraLoka == Util.psMaxValueLong) {
                            /*after implements  create table temporary*/
                            MessageBox.Show("error create table temporary");
                        } else {
                            query = @"insert into temp_list_local_name_datetime_list_hash_extension_from_database(date_and_hour , hash, name) values";
                            /*query += "(" + marcationOfParameterDataBaseForAutomaticGenerateParamenter + ++j + "," + marcationOfParameterDataBaseForAutomaticGenerateParamenter + ++j + ","+marcationOfParameterDataBaseForAutomaticGenerateParamenter + ++j +")";
                            listHashFileDateTimeCreation.Add(new ColumnValueType { column = marcationOfParameterDataBaseForAutomaticGenerateParamenter + (j - 2), dataType = NpgsqlDbType.Timestamp, value = listLocalNameDateListHashExtension[i].dateAndHour });
                            listHashFileDateTimeCreation.Add(new ColumnValueType { column = marcationOfParameterDataBaseForAutomaticGenerateParamenter + (j - 1), dataType = NpgsqlDbType.Varchar, value = listLocalNameDateListHashExtension[i].hash });
                            listHashFileDateTimeCreation.Add(new ColumnValueType { column = marcationOfParameterDataBaseForAutomaticGenerateParamenter + j, dataType = NpgsqlDbType.Varchar, value = listLocalNameDateListHashExtension[i].name });
                            i++;*/
                            while (i < listLocalNameDateListHashExtension.Count) {                            
                                  query += ( (i != 0 )? "," : "" ) +"(" + marcationOfParameterDataBaseForAutomaticGenerateParamenter + ++j + "," + marcationOfParameterDataBaseForAutomaticGenerateParamenter + ++j + ","+marcationOfParameterDataBaseForAutomaticGenerateParamenter + ++j +")";
                                  listHashFileDateTimeCreation.Add(new ColumnValueType { column = marcationOfParameterDataBaseForAutomaticGenerateParamenter + (j - 2), dataType = NpgsqlDbType.Timestamp, value = listLocalNameDateListHashExtension[i].dateAndHour });
                                  listHashFileDateTimeCreation.Add(new ColumnValueType { column = marcationOfParameterDataBaseForAutomaticGenerateParamenter + (j - 1), dataType = NpgsqlDbType.Varchar, value = listLocalNameDateListHashExtension[i].hash });
                                  listHashFileDateTimeCreation.Add(new ColumnValueType { column = marcationOfParameterDataBaseForAutomaticGenerateParamenter + j, dataType = NpgsqlDbType.Varchar, value = listLocalNameDateListHashExtension[i].name });
                                i++;
                            }
                            query += ";";                             
                            errorCodeExecuteNonQueryPorraLoka = WorkPostgreSQL.ExecuteNonQuery(stringConnection, query, listHashFileDateTimeCreation);
                            if (errorCodeExecuteNonQueryPorraLoka == Util.psMaxValueLong) {
                                MessageBox.Show("error insert");
                            } else {
                            //  query = @"select  t.date_and_hour|| t.hash  || t.name from temp_list_local_name_datetime_list_hash_extension_from_database t where t.date_and_hour || t.hash not  in ( select    o.hash_local || o.file_datetime_creation  from operations  o)";
                            query = @"select  t.date_and_hour, t.hash  , t.name from temp_list_local_name_datetime_list_hash_extension_from_database t where t.date_and_hour || t.hash not  in ( select    o.hash_local || o.file_datetime_creation  from operations  o)";
                            NpgsqlDataReader drOperation = WorkPostgreSQL.ExecuteReader(stringConnection, query, listHashFileDateTimeCreation);
             

                            // List<localTextDateTimeHashExtension> listTimeHashFromRDMS = new List<localTextDateTimeHashExtension>();
                            while (drOperation.Read()) {                                    
                                    /*List<localTextDateTimeHashExtension> listTimeHashFromRDMS */
                                   // localTextDateTimeHashExtension listTimeHashFromRDMS ;                                        
                                     localTextDateTimeHashExtension listTimeHashFromRDMS = listLocalNameDateListHashExtension.Where(a => a.dateAndHour.ToString(Util.psFORMATDATATIME)+a.hash+a.name == (((DateTime)drOperation["date_and_hour"]).ToString(Util.psFORMATDATATIME)+(string)drOperation["hash"]+(string)drOperation["name"] ) ).ToList()[0];


                                 
                                    MessageBox.Show("para aqui");
                                    int x = 0;
                                    /*copy origin for destiny*/
                                    /*compactar*/
                                    /*upload*/
                                }
                            }
                        }

                /*    } catch (Exception erro) {
                       MessageBox.Show(erro.ToString());
                    }*/
                }

            }

            /*TimeSpan ts = timeAtual - StringDatetimeList[0].dateAndHour;
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
            String local = "C:\\patrikFullManagerBackupService\\o";

            String name = "Telefones.xlsx";

            Debug.WriteLine(getSha1ToFile(local, name));
            MessageBox.Show(getSha1ToFile(local, name));

        }

        private void testRDMS_Click(object sender, EventArgs e) {


            Debug.WriteLine(WorkPostgreSQL.configurationIsOk(server, "5432", "postgres", "root", "backupInCloudWebUI_development"));
            MessageBox.Show(WorkPostgreSQL.configurationIsOk(server, "5432", "postgres", "root", "backupInCloudWebUI_development"));
        }

        private void testQuery_Click(object sender, EventArgs e) {
            String query = "ExecuteReader * from operations";
            string stringConnection = WorkPostgreSQL.getStringConection(server, port, user, password, dataBase);


            NpgsqlDataReader dr = WorkPostgreSQL.ExecuteReader(stringConnection, query);

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
            //  String value1 = Util.psReturnTimeString().Replace("-","_").Replace(" ","__");
            String value1 = "1";
            String value2 = "2";
            Thread.Sleep(2000);
            //  String value2 = Util.psReturnTimeString().Replace("-","_").Replace(" ","__");
            MessageBox.Show(value1 + value2);
            String query = @"ExecuteReader b.id as id_backup, b.origin, b.destiny, e.id as id_extension , e.name from backups b, extensions e where e.id = b.extension_id  and b.origin = :" + value1 + " and e.name = :" + value2 + "";
            string stringConnection = WorkPostgreSQL.getStringConection(server, port, user, password, dataBase);
            List<ColumnValueType> listParameterColumnValueType = new List<ColumnValueType>();
            listParameterColumnValueType.Add(new ColumnValueType { column = value1, dataType = NpgsqlDbType.Varchar, value = "M:\\o" });
            listParameterColumnValueType.Add(new ColumnValueType { column = value2, dataType = NpgsqlDbType.Varchar, value = "exe" });


            /* public struct ColumnValueType {
     public String column;
     public NpgsqlDbType dataType;
     public Object value;

 };*/

            NpgsqlDataReader dr = WorkPostgreSQL.ExecuteReader(stringConnection, query, listParameterColumnValueType);

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
            List<localTextDateTimeHashExtension> listLocalNameDateListHashExtension = Intelligence.getFileNameDateCreateHash("M:\\o", (int)Intelligence.searchDateFile.GetCreationTime, "exe");
            int days = Intelligence.calculeAmountDaysUseful(30);
            if (listLocalNameDateListHashExtension.Count == 0) {
                /*initial storage*/
                listLocalNameDateListHashExtension = listLocalNameDateListHashExtension.OrderBy(s => s.dateAndHour).ToList().GetRange(0, days);
                foreach (localTextDateTimeHashExtension ltdhe in listLocalNameDateListHashExtension) {

                }


            } else {
                /*   String aux = "";
                   if (listLocalNameDateListHashExtension != null && listLocalNameDateListHashExtension.Count != 0) {
                       foreach (localTextDateTimeHashExtension unitNameDateListHash in listLocalNameDateListHashExtension) {
                           aux += unitNameDateListHash.name + "\t";
                           aux += unitNameDateListHash.dateAndHour.ToString() + "\t";
                           aux += unitNameDateListHash.hash + "\t\n";

                       }

                       Debug.WriteLine(aux);

                       MessageBox.Show(aux);
                   }*/
            }



            // public static List<localTextDateTimeHashExtension> getFileNameDateCreateHash(String sourceDirectory, int numberGetNameAndDatatime, bool ascendingIsTheQuestion, int typeSearchDateFile = 0 /*default datetime creation*/, string extension = "*") {
        }

        private void button1_Click_1(object sender, EventArgs e) {

        }

        private void returnDate_Click(object sender, EventArgs e) {
            int j = 0;
            MessageBox.Show(" " + j++);

        }

        private void testQueryP2_Click(object sender, EventArgs e) {
            //  ExecuteReader * from operations  o where o.hash_local  in ('568') and o.file_datetime_creation  in ('2016-08-28 12:36:00' )
            //  String value1 = Util.psReturnTimeString().Replace("-","_").Replace(" ","__");
            String value1 = "568";
            DateTime value2 = DateTime.ParseExact("2016082812:36:00", "yyyyMMddHH:mm:ss", DateTimeFormatInfo.InvariantInfo);



            String valueName1 = ":1";
            String valueName2 = ":2";

            //MessageBox.Show(value2.ToString(Util.psFORMATDATATIME)) ;   
            // MessageBox.Show(value2.ToString()) ;  

            //  Thread.Sleep(2000);
            //  String value2 = Util.psReturnTimeString().Replace("-","_").Replace(" ","__");
            MessageBox.Show(value1 + value2);
            String query = @"ExecuteReader * from operations  o where o.hash_local  in (" + valueName1 + ") and o.file_datetime_creation  in (" + valueName2 + " )";
            string stringConnection = WorkPostgreSQL.getStringConection(server, port, user, password, dataBase);
            List<ColumnValueType> listParameterColumnValueType = new List<ColumnValueType>();
            //  MessageBox.Show(query);
            listParameterColumnValueType.Add(new ColumnValueType { column = valueName1.Replace(":", ""), dataType = NpgsqlDbType.Varchar, value = value1 });
            listParameterColumnValueType.Add(new ColumnValueType { column = valueName2.Replace(":", ""), dataType = NpgsqlDbType.Timestamp, value = value2 });


            /* public struct ColumnValueType {
     public String column;
     public NpgsqlDbType dataType;
     public Object value;

 };*/

            NpgsqlDataReader dr = WorkPostgreSQL.ExecuteReader(stringConnection, query, listParameterColumnValueType);



            String aux = "";
            for (int i = 0; i < dr.FieldCount; i++) {

                aux += dr.GetName(i) + "\t";
            }
            MessageBox.Show(dr.HasRows.ToString());
            while (dr.Read()) {

                aux += "\n";
                for (int i = 0; i < dr.FieldCount; i++) {

                    aux += dr[i].ToString() + "\t";
                }

            }
            //  dbPatrikFullManagerBackupDllDataBase.conn.Close();

            MessageBox.Show(aux, "");

        }

        private void ddlInsert_Click(object sender, EventArgs e) {
            String stringConnection = WorkPostgreSQL.getStringConection(server, port, user, password, dataBase);
            String query = @"create  table temp_list_local_name_datetime_list_hash_extension_from_database(date_and_hour_hash varchar(69) ); 
                            drop table temp_list_local_name_datetime_list_hash_extension_from_database ;
                            create  table temp_list_local_name_datetime_list_hash_extension_from_database(date_and_hour_hash varchar(69) );";


            WorkPostgreSQL.ExecuteNonQuery(stringConnection, query);
            MessageBox.Show("ola");
        }
    }
}
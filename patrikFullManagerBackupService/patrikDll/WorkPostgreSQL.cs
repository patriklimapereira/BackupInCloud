using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;


namespace PatrikSystemPersistence {

    public struct ColumnValueType {
        public String Column;
        public Object valor;
        public NpgsqlDbType dataType;
    };

   public class WorkPostgreSQL {
        public string serverName { get; set; } //localhost
        public string port { get; set; }            //porta
        public string userName { get; set; }   //nome 
        public string password { get; set; }     //senha 
        private string databaseName { get; set; }    //nome do banco de dados
        public NpgsqlConnection conn { get; set; }

        private NpgsqlCommand command { get; set; }

        public NpgsqlDataReader dr { get; set; }

        private static  NpgsqlConnection getConnection () {

            return null;
        }

       
     
        


        private static  NpgsqlConnection getConnection (String server, String port, String user, String password, String dataBase) {
            return new NpgsqlConnection(getStringConection(server, port, user, password, dataBase));
        }


        private static String getStringConection(String server, String port, String user, String password, String dataBase) {
            return "Server=" + server + ";" +
              "Port=" + port + ";" +
              "User Id=" + user + ";" +
              "Password=" + password + ";" +
              "Database=" + dataBase + ";";
        }

        private NpgsqlDbType identificaNpgsqlDbType(String dataType) {


            return NpgsqlDbType.Bigint;
        }
        public void s6elect(String consulta, List<ColumnValueType> columnValueType = null) {
            try {
                this.command = new NpgsqlCommand(consulta, this.conn);


                for (int i = 0; columnValueType != null && i < columnValueType.Count; i++) {
                    this.command.Parameters.Add(new NpgsqlParameter(columnValueType[i].Column, columnValueType[i].dataType));
                    this.command.Parameters[0].Value = columnValueType[i].valor;
                };
                this.dr = this.command.ExecuteReader();
            } catch (NpgsqlException ex) {
                throw ex;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string configurationIsOk(String serverName, String port, String userName, String password, String databaseName) {
            try {                
                WorkPostgreSQL dbPatrikFullManagerBackupDllDataBase;
                /*server = "10.69.24.24";
                port = "5432";
                user = "postgres";
                password = "root";
                database = "patrikFullManagerBackupDllDataBase";*/

                dbPatrikFullManagerBackupDllDataBase = new WorkPostgreSQL(serverName, port, userName, password, databaseName);
                dbPatrikFullManagerBackupDllDataBase.conn.Open();
                dbPatrikFullManagerBackupDllDataBase.conn.Close();


            }
            catch (Exception erro) {
                return erro.ToString();
            }

            return "ok";
        }


     /*   private String getStringConection() {
            return "Server=" + this.serverName + ";" +
              "Port=" + this.port + ";" +
              "User Id=" + this.userName + ";" +
              "Password=" + this.password + ";" +
              "Database=" + this.databaseName + ";";
        }*/

    }
}

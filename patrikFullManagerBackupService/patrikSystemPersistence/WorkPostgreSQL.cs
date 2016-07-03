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

        public WorkPostgreSQL() {
            this.serverName = "";
            this.port = "";
            this.userName = "";
            this.password = "";
            this.databaseName = "";
            this.conn = null;
            this.command = null;

        }
        public WorkPostgreSQL(String serverName, String port, String userName, String password, String databaseName) {
            this.serverName = serverName;
            this.port = port;
            this.userName = userName;
            this.password = password;
            this.databaseName = databaseName;
            this.conn = new NpgsqlConnection(this.getStringConection());
            this.command = null;

        }

        private NpgsqlDbType identificaNpgsqlDbType(String dataType) {


            return NpgsqlDbType.Bigint;
        }
        public void select(String consulta, List<ColumnValueType> columnValueType = null) {
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
                /*serverName = "10.69.24.24";
                port = "5432";
                userName = "postgres";
                password = "root";
                databaseName = "patrikFullManagerBackupDllDataBase";*/

                dbPatrikFullManagerBackupDllDataBase = new WorkPostgreSQL(serverName, port, userName, password, databaseName);
                dbPatrikFullManagerBackupDllDataBase.conn.Open();
                dbPatrikFullManagerBackupDllDataBase.conn.Close();


            }
            catch (Exception erro) {
                return erro.ToString();
            }

            return "ok";
        }


        private String getStringConection() {
            return "Server=" + this.serverName + ";" +
              "Port=" + this.port + ";" +
              "User Id=" + this.userName + ";" +
              "Password=" + this.password + ";" +
              "Database=" + this.databaseName + ";";
        }

    }
}

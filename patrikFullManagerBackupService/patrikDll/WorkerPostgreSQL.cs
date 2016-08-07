using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;

using System.Windows.Forms;

using System.Diagnostics;


namespace patrikDll {

    public struct ColumnValueType {
        public String column;
        public NpgsqlDbType dataType;
        public Object value;
        
    };

    public static class WorkPostgreSQL {
        /*   public string serverName { get; set; } //localhost
           public string port { get; set; }            //porta
           public string userName { get; set; }   //nome 
           public string password { get; set; }     //senha 
           private string databaseName { get; set; }    //nome do banco de dados
           public NpgsqlConnection conn { get; set; }

           private NpgsqlCommand command { get; set; }

           public NpgsqlDataReader dr { get; set; }*/   
                     


       private static NpgsqlConnection getConnection(String stringConnetion) {
            NpgsqlConnection conn =  new NpgsqlConnection( stringConnetion);
            conn.Open();
            return conn;
        }


    /*     private static NpgsqlConnection getConnection(String server, String port, String user, String password, String dataBase) {
            return new NpgsqlConnection(  getStringConection( server, port,  user,  password, dataBase));
        }*/



        public static String getStringConection(String server, String port, String user, String password, String dataBase) {
            return "Server=" + server + ";" +
              "Port=" + port + ";" +
              "User Id=" + user + ";" +
              "Password=" + password + ";" +
              "Database=" + dataBase + ";";
        }

        /*  private NpgsqlDbType identificaNpgsqlDbType(String dataType) {


              return NpgsqlDbType.Bigint;
          }*/
        public static NpgsqlDataReader select(String stringConnection , String consulta, List<ColumnValueType> columnValueType = null) {

            NpgsqlCommand command;
            NpgsqlDataReader dr = null;
            try {
                command = new NpgsqlCommand(consulta, getConnection( stringConnection ));


                if (columnValueType != null) {
                    for (int i = 0; i < columnValueType.Count; i++) {
                        command.Parameters.Add(new NpgsqlParameter(columnValueType[i].column, columnValueType[i].dataType));
                        command.Parameters[i].Value = columnValueType[i].value;
                    };

                }
             //   Console.WriteLine( command.CommandText);
             //   MessageBox.Show(       command.CommandText);

               //    MessageBox.Show(   command.Statements.ToString())      ;           
         
                dr = command.ExecuteReader();
            } catch (NpgsqlException ex) {
                MessageBox.Show(ex.ToString());

                return null;
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());

                return null;
            }

            return dr;
        }


        /*after otimize*/
        public static string configurationIsOk(String server, String port, String user, String password, String dataBase) {
            try {
                NpgsqlConnection conn = getConnection(  getStringConection( server, port,  user,  password, dataBase));
                conn.Open();
                conn.Close();

            } catch (Exception erro) {
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

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
                     


       public  static NpgsqlConnection getConnection(String stringConnetion) {
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
     
        private static void verififySqlInDataBase (String consulta, List<ColumnValueType> columnValueType = null) {
             string prefixString = "'";                       
              if (columnValueType != null) {
                    for (int i = 0; i < columnValueType.Count; i++) {
                     switch (columnValueType[i].dataType) {
                        case NpgsqlDbType.Varchar:
                        case NpgsqlDbType.Text:
                            prefixString = "'";  
                               consulta = consulta.Replace(columnValueType[i].column,     prefixString +  (string) columnValueType[i].value   +   prefixString );
                            break;
                        case NpgsqlDbType.Timestamp: 
                                          
                            prefixString = "'";  
                                consulta = consulta.Replace(columnValueType[i].column,     prefixString +   ((DateTime )columnValueType[i].value ).ToString(Util.psFORMATDATATIME).ToString()   +   prefixString );
                            break;
                        default:
                           MessageBox.Show("porra loka");
                            prefixString = "";
                            consulta = consulta.Replace(columnValueType[i].column,     prefixString +  (string) columnValueType[i].value   +   prefixString );
                            break;
                    }


                    prefixString = "";
                    };

                }
              
              Console.WriteLine("rogelia");
              Console.WriteLine (consulta);

        }

        private static NpgsqlCommand prepareStatement (String stringConnection, String query, List<ColumnValueType> columnValueType = null) {
          NpgsqlCommand command;
            try {
                command = new NpgsqlCommand(query, getConnection(stringConnection));
                if (columnValueType != null) {
                    for (int i = 0; i < columnValueType.Count; i++) {
                        command.Parameters.Add(new NpgsqlParameter(columnValueType[i].column, columnValueType[i].dataType));
                        command.Parameters[i].Value = columnValueType[i].value;
                    }
                }
            //    verififySqlInDataBase(query, columnValueType);
                return command;
            } catch (NpgsqlException ex) {
                MessageBox.Show("erro....\n\n\n\n\n\n\n" + ex.ToString());
                return null;
            } catch (Exception ex) {
                MessageBox.Show("erro....\n\n\n\n\n\n\n" + ex.ToString());
                return null;

            }

        }

        public static int ExecuteNonQueryPorraLoka(ref NpgsqlConnection conn, String query) {
            return new NpgsqlCommand(query, conn).ExecuteNonQuery();        

        }


        public static int  ExecuteNonQuery (String stringConnection , String query, List<ColumnValueType> columnValueType = null) {
            NpgsqlCommand command = prepareStatement(stringConnection, query, columnValueType);     
            verififySqlInDataBase( query,  columnValueType );                           
            return  (command == null) ?  -1 :  command.ExecuteNonQuery(); 

        }

        public static NpgsqlDataReader ExecuteReader(String stringConnection , String query, List<ColumnValueType> columnValueType = null) {
            NpgsqlCommand command = prepareStatement(stringConnection, query, columnValueType);
             verififySqlInDataBase( query,  columnValueType );   
            return (command == null) ? null : command.ExecuteReader();
          
          
        }


        /*after otimize*/
        public static string configurationIsOk(String server, String port, String user, String password, String dataBase) {
            try {
                NpgsqlConnection conn = getConnection(  getStringConection( server, port,  user,  password, dataBase));
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

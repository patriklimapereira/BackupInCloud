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
                     
       public  static NpgsqlConnection getConnection(String stringConnetion) {
            NpgsqlConnection conn =  new NpgsqlConnection( stringConnetion);
            conn.Open();
            return conn;
        }


      public static  NpgsqlConnection endConnection (ref NpgsqlConnection conn) {
           conn.Close ();
            return conn;
        }
                 
        public static String getStringConection(String server, String port, String user, String password, String dataBase) {
            return "Server=" + server + ";" +
              "Port=" + port + ";" +
              "User Id=" + user + ";" +
              "Password=" + password + ";" +
              "Database=" + dataBase + ";";
        }

            
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
              verififySqlInDataBase(query, columnValueType);
                return command;
            } catch (NpgsqlException ex) {
                MessageBox.Show("erro....\n\n\n\n\n\n\n" + ex.ToString());
                return null;
            } catch (Exception ex) {
                MessageBox.Show("erro....\n\n\n\n\n\n\n" + ex.ToString());
                return null;

            }

        }

        public static long   ExecuteNonQueryPorraLoka(ref NpgsqlConnection conn, String query) {
             try { 
               return  new NpgsqlCommand(query,  conn).ExecuteNonQuery();
                           
             }   catch (Exception error) {
                return  Util.psMaxValueLong;
            }  

        }


        public static long  ExecuteNonQuery (String stringConnection , String query, List<ColumnValueType> columnValueType = null) {
            NpgsqlCommand command = prepareStatement(stringConnection, query, columnValueType);     
            verififySqlInDataBase( query,  columnValueType );                           
            return  (command == null) ?   Util.psMaxValueLong :  command.ExecuteNonQuery(); 

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


    }
}

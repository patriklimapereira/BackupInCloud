﻿using System;
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
     
        private static void verififySqlInDataBase (String consulta, List<ColumnValueType> columnValueType = null) {
             string prefixString = "'";  
              string marcape = ":";            
              if (columnValueType != null) {
                    for (int i = 0; i < columnValueType.Count; i++) {
                     switch (columnValueType[i].dataType) {
                        case NpgsqlDbType.Varchar:
                        case NpgsqlDbType.Text:
                            prefixString = "'";  
                               consulta = consulta.Replace(marcape+columnValueType[i].column,     prefixString +  (string) columnValueType[i].value   +   prefixString );
                            break;
                        case NpgsqlDbType.Timestamp: 
                                          
                            prefixString = "'";  
                                consulta = consulta.Replace(marcape+columnValueType[i].column,     prefixString +   ((DateTime )columnValueType[i].value ).ToString("yyyy-MM-dd HH:mm:ss").ToString()   +   prefixString );
                            break;
                        default:
                           MessageBox.Show("porra loka");
                            prefixString = "";
                                consulta = consulta.Replace(marcape+columnValueType[i].column,     prefixString +  (string) columnValueType[i].value   +   prefixString );
                            break;
                    }


                    prefixString = "";
                    };

                }
              
              Console.WriteLine("rogelia");
              Console.WriteLine (consulta);

        }

        public static int  insert (String stringConnection , String query, List<ColumnValueType> columnValueType = null) {
            NpgsqlCommand command;
            int numberRownsAffected; 
            command = new NpgsqlCommand(query, getConnection( stringConnection ));
            numberRownsAffected  = command.ExecuteNonQuery();

            return 0;
        }

        public static NpgsqlDataReader select(String stringConnection , String query, List<ColumnValueType> columnValueType = null) {
            NpgsqlCommand command;
            NpgsqlDataReader dr = null;
            try {
                command = new NpgsqlCommand(query, getConnection( stringConnection ));
                if (columnValueType != null) {
                    for (int i = 0; i < columnValueType.Count; i++) {
                        command.Parameters.Add(new NpgsqlParameter(columnValueType[i].column, columnValueType[i].dataType));
                        command.Parameters[i].Value = columnValueType[i].value;
                    };
                }
                verififySqlInDataBase( query, columnValueType );     
                dr = command.ExecuteReader();
               } catch (NpgsqlException ex) {      
                MessageBox.Show( "erro....\n\n\n\n\n\n\n"  + ex.ToString());
                 return null;
            } catch (Exception ex) {
                MessageBox.Show("erro....\n\n\n\n\n\n\n"+ex.ToString());
                return null;
            }
            return dr;
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

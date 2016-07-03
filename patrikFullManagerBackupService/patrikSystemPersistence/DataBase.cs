using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace patrikSystemBackupDll {
    public class DataBase {
       /* private SQLiteConnection connection;

        private int openConnection() {
            try {
                 connection = new SQLiteConnection("Data Source=patrikSystemBackup.sqlite");
                 connection.Open();
                 return 0;
            }catch( Exception erro){
            return -1;
            }
            
        }

       public  void getTable() {
            string sql = "select * from name order by score desc";
            openConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["NAM_COD"] + "\tScore: " + reader["NAM_BACKUP"]);
                Console.ReadLine();
        }
            

           //    m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
         //   m_dbConnection.Open();
         
        */
    }
}

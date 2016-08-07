using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql;

using NpgsqlTypes;




namespace Crud {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            String consulta;
            String serverName, port, userName, password, databaseName;
            WorkPostgreSQL dbPatrikFullManagerBackupDllDataBase;
            List<ColumnValueType> listColumnValueType = new List<ColumnValueType>();
            ColumnValueType auxValoresDaColumnValueType;
            serverName = "172.16.250.130";
            port = "5432";
            userName = "postgres";
            password = "root";
            databaseName = "patrikFullManagerBackupDllDataBase";

            dbPatrikFullManagerBackupDllDataBase = new WorkPostgreSQL(serverName, port, userName, password, databaseName);
            dbPatrikFullManagerBackupDllDataBase.conn.Open();
            consulta = @"select s.sis_num, s.fab_num, s.sis_nome, a.acs_num, a.par_num, a.sis_num, p.par_num, p.usu_num, p.par_local_backup, p.par_local_move_backup, p.par_manter_quantas_versoes, p.par_extensao_backup, p.par_hora_de_verificacao, p.par_modificacaooucriacao, p.par_efetuar_verificacao from parametro p, sistema s,   acao_no_sistema a  where 
                  p.par_num = a.par_num and   a.sis_num = s.sis_num and  p.par_num in  ( select max ( p.par_num) from parametro p, sistema s, acao_no_sistema a where p.par_num = a.par_num and a.sis_num = s.sis_num group by s.sis_num )  and s.sis_num = :sis_num";
            auxValoresDaColumnValueType.Column = "sis_num";
            auxValoresDaColumnValueType.dataType = NpgsqlDbType.Bigint;  
            auxValoresDaColumnValueType.valor = 2;
            listColumnValueType.Add(auxValoresDaColumnValueType);



            dbPatrikFullManagerBackupDllDataBase.select(consulta, listColumnValueType);

            NpgsqlDataReader dr = dbPatrikFullManagerBackupDllDataBase.dr;
          
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
            dbPatrikFullManagerBackupDllDataBase.conn.Close();

            MessageBox.Show(aux, "");

        }

        private void button3_Click(object sender, EventArgs e) {
            String consulta;
            String serverName, port, userName, password, databaseName;
            WorkPostgreSQL dbPatrikFullManagerBackupDllDataBase;

            serverName = "10.69.24.24";
            port = "5432";
            userName = "postgres";
            password = "root";
            databaseName = "patrikFullManagerBackupDllDataBase";

            dbPatrikFullManagerBackupDllDataBase = new WorkPostgreSQL(serverName, port, userName, password, databaseName);
            dbPatrikFullManagerBackupDllDataBase.conn.Open();
            consulta = "select s.sis_num, s.fab_num, s.sis_nome, a.acs_num, a.par_num, a.sis_num, p.par_num, p.usu_num, p.par_local_backup, p.par_local_move_backup, p.par_manter_quantas_versoes, p.par_extensao_backup, p.par_hora_de_verificacao, p.par_modificacaooucriacao, p.par_efetuar_verificacao from parametro p, sistema s,   acao_no_sistema a  where p.par_num = a.par_num and   a.sis_num = s.sis_num and  p.par_num in  ( select max ( p.par_num) from parametro p, sistema s, acao_no_sistema a where p.par_num = a.par_num and a.sis_num = s.sis_num group by s.sis_num )";

            dbPatrikFullManagerBackupDllDataBase.select(consulta);

            NpgsqlDataReader dr = dbPatrikFullManagerBackupDllDataBase.dr;

            while (dr.Read()) {
                for (int i = 0; i < dr.FieldCount; i++) {
                    MessageBox.Show(dr[i].ToString(), "Important Message");
                }
                Console.WriteLine();
            }
            dbPatrikFullManagerBackupDllDataBase.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e) {

            Object x;
            x = 1;
            Console.WriteLine(x);
            x = "skdkd";
            Console.WriteLine(x);

        }
    }
}

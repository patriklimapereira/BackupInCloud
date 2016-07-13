using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace patrikSystemBackup {
    public partial class Service : ServiceBase {
       const String NAMEFILELOG = "patrikSystemBackup.log";
       const String LOCATEFILELOG = "cff";
            

        public Service() {
         
            InitializeComponent();

        }

        protected override void OnStart(string[] args) { 
        
     //      WorkFile.writeFile(true, NAMEFILELOG, LOCATEFILELOG, "Begin " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
          }

        protected override void OnStop() {
           // WorkFile.writeFile(true, NAMEFILELOG, LOCATEFILELOG, "End " +  DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
      


        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {

        }

        public void teste() {
           // WorkFile.writeFile(true, NAMEFILELOG, LOCATEFILELOG, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));


        }
    }

  
    

}

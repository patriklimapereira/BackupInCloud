using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using patrikSystemBackupDll;
using System.IO;


namespace patrikSystemBackupGUI {
    public partial class patrikSystemBackupGUI : Form {
        public patrikSystemBackupGUI() {
            InitializeComponent();
        }


        // private bool makeCopyFileAll(string sourceFile, string destFile,string extension, bool overwriter) {
        private bool makeCopyFileAll(string sourceFile,/* string destFile,*/string extension, bool overwriter) {

            /*if (Directory.Exists(sourceFile)) {
                   List <string> files = Directory.GetFiles(sourceFile).ToList();
                     
                   foreach (string s in files) {
                    
                       fileName = Path.GetFileName(s);
                    //   destFile = .Path.Combine(targetPath, fileName);
                    
                       System.IO.File.Copy(s, destFile, true);
                       //https://msdn.microsoft.com/pt-br/library/wz42302f(v=vs.110).aspx
                       //https://msdn.microsoft.com/pt-br/library/Cc148994(v=VS.120).aspx
                       //http://stackoverflow.com/questions/13301053/directory-getfiles-of-certain-extension
                   }
               }
               else {
                   Console.WriteLine("Source path does not exist!");
               }

               */
            return true;
        }




        private void button1_Click(object sender, EventArgs e) {

            List<StringDatetime> x = Intelligence.getFileNameDateCreate("C:\\Users\\patrik\\Downloads", 1, true, (int)Intelligence.searchDateFile.GetCreationTime, "*.zip");




            String test = "";
            foreach (StringDatetime i in x) {
                test += i.first + "\t" + i.second + "\n";
            }

            MessageBox.Show(test);
            //  MessageBox.Show(Intelligence.searchDateFile.GetCreationTime.ToString());


            // System.IO.File.Copy(s, destFile, true);
            //https://msdn.microsoft.com/pt-br/library/wz42302f(v=vs.110).aspx
            //https://msdn.microsoft.com/pt-br/library/Cc148994(v=VS.120).aspx
            //http://stackoverflow.com/questions/13301053/directory-getfiles-of-certain-extension
        }

        private void btnReset_Click(object sender, EventArgs e) {
            string s, d;
            string local = "\\\\srv-erp\\EL\\Backup\\Almox_patri"; 
            List<StringDatetime> listStringDatetime = Intelligence.getFileNameDateCreate(local, 15, false, (int)Intelligence.searchDateFile.GetCreationTime, "*.rar");
            if (listStringDatetime != null && listStringDatetime.Count != 0) {
                foreach (StringDatetime unitStringDatetime in listStringDatetime) {
                    s = Path.Combine(local, unitStringDatetime.first);
                    d = Path.Combine("C:\\Users\\patrik\\Desktop\\destino", unitStringDatetime.first);
                    if (File.Exists(d) == false) {
                        File.Copy(s, d);
                    }else {
                        switch (Intelligence.FileEquals(s, d)) {
                            case 0: File.Copy(s, d, true);
                                break;
                            case 2:
                                File.Copy(s, Intelligence.copyDuplicateNewName(d));
                                break;
                        }
                    }

                }
            }
            else {
                //criar tratamento de erro  
            }

        }

        private void btnProcurarOrigem_Click(object sender, EventArgs e) {
            this.fbdLocalDoArquivo.ShowNewFolderButton = false;
            this.fbdLocalDoArquivo.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdLocalDoArquivo.Description = "Selecione a pasta de origem do backup";
            if (this.fbdLocalDoArquivo.ShowDialog() == DialogResult.OK) {
                this.tbOrigem.Text = fbdLocalDoArquivo.SelectedPath;
            }

        }

        private void btnProcurarDestino_Click(object sender, EventArgs e) {
            this.fbdLocalDoArquivo.ShowNewFolderButton = false;
            this.fbdLocalDoArquivo.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdLocalDoArquivo.Description = "Selecione a pasta de destino do backup";
            if (this.fbdLocalDoArquivo.ShowDialog() == DialogResult.OK) {
                this.tbDestino.Text = fbdLocalDoArquivo.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            MessageBox.Show(Intelligence.removeName("c:\\aajaaj\\wwww\\ola.zip"));
        }
        
    }
}







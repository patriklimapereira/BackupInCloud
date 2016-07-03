using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using patrikDll;
using System.IO;


namespace patrikInstallFileSilentFull
{
    public partial class instalIcones : Form
    {
        public instalIcones()
        {
            InitializeComponent();
        }

        private void btnStartJobs_Click(object sender, EventArgs e)
        {
            String[] linhaInteira = WorkFile.readFileLines("", Util.IFSFFilePatrikFullManagerBackupService[0]);

            for (int i = 0; i < linhaInteira.Length; i++)
            {
                String[] linhaQuebrada = linhaInteira[i].Split(Util.psSeparator[1].ToCharArray());


                for (int j = 0; j < linhaQuebrada.Length; j++)
                {
                    if (Directory.Exists(linhaQuebrada[0]))
                    {
                        //  public static List<StringDatetime> getFileNameDateCreate(String sourceDirectory, int numberGetNameAndDatatime, bool ascendingIsTheQuestion, int typeSearchDateFile = 0, string extension = "*") {
                        List<StringDatetime> nameDateList = new List<StringDatetime>();

                        //     string[] nameFiles = Directory.GetFiles(sourceDirectory, extension);


                    }
                    else
                    {
                        MessageBox.Show("Existe um erro no arquivo\"" + Util.IFSFFilePatrikFullManagerBackupService[0] + "\" na linha n° " + i + 1 + ".", "Erro", MessageBoxButtons.OK);
                    }


                }
            }
        }
    }
}

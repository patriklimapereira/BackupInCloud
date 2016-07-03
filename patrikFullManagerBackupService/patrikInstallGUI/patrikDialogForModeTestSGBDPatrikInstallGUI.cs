using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patrikInstallGUI {
    public partial class patrikDialogForModeTestSGBDPatrikInstallGUI : Form {
        public patrikDialogForModeTestSGBDPatrikInstallGUI() {
            InitializeComponent();
        }

        private void BtnCopytoClipBoard_Click(object sender, EventArgs e) {
            Clipboard.SetText(rtbMsgErrorShowHere.Text);
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

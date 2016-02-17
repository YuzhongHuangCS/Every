using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Every {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }

        private void buttonAddRepo_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                listViewMain.Items.Add(dialog.SelectedPath);
            }
        }

        private void listViewMain_Click(object sender, EventArgs e) {
            ListViewItem current = listViewMain.SelectedItems[0];
        }
    }
}

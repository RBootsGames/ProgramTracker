using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public partial class Frm_EditBlacklist : Form
    {
        public Frm_EditBlacklist()
        {
            InitializeComponent();

            foreach (var item in Frm_Main.ProgSettings.IgnoreList)
            {
                listBox.Items.Add(item);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
                listBox.SetItemChecked(i, true);
        }

        private void btn_Deselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
                listBox.SetItemChecked(i, false);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int[] checks = listBox.CheckedIndices.Cast<int>().Reverse().ToArray();
            foreach (int item in checks)
            {
                listBox.Items.RemoveAt(item);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            List<string> list = listBox.Items.Cast<string>().ToList();
            Frm_Main.ProgSettings.IgnoreList = list;
            Frm_Main.ProgSettings.Save();
            Close();
        }
    }
}

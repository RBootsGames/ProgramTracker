using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public partial class Frm_AddProcess : Form
    {
        List<string> allProcs;
        List<string> selected = new List<string>();

        public Frm_AddProcess()
        {
            InitializeComponent();

            IEnumerable<Process> Ps = Process.GetProcesses();

            Ps = Ps.GroupBy(x => x.ProcessName).Select(x => x.First()).OrderBy(x => x.ProcessName);
            allProcs = Ps.Select(x => x.ProcessName).ToList();

            listBox.Items.AddRange(allProcs.ToArray());
        }

        void Search()
        {
            listBox.SelectedValueChanged -= listBox_SelectedValueChanged;

            var pruned = new List<string>();
            List<int> selectedIndices = new List<int>();
            int i = 0;

            foreach (string name in allProcs)
            {
                if (name.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    pruned.Add(name);
                    if (selected.Contains(name))
                        selectedIndices.Add(i);

                    i++;
                }
            }

            listBox.Items.Clear();
            listBox.Items.AddRange(pruned.ToArray());
            foreach (var index in selectedIndices)
            {
                listBox.SetItemChecked(index, true);
            }

            listBox.SelectedValueChanged += listBox_SelectedValueChanged;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var selection = listBox.SelectedItem;
            var index = listBox.SelectedIndex;

            if (listBox.GetItemChecked(index))
            {
                selected.Add(selection.ToString());
            }
            else
                selected.Remove(selection.ToString());
        }

        private void btn_Deselect_Click(object sender, EventArgs e)
        {
            listBox.SelectedValueChanged -= listBox_SelectedValueChanged;

            selected.Clear();
            for (int i = 0; i < listBox.Items.Count; i++)
                listBox.SetItemChecked(i, false);

            listBox.ClearSelected();
            listBox.SelectedValueChanged += listBox_SelectedValueChanged;
        }

        private void btn_AddSelection_Click(object sender, EventArgs e)
        {
            foreach (var p in selected)
            {
                if (!Frm_Main.ProgSettings.WhitelistProcesses.Contains(p) &&
                    !Frm_Main.MasterTracker.ProcessTrackers.ContainsKey(p))
                    Frm_Main.ProgSettings.WhitelistProcesses.Add(p);

            }
            Frm_Main.ProgSettings.Save();
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

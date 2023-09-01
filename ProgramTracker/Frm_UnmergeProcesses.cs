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
    public partial class Frm_UnmergeProcesses : Form
    {
        public Frm_UnmergeProcesses()
        {
            InitializeComponent();

            foreach (var merges in Frm_Main.ProgSettings.AlternateProcessNames)
            {
                Ctrl_UnmergeTemplate ctrl = new Ctrl_UnmergeTemplate(merges.Key, merges.Value.ToArray());
                pnl_Main.Controls.Add(ctrl);
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            foreach (var item in pnl_Main.Controls.OfType<Ctrl_UnmergeTemplate>())
            {
                List<string> removers = item.GetSelectedItems();

                if (removers.Count > 0)
                {
                    //List<string> children = Frm_Main.ProgSettings.AlternateProcessNames[item.MasterProcessName];
                    foreach (var rem in removers)
                    {
                        Frm_Main.MasterTracker.ProcessTrackers[item.MasterProcessName].RemoveAlternateProcessName(rem);
                        //children.Remove(rem);
                    }
                }
            }

            //Frm_Main.ProgSettings.Save();
            Close();
        }
    }
}

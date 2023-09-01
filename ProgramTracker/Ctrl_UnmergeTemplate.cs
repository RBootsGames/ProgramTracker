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
    public partial class Ctrl_UnmergeTemplate : UserControl
    {
        string l_MasterProcessName = "";

        [Category("User Controls")]
        public string MasterProcessName
        {
            get => l_MasterProcessName;
            set
            {
                l_MasterProcessName = value;
                lbl_Title.Text = "Master: " + value;
            }
        }

        public Ctrl_UnmergeTemplate(string masterProcessName, params string[] childProcesses)
        {
            InitializeComponent();

            MasterProcessName = masterProcessName;
            processList.Items.AddRange(childProcesses);
        }

        public List<string> GetSelectedItems()
        {
            List<string> list = new List<string>();
            foreach (var item in processList.SelectedItems.Cast<string>())
            {
                list.Add(item);
            }

            return list;
        }
    }
}

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
    public partial class Frm_MergeProcesses : Form
    {
        MasterTrackerClass TrackingData;
        Dictionary<string, Tracker> keyValuePairs = new Dictionary<string, Tracker>();

        internal Frm_MergeProcesses(MasterTrackerClass trackingData)
        {
            TrackingData = trackingData;
            InitializeComponent();

            list_Mergers.Enabled = false;

            List<string> allProcs = TrackingData.ProcessTrackers.Values
                // avoids dupes with alt processes
                    .GroupBy(x => x.ProcessName).Select(y => y.First())
                    .Select(x =>
                    {
                        string text = GetKey(x);
                        keyValuePairs[text] = x;

                        return text;

                    }).OrderBy(x => x).ToList();

            list_Master.Items.AddRange(allProcs.ToArray());
            list_Mergers.Items.AddRange(allProcs.ToArray());

            list_Master.SelectedIndexChanged += list_Master_SelectedIndexChanged;
        }

        private string GetKey(Tracker tracker)
        {
            string text = tracker.GetDisplayName();
            if (!string.IsNullOrEmpty(text))
                text += $" ({tracker.ProcessName})";
            else
                text = tracker.ProcessName;

            return text;
        }

        void MergeTrackingData(Tracker master, params Tracker[] mergers)
        {
            foreach (Tracker track in mergers)
            {
                master.MergeTracker(track);
                Frm_Main.MainForm.DeleteProcessItem(track, true);
            }
        }


        private void list_Master_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < list_Mergers.Items.Count; i++)
            {
                string item = list_Mergers.Items[i].ToString();
                if (item == list_Master.SelectedItem.ToString())
                {
                    list_Mergers.SetItemChecked(i, false);
                }
            }

            list_Mergers.Enabled = true;

            if (list_Mergers.CheckedIndices.Count > 0)
            {
                btn_OneTime.Enabled = true;
                btn_Permanent.Enabled = true;
            }
            else
            {
                btn_OneTime.Enabled = false;
                btn_Permanent.Enabled = false;
            }
        }

        /// <summary>percentage between left and right</summary>
        float splitterPos = .6f;
        private void Frm_MergeProcesses_ResizeBegin(object sender, EventArgs e)
        {
            //splitterPos = (float)Width / splitter1.Location.X;
            splitterPos = pnl_Left.Width / (float)Width;
            Console.WriteLine("resizing");
        }

        private void Frm_MergeProcesses_ClientSizeChanged(object sender, EventArgs e)
        {
            pnl_Left.Width = (int)(Width * splitterPos);
        }

        private void btn_OneTime_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"This will merge all existing data into '{keyValuePairs[list_Master.SelectedItem.ToString()].GetVisibleName()}'.\n" +
                $"You cannot undo this. Are you sure?",
                "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var mergers = list_Mergers.CheckedItems.OfType<string>()
                             .Select(x => keyValuePairs[x]);

                MergeTrackingData(keyValuePairs[list_Master.SelectedItem.ToString()], mergers.ToArray());
                Close();
            }
        }

        private void btn_Permanent_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"This will merge all existing data and future data into " +
                $"'{keyValuePairs[list_Master.SelectedItem.ToString()].GetVisibleName()}'.\n" +
                $"You cannot undo this. Are you sure?",
                "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var mergers = list_Mergers.CheckedItems.OfType<string>()
                             .Select(x => keyValuePairs[x]);

                MergeTrackingData(keyValuePairs[list_Master.SelectedItem.ToString()], mergers.ToArray());
                foreach (Tracker item in mergers)
                {
                    keyValuePairs[list_Master.SelectedItem.ToString()].AddAlternateProcessName(item.ProcessName);
                }

                Close();
            }
        }
    }
}

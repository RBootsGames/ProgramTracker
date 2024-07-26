using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public partial class Frm_ExportTrackers : Form
    {
        Tracker[] Selection;
        bool UseMasterDateFilter = true;

        public Frm_ExportTrackers(params Tracker[] selectedTrackers)
        {
            InitializeComponent();

            Selection = selectedTrackers;

            foreach (Tracker tracker in Selection)
            {
                Ctrl_ExportControl ctrl = new Ctrl_ExportControl(tracker);
                ctrl.SetDateTimeEnabled(false);
                pnl_Trackers.Controls.Add(ctrl);

                if (tracker.GetOldestDate() < dtp_Start.Value)
                    dtp_Start.Value = tracker.GetOldestDate();
                if (tracker.GetNewestDate() > dtp_End.Value)
                    dtp_End.Value = tracker.GetNewestDate().Value;
            }
        }

        private void btn_ToggleDateFilter_Click(object sender, EventArgs e)
        {
            UseMasterDateFilter = !UseMasterDateFilter;



            foreach (Ctrl_ExportControl ctrl in pnl_Trackers.Controls.OfType<Ctrl_ExportControl>())
            {
                ctrl.SetDateTimeEnabled(!UseMasterDateFilter);
            }

            dtp_Start.Enabled = UseMasterDateFilter;
            dtp_End.Enabled = UseMasterDateFilter;

            btn_ToggleDateFilter.Text = (UseMasterDateFilter) ? "Use Individual\nDate Filter" : "Use Master\nDate Filter";
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // get trackers that aren't excluded
                var exporters = pnl_Trackers.Controls.OfType<Ctrl_ExportControl>().Where(x => !x.ExcludeFromExport);

                if (!exporters.Any())
                {
                    MessageBox.Show("No data exported.");
                    Close();
                    return;
                }

                MasterTrackerClass tempMaster = new MasterTrackerClass();

                // loop trackers
                foreach (Ctrl_ExportControl track in exporters)
                {
                    // define date range
                    DateTime start = (UseMasterDateFilter) ? dtp_Start.Value : track.GetStartTime();
                    DateTime end = (UseMasterDateFilter) ? dtp_End.Value : track.GetEndTime();

                    var withinRange = track.GetParentTracker().GetDatesWithinRange(start, end);
                    if (withinRange.Count == 0)
                        continue;

                    Tracker tempTracker = new Tracker()
                    {
                        ProcessName = track.GetParentTracker().ProcessName,
                        TimeMarkers = withinRange
                    };
                    tempMaster.ProcessTrackers[tempTracker.ProcessName] = tempTracker;
                }

                tempMaster.Save(Path.GetDirectoryName(saveFileDialog1.FileName),
                                fileNameOverride:Path.GetFileName(saveFileDialog1.FileName));

                Close();
            }
        }
    }
}

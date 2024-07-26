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
    public partial class Frm_SetTimeRange : Form
    {
        public DialogResult Response = DialogResult.Cancel;

        public bool UseStartDate
        {
            get => chbx_UseStartDate.Checked;
            set => chbx_UseStartDate.Checked = value;
        }
        public bool UseEndDate
        {
            get => chbx_UseEndDate.Checked;
            set => chbx_UseEndDate.Checked = value;
        }
        public bool ShowFilteredOut
        {
            get => chbx_ShowFilteredOut.Checked;
            set => chbx_ShowFilteredOut.Checked = value;
        }

        public DateTime StartDate
        {
            get
            {
                return new DateTime
                (
                    dt_StartDate.Value.Year,
                    dt_StartDate.Value.Month,
                    dt_StartDate.Value.Day,
                    dt_StartTime.Value.Hour,
                    dt_StartTime.Value.Minute,
                    0
                );
            }
            set
            {
                dt_StartDate.Value = value;
                dt_StartTime.Value = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return new DateTime
                (
                    dt_EndDate.Value.Year,
                    dt_EndDate.Value.Month,
                    dt_EndDate.Value.Day,
                    dt_EndTime.Value.Hour,
                    dt_EndTime.Value.Minute,
                    0
                );
            }
            set
            {
                dt_EndDate.Value = value;
                dt_EndTime.Value = value;
            }
        }

        public Frm_SetTimeRange(Settings settings = null)
        {
            InitializeComponent();
            toolTip1.SetToolTip(chbx_ShowFilteredOut, "If a time entry or program falls outside the time filtered, it will still be showed.");

            if (settings != null)
            {
                UseStartDate = settings.UseFilterDateStart;
                UseEndDate = settings.UseFilterDateEnd;
                ShowFilteredOut = settings.ShowFilteredOutDateEntries;

                // no start date has been set, so get oldest date available
                try
                {
                    DateTime old = Frm_Main.MasterTracker.GetOldestDate();
                    StartDate = (settings.FilterDateStart == DateTimePicker.MinimumDateTime) ? old : settings.FilterDateStart;
                    if (StartDate < old)
                        StartDate = old;
                }
                catch // this could cause issues if there is no oldest date
                {
                    StartDate = DateTimePicker.MinimumDateTime;
                }

                EndDate = settings.FilterDateEnd;
            }
            else
            {
                StartDate = Frm_Main.MasterTracker.GetOldestDate();
                EndDate = DateTimePicker.MaximumDateTime;
            }

            // force updating controls if these are set to false
            chbx_UseStartDate_CheckedChanged(null, null);
            chbx_UseEndDate_CheckedChanged(null, null);
        }

        private void chbx_UseEndDate_CheckedChanged(object sender, EventArgs e)
        {
            dt_EndDate.Enabled = UseEndDate;
            dt_EndTime.Enabled = UseEndDate;
        }

        private void chbx_UseStartDate_CheckedChanged(object sender, EventArgs e)
        {
            dt_StartDate.Enabled = UseStartDate;
            dt_StartTime.Enabled = UseStartDate;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            Response = DialogResult.OK;
            Close();
        }
    }
}

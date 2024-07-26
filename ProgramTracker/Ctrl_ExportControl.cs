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
    public partial class Ctrl_ExportControl : UserControl
    {
        public bool ExcludeFromExport
        {
            get => cbx_Exclude.Checked;
            set => cbx_Exclude.Checked = value;
        }

        Tracker ParentTracker { get; } = null;

        /// <summary>
        /// Don't use this one.
        /// </summary>
        public Ctrl_ExportControl()
        {
            InitializeComponent();
        }

        public Ctrl_ExportControl(Tracker trackingData)
        {
            InitializeComponent();
            Dock = DockStyle.Top;

            ParentTracker = trackingData;

            lbl_ProcessName.Text = trackingData.GetVisibleName();
            dtp_Start.Value = trackingData.GetOldestDate();
            DateTime? end = trackingData.GetNewestDate(true);

            // if process is still running, use second to last item
            if (end.HasValue)
                dtp_End.Value = end.Value;
            else
                dtp_End.Value = trackingData.TimeMarkers[trackingData.TimeMarkers.Count - 2].StopTime.Value;
        }

        public void SetDateTimeEnabled(bool enabled)
        {
            dtp_Start.Enabled = enabled;
            dtp_End.Enabled = enabled;
        }

        public Tracker GetParentTracker() => ParentTracker;
        public DateTime GetStartTime() => dtp_Start.Value;
        public DateTime GetEndTime() => dtp_End.Value;
    }
}

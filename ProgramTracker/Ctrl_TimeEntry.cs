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
    public partial class Ctrl_TimeEntry : UserControl
    {
        DateTime? l_StartTime = null;
        DateTime? l_EndTime = null;
        TimeSpan l_Duration = TimeSpan.Zero;
        TrackingPoint trackingPoint;
        bool l_IsMostRecent = false;

        public bool IsMostRecent
        {
            get => l_IsMostRecent;
            set
            {
                l_IsMostRecent = value;
            }
        }

        [Category("Control Variables")]
        public DateTime? StartTime
        {
            get => l_StartTime;
            set
            {
                l_StartTime = value;
                if (l_StartTime != null)
                    //lbl_Start.Text = ((DateTime)(l_StartTime)).ToString("   MM/dd/yyyy h:mm:ss tt");
                    lbl_Start.Text = ((DateTime)(l_StartTime)).ToString("h:mm:ss tt");
                else
                    lbl_Start.Text = "";

                CalculateDuration();
            }
        }


        [Category("Control Variables")]
        public DateTime? EndTime
        {
            get => l_EndTime;
            set
            {
                l_EndTime = value;

                CalculateDuration();
            }
        }

        internal Ctrl_TimeEntry(TrackingPoint point)
        {
            InitializeComponent();
            Dock = DockStyle.Top;

            trackingPoint = point;
            StartTime = trackingPoint.StartTime;
            EndTime = trackingPoint.StopTime;
        }

        internal TrackingPoint GetTrackingPoint() => trackingPoint;


        public void CalculateDuration()
        {
            if (l_StartTime == null)
            {
                l_Duration = TimeSpan.Zero;
                lbl_Duration.Text = "";
            }
            else
            {
                lbl_Duration.Text = trackingPoint.GetDuration(true).DurationToString(true);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            set =>l_IsMostRecent = value;
        }

        [Category("Control Variables")]
        public DateTime? StartTime
        {
            get => l_StartTime;
            set
            {
                bool wasUpdated = !l_StartTime.Equals(value);
                l_StartTime = value;
                
                if (l_StartTime != null)
                    lbl_Start.Text = ((DateTime)(l_StartTime)).ToString("h:mm:ss tt");
                else
                    lbl_Start.Text = "";

                if (wasUpdated)
                    OnStartStopUpdated(EventArgs.Empty);

                CalculateDuration(true);
            }
        }


        [Category("Control Variables")]
        public DateTime? EndTime
        {
            get => l_EndTime;
            set
            {
                bool wasUpdated = !l_EndTime.Equals(value);
                l_EndTime = value;

                if (wasUpdated)
                    OnStartStopUpdated(EventArgs.Empty);

                CalculateDuration(true);
            }
        }


        [Category("Property Changed"), Description("This is called whenever the tracking point's start or stop times are updated.")]
        public EventHandler StartStopUpdated;

        [Category("Property Changed")]
        public EventHandler TimeEntriesMerged;

        protected virtual void OnStartStopUpdated(EventArgs e)
        {
            StartStopUpdated?.Invoke(this, e);
        }

        private void OnMergeAction(EventArgs e)
        {
            TimeEntriesMerged?.Invoke(this, e);
        }


        internal Ctrl_TimeEntry(TrackingPoint point)
        {
            InitializeComponent();
            Dock = DockStyle.Top;

            point.SetTimeEntryControl(this);
            trackingPoint = point;
            ApplyTimeUpdates();
        }

        void ApplyTimeUpdates(bool alsoReorder=false)
        {
            // I'm using this to get around the event being run on both time edits
            bool wasUpdated = !l_StartTime.Equals(trackingPoint.StartTime) ||
                              !l_EndTime.Equals(trackingPoint.StopTime);

            l_StartTime = trackingPoint.StartTime;
            l_EndTime = trackingPoint.StopTime;

            // Some code still needs to be executed from the setter
            StartTime = trackingPoint.StartTime;
            EndTime = trackingPoint.StopTime;

            if (alsoReorder)
            {
                Ctrl_TrackingInfoPage parent = this.GetParentOfType<Ctrl_TrackingInfoPage>();

                parent.ReorderTimeEntries(this);
            }

            if (wasUpdated)
                OnStartStopUpdated(EventArgs.Empty);
        }

        internal TrackingPoint GetTrackingPoint() => trackingPoint;


        public TimeSpan GetDuration() => l_Duration;

        public void CalculateDuration(bool calledFromEvent=false)
        {
            if (l_StartTime == null)
            {
                l_Duration = TimeSpan.Zero;
                lbl_Duration.Text = "";
            }
            else
            {
                l_Duration = trackingPoint.GetDuration(true, true);
                lbl_Duration.Text = l_Duration.DurationToString(true);

                // This should only be used to update the header of this collapsible control
                if (!calledFromEvent && trackingPoint.StopTime == null)
                {
                    OnStartStopUpdated(EventArgs.Empty);
                }
            }
        }

        private void EditForm_Closed(object sender, EventArgs e)
        {
            Frm_EditTimeEntry ctrl = sender as Frm_EditTimeEntry;

            if (ctrl.DialogResult != DialogResult.OK)
                return;

            var updated = ctrl.GetUpdatedTrackingData();
            trackingPoint.StartTime = updated.StartTime;
            trackingPoint.StopTime = (trackingPoint.IsRunning) ? null : updated.StopTime;
            ApplyTimeUpdates(true);

            if (ctrl.DidMergeHappen())
                OnMergeAction(EventArgs.Empty);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            
            Frm_EditTimeEntry popup = new Frm_EditTimeEntry(trackingPoint);
            Point here = MousePosition;
            Screen currentDisplay = Screen.FromPoint(here);
            here.Y -= popup.Height / 2;
            if (here.X + popup.Width > currentDisplay.Bounds.Right)
                here.X -= (here.X + popup.Width) - currentDisplay.Bounds.Right;

            popup.FormClosed += EditForm_Closed;
            popup.Show();
            popup.Location = here;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this time entry?", "Remove entry?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Tracker parentTracker = Frm_Main.MasterTracker.ProcessTrackers[trackingPoint.ParentTracker.ProcessName];
            parentTracker.TimeMarkers.Remove(trackingPoint);
            this.GetParentOfType<Ctrl_CollapsibleTimeEntries>().RemoveControl(trackingPoint);
        }
    }
}

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
    public partial class Ctrl_CollapsibleTimeEntries : UserControl
    {
        bool l_IsGrayedOut = false;
        TimeSpan l_Duration;
        DateTime l_DateOfEntries;
        bool isMouseOver = false;
        bool isCollapsed = false;
        bool hasLatestEntry = false;
        bool dataAlreadyLoaded = false;
        List<TrackingPoint> trackingPoints = new List<TrackingPoint>();

        public DateTime DateOfEntries
        {
            get => l_DateOfEntries;
            set
            {
                l_DateOfEntries = value;
                lbl_StartDate.Text = l_DateOfEntries.ToString("MM/dd/yyyy");
            }
        }

        public bool IsGrayedOut
        {
            get => l_IsGrayedOut;
            set
            {
                l_IsGrayedOut = value;
                ApplyBGColor();
            }
        }
        //internal Tracker TrackingData;

        //[Category("Item Settings")]
        //public DateTime


        [Category("Action")]
        public event EventHandler ControlClick;

        [Category("Property Changed")]
        public event EventHandler TrackingPointUpdated;


        internal Ctrl_CollapsibleTimeEntries(List<TrackingPoint> entries, bool latestEntry=false, bool startCollapsed=true)
        {
            InitializeComponent();
            BackColor = DefaultBackColor;
            Dock = DockStyle.Top;
            //lbl_StartDate.Text = entries.First().StartTime.Date.ToString("MM/dd/yyyy");
            DateOfEntries = entries.First().StartTime.Date;

            l_Duration = TrackingPoint.GetDuration(entries.ToArray());
            lbl_Duration.Text = l_Duration.DurationToString(true);

            trackingPoints = entries;
            hasLatestEntry = latestEntry;


            if (!startCollapsed)
                ExpandControl();
            else
                CollapseControl();
        }

        void PopulateData()
        {
            var tempList = trackingPoints.Select(x => new Ctrl_TimeEntry(x)).ToArray();
            if (hasLatestEntry)
                tempList.LastOrDefault().IsMostRecent = true;

            foreach (var entryCtrl in tempList)
            {
                entryCtrl.TimeEntriesMerged += OnTimeEntryMerged;
                entryCtrl.StartStopUpdated += OnEntryUpdated;

                if (entryCtrl.GetDuration() == TimeSpan.Zero)
                {
                    entryCtrl.BackColor = Color.Gainsboro;
                }
            }

            pnl_Contents.Controls.AddRange(tempList);

            //foreach (var item in tempList)

            dataAlreadyLoaded = true;
        }

        public Ctrl_TimeEntry GetMostRecentEntry() => pnl_Contents.Controls.OfType<Ctrl_TimeEntry>().LastOrDefault();

        private List<Ctrl_TimeEntry> GetTimeEntryControls() => pnl_Contents.Controls.OfType<Ctrl_TimeEntry>().ToList();


        public TimeSpan GetDuration() => l_Duration;

        private void ReCalculateDuration()
        {
            this.UpdateOnThread(() =>
            {
                l_Duration = TrackingPoint.GetDuration(trackingPoints.ToArray());
                lbl_Duration.Text = l_Duration.DurationToString(true);

                //lbl_Duration.Text = TrackingPoint.GetDuration(trackingPoints.ToArray()).DurationToString(true);
            });
            this.GetParentOfType<Ctrl_TrackingInfoPage>().UpdateTimeDuration();
        }

        public void OrderControls()
        {
            List<Ctrl_TimeEntry> ordered = GetTimeEntryControls().OrderBy(x => x.StartTime).Reverse().ToList();

            foreach (Ctrl_TimeEntry item in ordered)
                pnl_Contents.Controls.SetChildIndex(item, 0);
        }

        /// <summary>
        /// This just removes the control associated with this tracking point.
        /// </summary>
        internal void RemoveControl(TrackingPoint existingEntry)
        {
            Ctrl_TrackingInfoPage parent = this.GetParentOfType<Ctrl_TrackingInfoPage>();
            Point scrollPoint = parent.pnl_Main.AutoScrollPosition;

            if (!dataAlreadyLoaded)
                trackingPoints.Remove(existingEntry);
            else
            {
                trackingPoints.Remove(existingEntry);
                Ctrl_TimeEntry obj = GetTimeEntryControls().Where(x => x.GetTrackingPoint().Equals(existingEntry)).FirstOrDefault();
                if (obj != null)
                {
                    obj.TimeEntriesMerged -= OnTimeEntryMerged;
                    obj.StartStopUpdated -= OnEntryUpdated;
                    pnl_Contents.SuspendLayout();
                    pnl_Contents.Controls.Remove(obj);

                    obj.Dispose();
                    if (!isCollapsed)
                        ExpandControl();

                    pnl_Contents.ResumeLayout();
                    parent.pnl_Main.AutoScrollPosition = new Point(Math.Abs(scrollPoint.X), Math.Abs(scrollPoint.Y));
                }
            }

            ReCalculateDuration();
         
            if (trackingPoints.Count == 0)
                this.Dispose();
        }

        internal void AddControl(TrackingPoint newEntry)
        {
            if (!dataAlreadyLoaded)
            {
                trackingPoints.Add(newEntry);
                trackingPoints = trackingPoints.OrderBy(x => x.StartTime).ToList();
            }
            else
            {
                trackingPoints.Add(newEntry);
                trackingPoints = trackingPoints.OrderBy(x => x.StartTime).ToList();

                Ctrl_TimeEntry obj = new Ctrl_TimeEntry(newEntry);
                obj.TimeEntriesMerged += OnTimeEntryMerged;
                obj.StartStopUpdated += OnEntryUpdated;
                pnl_Contents.Controls.Add(obj);

                OrderControls();
                if (!isCollapsed)
                    ExpandControl();
            }
        }

        public void CollapseControl()
        {
            isCollapsed = true;

            pnl_Contents.Visible = false;
            Height = tableLayoutPanel1.Height;
        }

        public void ExpandControl()
        {
            isCollapsed = false;

            if (!dataAlreadyLoaded)
                PopulateData();

            pnl_Contents.Visible = true;
            int finalHeight = tableLayoutPanel1.Height + 3;
            foreach (var item in pnl_Contents.Controls.OfType<Control>())
            {
                finalHeight += item.Height;
            }
            Height = finalHeight;
        }

        private void ApplyBGColor()
        {
            if (isMouseOver)
                BackColor = Color.LightGray;
            else
                BackColor = DefaultBackColor;

            if (IsGrayedOut)
            {
                Color c = BackColor;
                BackColor = Color.FromArgb(
                    (int)(c.R * .9),
                    (int)(c.G * .9),
                    (int)(c.B * .9));
            }
        }

        
        private void ButtonMouseEnter(object sender, EventArgs e)
        {
            isMouseOver = true;
            ApplyBGColor();
        }
        
        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            isMouseOver = false;
            ApplyBGColor();
        }

        private void ControlClickEvent(object sender, EventArgs e)
        {
            isCollapsed = !isCollapsed;

            if (isCollapsed)
                CollapseControl();
            else
                ExpandControl();

            if (ControlClick != null)
                ControlClick(this, e);
        }


        void OnEntryUpdated(object sender, EventArgs e)
        {
            Ctrl_TimeEntry ctrl = (Ctrl_TimeEntry)sender;
            Ctrl_TrackingInfoPage parent = this.GetParentOfType<Ctrl_TrackingInfoPage>();
            //Ctrl_TrackingInfoPage parent = (Ctrl_TrackingInfoPage)this.Parent.Parent;


            //parent.UpdateTimeDuration(this, ctrl);
            //
            //


            ReCalculateDuration();

            TrackingPointUpdated?.Invoke(sender, e);
        }

        void OnTimeEntryMerged(object sender, EventArgs e)
        {
            var updated = (Ctrl_TimeEntry)sender;

            if (updated.StartTime?.Date == DateOfEntries.Date)
            {
                ExpandControl();
            }
        }
    }
}

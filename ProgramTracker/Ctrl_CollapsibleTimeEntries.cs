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
        bool isMouseOver = false;
        bool isCollapsed = false;
        bool hasLatestEntry = false;
        bool dataAlreadyLoaded = false;
        List<TrackingPoint> trackingPoints = new List<TrackingPoint>();

        //internal Tracker TrackingData;

        //[Category("Item Settings")]
        //public DateTime


        [Category("Action")]
        public event EventHandler ControlClick;


        //internal Ctrl_CollapsibleTimeEntries(DateTime startRange, Tracker trackingData, DateTime? endRange=null, bool collapsed=false)
        internal Ctrl_CollapsibleTimeEntries(TrackingPoint singleEntry, bool latestEntry = false, bool startCollapsed = true)
                                      : this(new List<TrackingPoint>() { singleEntry }, latestEntry, startCollapsed) { }
        internal Ctrl_CollapsibleTimeEntries(List<TrackingPoint> entries, bool latestEntry=false, bool startCollapsed=true)
        {
            InitializeComponent();
            BackColor = DefaultBackColor;
            Dock = DockStyle.Top;
            lbl_StartDate.Text = entries.First().StartTime.Date.ToString("MM/dd/yyyy");

            lbl_Duration.Text = TrackingPoint.GetDuration(entries.ToArray()).DurationToString(true);

            trackingPoints = entries;
            hasLatestEntry = latestEntry;

            //var tempList = new List<Ctrl_TimeEntry>();
            //var tempList = trackingPoints.Select(x => new Ctrl_TimeEntry(x));
            //if (hasLatestEntry)
            //    tempList.LastOrDefault().IsMostRecent = true;

            //pnl_Contents.Controls.AddRange(tempList.ToArray());

            if (!startCollapsed)
                ExpandControl();
            else
                CollapseControl();
            //l_StartRange = startRange;
            //l_EndRange = endRange;
            //TrackingData = trackingData;
            //isCollapsed = collapsed;
        }

        void PopulateData()
        {
            var tempList = trackingPoints.Select(x => new Ctrl_TimeEntry(x));
            if (hasLatestEntry)
                tempList.LastOrDefault().IsMostRecent = true;

            pnl_Contents.Controls.AddRange(tempList.ToArray());
            dataAlreadyLoaded = true;
        }

        public Ctrl_TimeEntry GetMostRecentEntry() => pnl_Contents.Controls.OfType<Ctrl_TimeEntry>().LastOrDefault();

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
            int finalHeight = tableLayoutPanel1.Height;
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
    }
}

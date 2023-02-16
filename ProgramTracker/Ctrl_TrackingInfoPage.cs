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
    public partial class Ctrl_TrackingInfoPage : UserControl
    {
        Tracker TrackingData;
        Ctrl_TimeEntry l_MostRecent = null;

        public bool IsRunning => TrackingData.IsRunning;


        internal Ctrl_TrackingInfoPage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        string FormatTimeSpan(TimeSpan ts)
        {
            //ts = ts.Add(TimeSpan.FromDays(4));
            string text = "";
            if (ts.Days > 0)
                text += $"{ts.Days} d  ";
            text += $"{ts.Hours.ToString("00")} h {ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")} min";
            return text;
        }

        internal void LoadData(Tracker trackingData)
        {
            TrackingData = trackingData;

            lbl_Title.Text = TrackingData.GetVisibleName();
            pict_Icon.Image = TrackingData.GetFormControl().Icon;
            lbl_Duration.Text = FormatTimeSpan(TrackingData.GetDuration());

            
            //var tempList = new List<Ctrl_TimeEntry>();
            //var groupedTimeEntries = new List<List<TrackingPoint>>();
            var groupedTimeEntries = new List<Ctrl_CollapsibleTimeEntries>();

            DateTime currentDateRange = TrackingData.TimeMarkers.First().StartTime.Date;
            var tempTimeEntries = new List<TrackingPoint>();
            bool firstDateInRange = true;

            foreach (TrackingPoint point in TrackingData.TimeMarkers)
            {
                if (point.StartTime.Date == currentDateRange && point != TrackingData.TimeMarkers.Last())
                {
                    tempTimeEntries.Add(point);
                    firstDateInRange = false;
                }
                else
                {
                    firstDateInRange = point.StartTime.Date != currentDateRange;

                    if (point == TrackingData.TimeMarkers.Last())
                    {
                        if (firstDateInRange)
                        {
                            groupedTimeEntries.Add(new Ctrl_CollapsibleTimeEntries(new List<TrackingPoint>(tempTimeEntries), false, true));
                            tempTimeEntries.Clear();
                        }

                        tempTimeEntries.Add(point);
                        var meh = new Ctrl_CollapsibleTimeEntries(new List<TrackingPoint>(tempTimeEntries), true, false);
                        groupedTimeEntries.Add(meh);
                        l_MostRecent = meh.GetMostRecentEntry();
                        TrackingData.SetMostRecentEntry(meh.GetMostRecentEntry());
                        
                    }
                    else
                    {
                        groupedTimeEntries.Add(new Ctrl_CollapsibleTimeEntries(new List<TrackingPoint>(tempTimeEntries), false, true));

                        tempTimeEntries.Clear();
                        firstDateInRange = true;
                        tempTimeEntries.Add(point);
                        currentDateRange = point.StartTime.Date;
                    }


                }
            }

            pnl_Main.Controls.Clear();

            //Ctrl_CollapsibleTimeEntries bleh = new Ctrl_CollapsibleTimeEntries(tempList.ToArray());

            pnl_Main.Controls.AddRange(groupedTimeEntries.ToArray());
            //pnl_Main.Controls.AddRange(tempList.ToArray());

        }

        public Ctrl_TimeEntry GetMostRecentEntry() => l_MostRecent;

        public void UpdateTime()
        {
            if (lbl_Duration.InvokeRequired)
            {
                lbl_Duration.Invoke(new MethodInvoker(UpdateTime));
                return;
            }
            lbl_Duration.Text = FormatTimeSpan(TrackingData.GetDuration());
        }

        public void AddNewEntry()
        {
            TrackingPoint latestPoint = TrackingData.TimeMarkers.Last();
            Console.WriteLine(l_MostRecent.GetTrackingPoint() == latestPoint);
            if (l_MostRecent.GetTrackingPoint() == latestPoint)
                return;

            Ctrl_TimeEntry newest = new Ctrl_TimeEntry(latestPoint);
            newest.IsMostRecent = true;
            l_MostRecent.IsMostRecent = false;
            TrackingData.SetMostRecentEntry(newest);
            pnl_Main.UpdateOnThread(() => { pnl_Main.Controls.Add(newest); });
            

            l_MostRecent = newest;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //Frm_Main.MainForm.pnl_TrackedProgs.Visible = true;
            TrackingData.GetFormControl().IsSelected = false;
            var scrollPoint = Frm_Main.MainForm.pnl_TrackedProgs.AutoScrollPosition;
            this.Visible = false;
            //this.Dispose();
            Frm_Main.MainForm.MakeItemListFullscreen(scrollPoint);
        }
    }
}

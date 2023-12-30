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
        Ctrl_TimeEntry l_MostRecent = null;
        Tracker TrackingData;
        SortedDictionary<DateTime, List<TrackingPoint>> GroupedPoints = new SortedDictionary<DateTime, List<TrackingPoint>>();

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

        internal void ReloadData() => LoadData(TrackingData);
        internal void LoadData(Tracker trackingData)
        {
            pnl_Main.Controls.Clear();

            TrackingData = trackingData;

            lbl_Title.Text = TrackingData.GetVisibleName();
            pict_Icon.Image = TrackingData.GetFormControl().Icon;
            lbl_Duration.Text = FormatTimeSpan(TrackingData.GetDuration());



            //var groupedByDays = TrackingData.TimeMarkers.GroupBy(x => x.StartTime.Date).Reverse().ToList();
            GroupedPoints.Clear();
            GroupedPoints = new SortedDictionary<DateTime, List<TrackingPoint>>(
                    TrackingData.TimeMarkers.Where(x =>
                    {
                        return Frm_Main.ProgSettings.ShowFilteredOutDateEntries || !x.IsFilteredOut;
                    })
                    .GroupBy(x => x.StartTime.Date).ToDictionary(x => x.Key, x => x.ToList())
                );


            var groupedTimeEntries = new List<Ctrl_CollapsibleTimeEntries>();

            bool isFirst = true;
            var allKeys = GroupedPoints.Keys.ToList();
            for (int i = allKeys.Count - 1; i >= 0; i--)
            {
                DateTime key = allKeys[i];
                var ctrl = new Ctrl_CollapsibleTimeEntries(new List<TrackingPoint>(GroupedPoints[key]), isFirst, !isFirst);

                groupedTimeEntries.Add(ctrl);
                ctrl.IsGrayedOut = ctrl.GetDuration() == TimeSpan.Zero;

                if (isFirst)
                {
                    l_MostRecent = ctrl.GetMostRecentEntry();
                    TrackingData.SetMostRecentEntry(ctrl.GetMostRecentEntry());
                }
                isFirst = false;
            }
            groupedTimeEntries.Reverse();




            pnl_Main.Controls.AddRange(groupedTimeEntries.ToArray());

            TrackingData.ItemUpdated += OnTrackerUpdated;
        }

        public void SetIcon(Bitmap icon)
        {
            pict_Icon.Image = icon;
        }

        public void SetTitle(string title)
        {
            lbl_Title.Text = title;
        }

        public Ctrl_TimeEntry GetMostRecentEntry() => l_MostRecent;

        void ReorderCollapsibleTimeEntries()
        {
            var ordered = pnl_Main.Controls.OfType<Ctrl_CollapsibleTimeEntries>().OrderByDescending(x => x.DateOfEntries);

            foreach (var item in ordered)
                pnl_Main.Controls.SetChildIndex(item, 0);
        }
        public void ReorderTimeEntries(Ctrl_TimeEntry updatedControl)
        {
            Ctrl_CollapsibleTimeEntries controlsParent = updatedControl.GetParentOfType<Ctrl_CollapsibleTimeEntries>();
            //Ctrl_CollapsibleTimeEntries controlsParent = (Ctrl_CollapsibleTimeEntries)updatedControl.Parent.Parent;

            // move time entry controls if they need to be
            TrackingPoint tp = updatedControl.GetTrackingPoint();
            if (tp.StartTime.Date.Equals(controlsParent.DateOfEntries)) // remains in same date
            {
                Console.WriteLine("garbage");
                controlsParent.OrderControls();
                // apply order to dictionary item
                List<TrackingPoint> ordered = GroupedPoints[tp.StartTime.Date].OrderBy(x => x.StartTime).ToList();
                GroupedPoints[tp.StartTime.Date] = ordered;
            }
            else // moves to different date
            {
                Ctrl_CollapsibleTimeEntries existing = pnl_Main.Controls.OfType<Ctrl_CollapsibleTimeEntries>()
                                                        .Where(x => x.DateOfEntries.Equals(tp.StartTime.Date))
                                                        .FirstOrDefault();
                if (existing != null) // moves to existing date
                {
                    existing.AddControl(tp);
                    existing.OrderControls();
                    controlsParent.RemoveControl(tp);

                    // apply order to dictionary item
                    List<TrackingPoint> ordered = GroupedPoints[tp.StartTime.Date].OrderBy(x => x.StartTime).ToList();
                    GroupedPoints[tp.StartTime.Date] = ordered;
                }
                else // moves to nonexistent date
                {
                    controlsParent.RemoveControl(tp);
                    Ctrl_CollapsibleTimeEntries added = new Ctrl_CollapsibleTimeEntries(new List<TrackingPoint> { tp }, false, false);
                    pnl_Main.Controls.Add(added);

                    GroupedPoints[tp.StartTime.Date] = new List<TrackingPoint>() { tp };

                    List<Ctrl_CollapsibleTimeEntries> ordered = pnl_Main.Controls.OfType<Ctrl_CollapsibleTimeEntries>()
                                                                .OrderBy(x => x.DateOfEntries).Reverse().ToList();

                    foreach (Ctrl_CollapsibleTimeEntries item in ordered)
                        pnl_Main.Controls.SetChildIndex(item, 0);
                }
            }

        }

        public void UpdateTimeDuration()
        {
            lbl_Duration.UpdateOnThread(() =>
            {
                lbl_Duration.Text = FormatTimeSpan(TrackingData.GetDuration());
            });
        }

        public void AddNewEntry()
        {
            TrackingPoint latestPoint = TrackingData.TimeMarkers.Last();
            if (l_MostRecent?.GetTrackingPoint() == latestPoint)
                return;

            var existingCollapse = pnl_Main.Controls.OfType<Ctrl_CollapsibleTimeEntries>().Where(x => x.DateOfEntries.Equals(latestPoint.StartTime.Date)).FirstOrDefault();
            if (existingCollapse != null)
            {
                Ctrl_TimeEntry newest = new Ctrl_TimeEntry(latestPoint);
                newest.IsMostRecent = true;
                if (l_MostRecent != null) l_MostRecent.IsMostRecent = false;
                TrackingData.SetMostRecentEntry(newest);

                existingCollapse.pnl_Contents.UpdateOnThread(() => 
                {
                    existingCollapse.pnl_Contents.Controls.Add(newest);
                    //existingCollapse.pnl_Contents.Controls.SetChildIndex(newest, 0);
                    existingCollapse.ExpandControl();
                });


                l_MostRecent = newest;
            }
            else
            {
                Ctrl_CollapsibleTimeEntries collapse = new Ctrl_CollapsibleTimeEntries(new List<TrackingPoint>() { latestPoint }, true, false);
                var newest = collapse.GetMostRecentEntry();
                TrackingData.SetMostRecentEntry(newest);
                
                pnl_Main.UpdateOnThread(() => { pnl_Main.Controls.Add(collapse); });

                l_MostRecent = newest;
            }
            
        }

        public void CloseTrackingWindow()
        {
            TrackingData.GetFormControl().IsSelected = false;
            var scrollPoint = Frm_Main.MainForm.pnl_TrackedProgs.AutoScrollPosition;
            this.Visible = false;
            TrackingData.ItemUpdated -= OnTrackerUpdated;
            Frm_Main.MainForm.MakeItemListFullscreen(scrollPoint);
        }


        private void btn_AddEntry_Click(object sender, EventArgs e)
        {
            TrackingPoint trackingPoint = new TrackingPoint(DateTime.Now - new TimeSpan(0,0,1), DateTime.Now);


            Frm_EditTimeEntry popup = new Frm_EditTimeEntry(trackingPoint, TrackingData);
            Frm_Main main = Frm_Main.MainForm;
            Point here = new Point(main.Location.X + main.Width / 2, main.Location.Y + main.Height / 2);
            here.X -= popup.Width / 2;
            here.Y -= popup.Height / 2;

            popup.FormClosed += AddEntryForm_Closed;
            popup.Show();
            popup.Location = here;
        }

        private void AddEntryForm_Closed(object sender, EventArgs e)
        {
            Frm_EditTimeEntry ctrl = sender as Frm_EditTimeEntry;

            if (ctrl.DialogResult != DialogResult.OK)
                return;

            var updated = ctrl.GetUpdatedTrackingData();
            TrackingData.InsertTrackingPoint(updated);
            AddNewEntry();
            ReorderCollapsibleTimeEntries();

            //TrackingData.StartTracking(updated.StartTime);

            //trackingPoint.StartTime = updated.StartTime;
            //trackingPoint.StopTime = (trackingPoint.IsRunning) ? null : updated.StopTime;
            //ApplyTimeUpdates(true);

            //if (ctrl.DidMergeHappen())
            //    OnMergeAction(EventArgs.Empty);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CloseTrackingWindow();
        }


        void OnTrackerUpdated(object sender, EventArgs e)
        {
            UpdateTimeDuration();
        }
    }
}

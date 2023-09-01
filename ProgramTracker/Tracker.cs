using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ProgramTracker
{

    public class Tracker
    {
        public string ProcessName { get; set; }
        public List<TrackingPoint> TimeMarkers { get; set; }
        // <summary>This is only used if this is an alternate process</summary>
        //public string ParentProcessName = null;

        private Ctrl_TrackingItem TrackingFormControl { get; set; }
        
        /// <summary>
        /// Gets the control, not the actual time entry
        /// </summary>
        private Ctrl_TimeEntry MostRecentEntry { get; set; }

        internal bool IsRunning
        {
            get
            {
                return TimeMarkers.Count != 0 && TimeMarkers.Last().StopTime == null;
            }
        }


        public event EventHandler ItemUpdated;

        public Tracker() 
        {
            ProcessName = "";
            TimeMarkers = new List<TrackingPoint>();
            //AlternateProcessNames = new List<string>();
            TrackingFormControl = new Ctrl_TrackingItem(this);
        }
        /// <summary>Starts the tracking timer.</summary>
        public Tracker(string processName, Ctrl_TrackingItem _trackingForm=null, DateTime? startTime = null)
        {
            ProcessName = processName;
            TimeMarkers = new List<TrackingPoint>();
            //AlternateProcessNames = new List<string>();
            
            var p = new TrackingPoint(startTime, parent:this);
            p.UpdatedTracker += OnItemUpdated;
            TimeMarkers.Add(p);
            TrackingFormControl = (_trackingForm != null) ? _trackingForm : new Ctrl_TrackingItem(ProcessName, this, _displayName:GetDisplayName());
            //TrackingFormControl.Dock = DockStyle.Top;

            TrackingFormControl.Icon = GetSavedIcon();
        }


        public void AddAlternateProcessName(string altName)
        {
            if (Frm_Main.ProgSettings.AddAlternateProccessName(ProcessName, altName))
                Frm_Main.MasterTracker.ProcessTrackers[altName] = this;

            Frm_Main.ProgSettings.Save();
        }
        public void RemoveAlternateProcessName(string altName)
        {
            StopTracking();
            Frm_Main.ProgSettings.RemoveAlternateProcessName(ProcessName, altName);
            Frm_Main.ProgSettings.Save();
        }


        public Tracker Clone()
        {
            Tracker clone = new Tracker
            {
                ProcessName = ProcessName,
                TimeMarkers = TimeMarkers.Select(x => x.Clone()).ToList()
            };
            return clone;
        }

        /// <summary>
        /// The display name is defined within the program settings, so this gets it from there.
        /// </summary>
        public string GetDisplayName()
        {
            if (Frm_Main.ProgSettings != null)
            {
                if (Frm_Main.ProgSettings.ProcessNameOverride.TryGetValue(ProcessName, out string niceName))
                    return niceName;
                else
                    return "";
            }
            else
                return "";
        }

        /// <summary>Returns the display name if the control has one, otherwise returns the process name.</summary>
        public string GetVisibleName()
        {
            var a = GetDisplayName();
            return (string.IsNullOrEmpty(a)) ? ProcessName.ToPrettyString() : a;
        }

        public List<string> GetGroups()
        {
            List<string> groups = new List<string>();

            foreach (string key in Frm_Main.ProgSettings.ProgramGroups.Keys)
                if (Frm_Main.ProgSettings.ProgramGroups[key].Contains(ProcessName))
                    groups.Add(key);


            return groups;
        }

        public Bitmap GetSavedIcon()
        {
            Bitmap bmp = null;
            string path = Path.Combine(Settings.GetSettingsDirectory(), "Icons", ProcessName + ".png");

            if (File.Exists(path))
            {
                var ms = new MemoryStream(File.ReadAllBytes(path));
                bmp = (Bitmap)Image.FromStream(ms);
            }


            return bmp;
        }

        public Ctrl_TrackingItem GetFormControl(bool updateControl=false)
        {
            if (updateControl)
            {
                TrackingFormControl.ProcessName = ProcessName;
                TrackingFormControl.DisplayName = GetDisplayName();
                GetDuration();
                TrackingFormControl.Icon = GetSavedIcon();

                TrackingFormControl.Groups = GetGroups();
            }

            return TrackingFormControl;
        }

        public Ctrl_TimeEntry GetMostRecentEntry() => MostRecentEntry;
        public void SetMostRecentEntry(Ctrl_TimeEntry entry) => MostRecentEntry = entry;

        /// <summary>
        /// Tracking point needs to have an stop time.
        /// </summary>
        /// <param name="point"></param>
        public void InsertTrackingPoint(TrackingPoint point, bool stopIfRunning=false)
        {
            if (point.IsRunning)
            {
                if (stopIfRunning)
                {
                    point.ParentTracker.StopTracking();
                }
                else
                {
                    Console.WriteLine("Couldn't insert tracking point because it doesn't have a stop time.");
                    return;
                }
            }

            point.ParentTracker = this;
            point.UpdatedTracker += OnItemUpdated;

            TimeMarkers.Add(point);
        }

        /// <summary></summary>
        /// <param name="startTime">Defaults to DateTime.Now.</param>
        public void StartTracking(DateTime? startTime = null)
        {
            if (!IsRunning)
            {
                TrackingPoint p = new TrackingPoint(startTime, parent:this);
                p.UpdatedTracker += OnItemUpdated;

                TimeMarkers.Add(p);
            }

            if (TrackingFormControl.Icon == null)
                TrackingFormControl.Icon = GetSavedIcon();
        }
        public void StopTracking()
        {
            if (IsRunning)
                TimeMarkers.Last().StopTime = DateTime.Now;
        }

        /// <summary>
        /// This also updates the duration on the form control.
        /// </summary>
        internal TimeSpan GetDuration()
        {
            TimeSpan time = TimeSpan.Zero;

            foreach (TrackingPoint point in TimeMarkers)
                time+= point.GetDuration();

            if (TimeMarkers.Count > 0)
            {
                TrackingPoint last = TimeMarkers.Last();
                if (last.StopTime == null)
                    time += DateTime.Now - last.StartTime;
            }

            TrackingFormControl.Duration = time;
            return time;
        }

        /// <summary>
        /// Searches through existing points in the time markers and returns a list of points that overlap the passed through point.
        /// </summary>
        /// <param name="ignoreThisOne">This needs to be a point in the parent tracker.</param>
        public List<TrackingPoint> CheckForOverlap(TrackingPoint ignoreThisOne, TrackingPoint overlapper)
        {
            var matches = new List<TrackingPoint>();

            // The order of tracking points should already be ordered by start time.
            foreach (TrackingPoint compare in TimeMarkers.Where(x=>x != ignoreThisOne))
            {
                if (compare.StopTime < overlapper.StartTime)
                    continue;
                else if (compare.StartTime >= overlapper.StopTime) // stop iterating if already passed overlapper
                    break;

                if ((compare.StartTime >= overlapper.StartTime && compare.StartTime <= overlapper.StopTime) ||
                     (compare.StopTime > overlapper.StartTime && compare.StopTime <= overlapper.StopTime))
                {
                    matches.Add(compare);
                }
            }

            return matches;
        }


        /// <summary>
        /// This will take the oldest start point and the newest stop point and remove all the other points. CheckForOverlap() should be run before this.
        /// </summary>
        public void Merge(params TrackingPoint[] mergers)
        {
            if (mergers == null || mergers.Length == 0)
                return;

            DateTime start = mergers.OrderBy(x => x.StartTime).First().StartTime;
            DateTime end = (DateTime)mergers.OrderBy(x => x.StopTime).Last().StopTime;
            int index = mergers.Select(x => TimeMarkers.IndexOf(x)).OrderBy(x => x).Where(i => i != -1).First();
            var query = mergers.OrderBy(x => x.StopTime).Where(x => TimeMarkers.Contains(x)).ToList();

            for (int i = 0; i < query.Count-1; i++)
            {
                TimeMarkers.Remove(query[i]);
                query[i].GetTimeEntryControl()?.Dispose();
            }

            var last = query.Last();
            last.StartTime = start;
            last.StopTime = end;
        }

        /// <summary>Merges all tracking points from another tracker.</summary>
        /// <param name="merger">Merges these points with the parent tracker.</param>
        public void MergeTracker(Tracker merger)
        {
            foreach (TrackingPoint mergePoint in merger.TimeMarkers)
            {
                var overlaps = CheckForOverlap(null, mergePoint);
                if (overlaps.Count > 0)
                {
                    overlaps.Add(mergePoint);
                    Merge(overlaps.ToArray());
                }
                else
                {
                    InsertTrackingPoint(mergePoint, true);
                }
            }

            TimeMarkers = TimeMarkers.OrderBy(x => x.StartTime).ToList();
            //DateTime start = mergers.OrderBy(x => x.StartTime).First().StartTime;

            /*
            List<TrackingPoint> addThese = new List<TrackingPoint>();
            // All points should be ordered from oldest to newest.
            foreach (TrackingPoint point in TimeMarkers)
            {
                foreach (TrackingPoint mergePoint in merger.TimeMarkers)
                {
                    if (mergePoint.StopTime < point.StartTime)
                    {
                        ad
                        continue;
                    }
                    else if (mergePoint.StartTime > point.StopTime)
                        goto NextUp;

                    DateTime[] starts = { point.StartTime, mergePoint.StartTime };
                    DateTime[] ends = { (DateTime)point.StopTime, (DateTime)mergePoint.StopTime};

                    point.StartTime = starts.Min();
                    point.StopTime = ends.Max();
                }
            NextUp:;

            }
            */
        }


        /// <summary>
        /// This is so I don't have to make OnItemUpdated() accessible outside of this class.
        /// </summary>
        internal void ApplyItemUpdateEvents()
        {
            foreach (var p in TimeMarkers)
            {
                p.UpdatedTracker += OnItemUpdated;
            }
        }

        internal virtual void OnItemUpdated(object sender, EventArgs e)
        {
            // update order of tracking points
            TimeMarkers = TimeMarkers.OrderBy(x => x.StartTime).ToList();
            ItemUpdated?.Invoke(this, e);
        }
    }
}

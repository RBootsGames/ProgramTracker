using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ProgramTracker
{
    internal class MasterTrackerClass
    {
        public Dictionary<string, Tracker> ProcessTrackers { get; set; } = new Dictionary<string, Tracker>();


        /// <summary></summary>
        /// <param name="savePath">Defaults to %USERPROFILE%\Program Tracker</param>
        public void Save(string savePath = "")
        {
            if (savePath == "")
                savePath = Settings.GetSettingsDirectory();

            ProcessTrackers = ProcessTrackers.Sort();

            var options = new JsonSerializerOptions { WriteIndented = true };
            string data = JsonSerializer.Serialize(this, options);

            Directory.CreateDirectory(savePath);
            savePath = Path.Combine(savePath, "trackingdata.json");

            File.WriteAllText(savePath, data);
        }

        /// <summary></summary>
        /// <param name="loadPath">Defaults to %USERPROFILE%\Program Tracker</param>
        static public MasterTrackerClass Load(string loadPath = "")
        {
            if (loadPath == "")
                loadPath = Settings.GetSettingsDirectory();

            // missing directory
            if (!Directory.Exists(loadPath))
            {
                Console.Error.WriteLine($"'{loadPath}' doesn't exist.");
                return new MasterTrackerClass();
            }

            loadPath = Path.Combine(loadPath, "trackingdata.json");

            // missing file
            if (!File.Exists(loadPath))
            {
                Console.Error.WriteLine($"'{loadPath}' doesn't exist.");
                return new MasterTrackerClass();
            }

            string data = File.ReadAllText(loadPath);

            // actual loading data
            try
            {
                MasterTrackerClass mtc = JsonSerializer.Deserialize<MasterTrackerClass>(data);

                // setup events
                foreach (Tracker tracker in mtc.ProcessTrackers.Values)
                {
                    tracker.ApplyItemUpdateEvents();
                    tracker.ItemUpdated += mtc.OnTrackerUpdate;
                    foreach (var item in tracker.TimeMarkers)
                    {
                        item.ParentTracker = tracker;
                    }
                }

                var allControls = mtc.ProcessTrackers.Values.Select(x => x.GetFormControl(true)).ToArray();
                //var allControls = mtc.ProcessTrackers.Values.OrderBy(n => n.GetVisibleName())
                //                                .Reverse()
                //                                .Select(x => x.GetFormControl(true));

                Frm_Main.MainForm.pnl_TrackedProgs.Controls.AddRange(allControls.ToArray());
                Frm_Main.MainForm.SortEntries();
                Console.WriteLine("Tracking data loaded");
                return mtc;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Something went wrong when loading the settings file.");
                Console.Error.WriteLine(e.Message);

                throw;
                //return null;
            }
        }



        /// <summary>Starts the tracking timer.</summary>
        private void AddProcess(string procName, DateTime? startTrackingTime = null)
        {
            if (!ProcessTrackers.ContainsKey(procName))
            {
                Tracker t = new Tracker(procName, startTime:startTrackingTime);
                ProcessTrackers.Add(procName, t);

                var ctrl = t.GetFormControl();
                Frm_Main.MainForm.pnl_TrackedProgs.UpdateOnThread(() =>
                {
                    Frm_Main.MainForm.pnl_TrackedProgs.Controls.Add(ctrl);
                });

                t.ItemUpdated += OnTrackerUpdate;
            }
        }

        public void RemoveTrackingData(string procName)
        {
            if (ProcessTrackers.TryGetValue(procName, out Tracker tracker))
            {
                ProcessTrackers.Remove(procName);
                tracker.GetFormControl().Dispose();
            }
        }
        
        public void StopTrackingProcess(string procName)
        {
            if (ProcessTrackers.TryGetValue(procName, out Tracker program))
                program.StopTracking();
        }
        public void StartTrackingProcess(string procName, DateTime? startTrackingTime = null)
        {
            if (ProcessTrackers.TryGetValue(procName, out Tracker program))
                program.StartTracking(startTrackingTime);
            else
                AddProcess(procName, startTrackingTime);
        }


        public void UpdateAllTimes()
        {
            try
            {
                foreach (string key in ProcessTrackers.Keys)
                    ProcessTrackers[key].GetDuration();
            }
            catch { }
        }

        internal List<string> GetTrackerTimesAsString()
        {
            List<string> trackerTimes = new List<string>();

            foreach (string key in ProcessTrackers.Keys)
            {
                string text = (key).PadRight(20) + " ";
                text += ProcessTrackers[key].GetDuration().ToString(@"hh\:mm\:ss");
                trackerTimes.Add(text);
            }

            return trackerTimes;
        }

        private void OnTrackerUpdate(object sender, EventArgs e)
        {
            Tracker t = sender as Tracker;
            Console.WriteLine(t.ProcessName + " was updated");
        }
    }

    internal class Tracker
    {
        public string ProcessName { get; set; }
        public List<TrackingPoint> TimeMarkers { get; set; }

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
            TrackingFormControl = new Ctrl_TrackingItem(this);
            //TrackingFormControl.Dock = DockStyle.Top;
        }
        /// <summary>Starts the tracking timer.</summary>
        public Tracker(string processName, Ctrl_TrackingItem _trackingForm=null, DateTime? startTime = null)
        {
            ProcessName = processName;
            TimeMarkers = new List<TrackingPoint>();
            var p = new TrackingPoint(startTime, parent:this);
            p.UpdatedTracker += OnItemUpdated;
            //p.UpdatedTracker += new EventHandler(delegate (object sender, EventArgs e)
            //{
            //    OnItemUpdated(e);
            //});
            TimeMarkers.Add(p);
            TrackingFormControl = (_trackingForm != null) ? _trackingForm : new Ctrl_TrackingItem(ProcessName, this, _displayName:GetDisplayName());
            //TrackingFormControl.Dock = DockStyle.Top;

            TrackingFormControl.Icon = GetSavedIcon();
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

        /// <summary></summary>
        /// <returns>Returns the display name if the control has one, otherwise returns the process name.</returns>
        public string GetVisibleName()
        {
            var a = GetDisplayName();
            return (string.IsNullOrEmpty(a)) ? ProcessName.ToPrettyString() : a;
        }

        private Bitmap GetSavedIcon()
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
            }

            return TrackingFormControl;
        }

        public Ctrl_TimeEntry GetMostRecentEntry() => MostRecentEntry;
        public void SetMostRecentEntry(Ctrl_TimeEntry entry) => MostRecentEntry = entry;

        /// <summary>
        /// Tracking point needs to have an stop time.
        /// </summary>
        /// <param name="point"></param>
        public void InsertTrackingPoint(TrackingPoint point)
        {
            if (point.IsRunning)
            {
                Console.WriteLine("Couldn't insert tracking point because it doesn't have a stop time.");
                return;
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
                query[i].GetTimeEntryControl().Dispose();
            }

            var last = query.Last();
            last.StartTime = start;
            last.StopTime = end;

            //foreach (var remover in mergers)
            //    TimeMarkers.Remove(remover);

            //var added = new TrackingPoint(start, end, this);
            //added.UpdatedTracker += OnItemUpdated;
            //TimeMarkers.Insert(index, added);
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

    internal class TrackingPoint
    {
        DateTime l_StartTime;
        DateTime? l_StopTime;
        Ctrl_TimeEntry l_TimeEntryControl = null;

        public Tracker ParentTracker = null;
        public DateTime StartTime
        {
            get => l_StartTime;
            set
            {
                bool updated = false;
                if (!l_StartTime.Equals(value))
                    updated = true;

                l_StartTime = value;
                if (updated)
                    OnUpdateTracker(EventArgs.Empty);
            }
        }
        public DateTime? StopTime
        {
            get => l_StopTime;
            set
            {
                bool stopped = false;
                bool updated = false;
                if (l_StopTime == null && value != null)
                    stopped = true;

                if (!l_StopTime.Equals(value))
                    updated = true;

                l_StopTime = value;

                if (stopped)
                    OnStoppedTracking(EventArgs.Empty);

                if (updated)
                    OnUpdateTracker(EventArgs.Empty);
            }
        }

        internal bool IsRunning => StopTime == null;

        public event EventHandler StoppedTracking;

        public event EventHandler UpdatedTracker;


        public TrackingPoint() { }
        public TrackingPoint(DateTime? _startTime, DateTime? _stopTime = null, Tracker parent = null)
        {
            StartTime = (_startTime == null) ? DateTime.Now : (DateTime)_startTime;
            StopTime = _stopTime;
            ParentTracker = parent;
        }

        public void SetTimeEntryControl(Ctrl_TimeEntry ctrl) => l_TimeEntryControl = ctrl;
        public Ctrl_TimeEntry GetTimeEntryControl() => l_TimeEntryControl;

        public TrackingPoint Clone()
        {
            // This will also clone the events
            var clone = this.MemberwiseClone() as TrackingPoint;
            if (clone.ParentTracker != null)
            {
                clone.UpdatedTracker -= clone.ParentTracker.OnItemUpdated;
                clone.ParentTracker = null;
            }

            return clone;
        }

        internal TimeSpan GetDuration(bool calculateIfActive=false)
        {
            return (!IsRunning) ? (DateTime)StopTime - StartTime :
                (calculateIfActive) ? DateTime.Now - StartTime : TimeSpan.Zero;
        }


        /// <summary>
        /// Adds the duration of all the tracking points in the parameters.
        /// </summary>
        public static TimeSpan GetDuration(params TrackingPoint[] entries)
        {
            TimeSpan duration = TimeSpan.Zero;

            foreach (TrackingPoint point in entries)
            {
                duration += (!point.IsRunning) ? (DateTime)point.StopTime - point.StartTime:
                    DateTime.Now - point.StartTime;
            }

            return duration;
        }



        protected virtual void OnStoppedTracking(EventArgs e)
        {
            StoppedTracking?.Invoke(this, e);
        }
        protected virtual void OnUpdateTracker(EventArgs e)
        {
            UpdatedTracker?.Invoke(this, e);
        }
    }
}

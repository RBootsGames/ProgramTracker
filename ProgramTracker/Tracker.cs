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

            if (!Directory.Exists(loadPath))
            {
                Console.Error.WriteLine($"'{loadPath}' doesn't exist.");
                return new MasterTrackerClass();
            }

            loadPath = Path.Combine(loadPath, "trackingdata.json");

            if (!File.Exists(loadPath))
            {
                Console.Error.WriteLine($"'{loadPath}' doesn't exist.");
                return new MasterTrackerClass();
            }

            string data = File.ReadAllText(loadPath);

            try
            {
                MasterTrackerClass mtc = JsonSerializer.Deserialize<MasterTrackerClass>(data);

                var allControls = mtc.ProcessTrackers.Values.Select(x => x.GetFormControl(true)).ToArray();
                //var allControls = mtc.ProcessTrackers.Values.OrderBy(n => n.GetVisibleName())
                //                                .Reverse()
                //                                .Select(x => x.GetFormControl(true));

                Frm_Main.MainForm.pnl_TrackedProgs.Controls.AddRange(allControls.ToArray());
                Frm_Main.MainForm.Alphabetize();
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
    }

    internal class Tracker
    {
        public string ProcessName { get; set; }
        public List<TrackingPoint> TimeMarkers { get; set; }

        private Ctrl_TrackingItem TrackingFormControl { get; set; }
        
        private Ctrl_TimeEntry MostRecentEntry { get; set; }

        internal bool IsRunning
        {
            get
            {
                return TimeMarkers.Last().StopTime == null;
            }
        }


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
            TimeMarkers.Add(new TrackingPoint(startTime));
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

        public void StartTracking(DateTime? startTime = null)
        {
            if (!IsRunning)
                TimeMarkers.Add(new TrackingPoint(startTime));

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
    }

    internal class TrackingPoint
    {
        public DateTime StartTime { get; set; }
        public DateTime? StopTime { get; set; }

        internal bool IsRunning => StopTime == null;

        public TrackingPoint() { }
        public TrackingPoint(DateTime? _startTime, DateTime? _stopTime = null)
        {
            StartTime = (_startTime == null) ? DateTime.Now : (DateTime)_startTime;
            StopTime = _stopTime;
        }

        internal TimeSpan GetDuration(bool calculateIfActive=false)
        {
            return (!IsRunning) ? (DateTime)StopTime - StartTime :
                (calculateIfActive) ? DateTime.Now - StartTime : TimeSpan.Zero;
        }


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
    }
}

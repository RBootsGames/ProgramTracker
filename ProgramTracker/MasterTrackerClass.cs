using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace ProgramTracker
{
    internal class MasterTrackerClass
    {
        /// <summary>
        /// Key: process name
        /// Value: tracking data
        /// </summary>
        public Dictionary<string, Tracker> ProcessTrackers { get; set; } = new Dictionary<string, Tracker>();


        /// <summary></summary>
        /// <param name="savePath">Defaults to %USERPROFILE%\Program Tracker</param>
        /// <param name="keepProcsRunning">Set to true if you aren't stopping the program.</param>
        public void Save(string savePath = "", bool keepProcsRunning = false, string fileNameOverride="")
        {
            if (keepProcsRunning)
            {
                MasterTrackerClass clone = new MasterTrackerClass();
                clone.ProcessTrackers = ProcessTrackers.ToDictionary(entry => entry.Key,
                                                                     entry => entry.Value.Clone());
                //var clone = this.MemberwiseClone() as MasterTrackerClass;
                clone.Save(savePath);

                return;
            }

            if (savePath == "")
                savePath = Settings.GetSettingsDirectory();

            // remove duplicates from the alt processes
            foreach (string master in Frm_Main.ProgSettings.AlternateProcessNames.Keys)
            {
                foreach (string child in Frm_Main.ProgSettings.AlternateProcessNames[master])
                {
                    ProcessTrackers.Remove(child);
                }
            }

            foreach (var proc in ProcessTrackers.Values.Where(x => x.IsRunning))
            {
                StopTrackingProcess(proc.ProcessName);
            }

            //foreach (var proc in OpenProcesses.Values)
            //{
            //    MasterTracker.StopTrackingProcess(proc.ProcessName);
            //}


            ProcessTrackers = ProcessTrackers.Sort();

            var options = new JsonSerializerOptions { WriteIndented = true };
            string data = JsonSerializer.Serialize(this, options);

            Directory.CreateDirectory(savePath);

            if (string.IsNullOrEmpty(fileNameOverride))
                fileNameOverride = "trackingdata.json";

            savePath = Path.Combine(savePath, fileNameOverride);

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

                // setup events and alt processes
                var tempList = mtc.ProcessTrackers.Values.ToList();
                foreach (Tracker tracker in tempList)
                {
                    tracker.ApplyItemUpdateEvents();
                    tracker.ItemUpdated += mtc.OnTrackerUpdate;
                    foreach (var item in tracker.TimeMarkers)
                    {
                        item.ParentTracker = tracker;
                    }


                    if (Frm_Main.ProgSettings.AlternateProcessNames.TryGetValue(tracker.ProcessName, out var childList))
                    {
                        foreach (var child in childList)
                        {
                            mtc.ProcessTrackers[child] = tracker;
                        }
                    }
                }


                var allControls = mtc.ProcessTrackers.Values.Select(x => x.GetFormControl(true)).ToArray();
                //var allControls = mtc.ProcessTrackers.Values.OrderBy(n => n.GetVisibleName())
                //                                .Reverse()
                //                                .Select(x => x.GetFormControl(true));

                Frm_Main.MainForm.pnl_TrackedProgs.Controls.AddRange(allControls.ToArray());
                Frm_Main.MainForm.SortAndFilterEntries();
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
                    //ctrl.CheckboxVisible = true;
                });

                t.ItemUpdated += OnTrackerUpdate;
            }
        }

        public void RemoveTrackingData(string procName)
        {
            if (ProcessTrackers.TryGetValue(procName, out Tracker tracker))
            {
                // remove alt processes
                if (Frm_Main.ProgSettings.AlternateProcessNames.TryGetValue(procName, out var list))
                {
                    foreach (string alt in list)
                    {
                        ProcessTrackers.Remove(alt);
                    }
                }
                //foreach (string alt in tracker.AlternateProcessNames)
                //    ProcessTrackers.Remove(alt);

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


        public DateTime GetOldestDate()
        {
            DateTime oldest = DateTime.MaxValue;
            foreach (Tracker tracker in ProcessTrackers.Values)
            {
                DateTime date = tracker.GetOldestDate();
                if (date < oldest)
                    oldest = date;
            }

            return oldest;
        }

        public List<TrackingPoint> GetProcessDatesWithinRange(string processName, DateTime start, DateTime end)
        {
            if (ProcessTrackers.TryGetValue(processName, out Tracker tracker))
                return tracker.GetDatesWithinRange(start, end);
            else
                return new List<TrackingPoint>();
        }

        public void UpdateAllTimes()
        {
            try
            {
                // try to prevent the same trackers from updating multiple times
                List<Tracker> updateThese = new List<Tracker>();

                foreach (Tracker item in ProcessTrackers.Values)
                {
                    if (!updateThese.Contains(item))
                    {
                        item.GetDuration();
                        //updateThese.Add(item);
                    }
                }

                //foreach (string key in ProcessTrackers.Keys)
                //    ProcessTrackers[key].GetDuration();
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
}

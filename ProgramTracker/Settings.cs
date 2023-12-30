using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace ProgramTracker
{
    public class Settings
    {
        public List<string> IgnoreList { get; set; } = new List<string>();
        public List<string> WhitelistProcesses { get; set; } = new List<string>();
        public Dictionary<string, string> ProcessNameOverride { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// Key: Master process name.  Value: Other processes that will start tracking the master process.
        /// </summary>
        public Dictionary<string, List<string>> AlternateProcessNames { get; set; } = new Dictionary<string, List<string>>();
        /// <summary>
        /// Key: name of group Value: list of processes in the group
        /// </summary>
        public Dictionary<string, List<string>> ProgramGroups { get; set; } = new Dictionary<string, List<string>>();
        public bool StartMinimized { get; set; } = false;
        public bool AcknowledgedNonAdminMessage { get; set; } = false;
        public SortOrderType SortOrder { get; set; } = SortOrderType.Alphabetical;

        #region Date Filter
        public bool UseFilterDateStart { get; set; } = false;
        public bool UseFilterDateEnd { get; set; } = false;
        public bool ShowFilteredOutDateEntries { get; set; } = false;
        public DateTime FilterDateStart { get; set; }
        public DateTime FilterDateEnd { get; set; }
        #endregion

        public Settings()
        {
            WhitelistProcesses.Add(Process.GetCurrentProcess().ProcessName);

            FilterDateStart = new DateTime(2000, 1, 1);
            FilterDateEnd = DateTime.Now;
        }


        /// <summary></summary>
        /// <param name="savePath">Defaults to %USERPROFILE%\Program Tracker</param>
        public void Save(string savePath = "")
        {
            if (savePath == "")
                savePath = Settings.GetSettingsDirectory();

            IgnoreList.Sort();
            WhitelistProcesses.Sort();
            ProcessNameOverride = ProcessNameOverride.Sort();

            var options = new JsonSerializerOptions { WriteIndented = true };
            string data = JsonSerializer.Serialize(this, options);

            Directory.CreateDirectory(savePath);
            savePath = Path.Combine(savePath, "settings.ini");

            File.WriteAllText(savePath, data);
        }

        /// <summary></summary>
        /// <param name="loadPath">Defaults to %USERPROFILE%\Program Tracker</param>
        static public Settings Load(string loadPath = "")
        {
            if (loadPath == "")
                loadPath = Settings.GetSettingsDirectory();

            // directory not found
            if (!Directory.Exists(loadPath))
            {
                Console.Error.WriteLine($"'{loadPath}' doesn't exist.");
                return new Settings();
            }

            loadPath = Path.Combine(loadPath, "settings.ini");

            // settings not found
            if (!File.Exists(loadPath))
            {
                Console.Error.WriteLine($"'{loadPath}' doesn't exist.");
                return new Settings();
            }

            string data = File.ReadAllText(loadPath);

            try
            {
                Settings settings = JsonSerializer.Deserialize<Settings>(data);

                Console.WriteLine("Settings loaded");
                settings.ProcessNameOverride = settings.ProcessNameOverride.Sort();

                return settings;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Something went wrong when loading the settings file.");
                Console.Error.WriteLine(e.Message);

                throw;
                //return null;
            }

        }


        /// <summary></summary>
        /// <returns>Returns true if process was successfully added.</returns>
        public bool AddAlternateProccessName(string masterProcess, string childProcess)
        {
            AlternateProcessNames.TryGetValue(childProcess, out List<string> existingChildProcesses);

            bool success = false;

            if (AlternateProcessNames.TryGetValue(masterProcess, out var list))
            {
                if (list.AddWithoutDupes(childProcess))
                    success = true;
            }
            else
            {
                AlternateProcessNames[masterProcess] = new List<string> { childProcess };

                success = true;
            }

            if (success && existingChildProcesses != null)
            {
                foreach (string item in existingChildProcesses)
                    AlternateProcessNames[masterProcess].AddWithoutDupes(item);

                AlternateProcessNames.Remove(childProcess);
            }

            return success;
        }
        public void RemoveAlternateProcessName(string masterProcess, string childProcess)
        {
            if (AlternateProcessNames.TryGetValue(masterProcess, out var list))
            {
                list.Remove(childProcess);
                if (list.Count == 0)
                    AlternateProcessNames.Remove(masterProcess);

                Frm_Main.MasterTracker.ProcessTrackers.Remove(childProcess);
                Frm_Main.MainForm.ForceReloadProcesses = true;
            }
        }

        public string RangeToString()
        {
            string s = "";

            if (!UseFilterDateStart && !UseFilterDateEnd)
                return "All Dates";

            s += (UseFilterDateStart) ? FilterDateStart.ToString("d") : "Beginning";

            if (UseFilterDateStart && UseFilterDateEnd && FilterDateStart.ToShortDateString() == FilterDateEnd.ToShortDateString())
            {
                s += $" {FilterDateStart.TimeOfDay.Hours}:{FilterDateStart.TimeOfDay.Minutes}";
            }
            s += " - ";

            if (UseFilterDateEnd && UseFilterDateStart && FilterDateStart.ToShortDateString() == FilterDateEnd.ToShortDateString())
            {
                s += $" {FilterDateEnd.TimeOfDay.Hours}:{FilterDateEnd.TimeOfDay.Minutes}";
            }
            else
                s += (UseFilterDateEnd) ? FilterDateEnd.ToString("d") : "Present";

            return s;
        }


        public static string GetSettingsDirectory()
        {
            if (Debugger.IsAttached)
                return Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Program Tracker\\Debugging Items");
            else
                return Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Program Tracker");
        }
        public static string GetIconsDirectory()
        {
            return Path.Combine(GetSettingsDirectory(), "Icons");
        }

        public void SetProcessDisplayName(string procName, string displayName)
        {
            ProcessNameOverride[procName] = displayName;
            if (string.IsNullOrEmpty(displayName))
                ProcessNameOverride.Remove(procName);

            Save();
        }
    }
}

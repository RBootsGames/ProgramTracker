using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace ProgramTracker
{
    internal class Settings
    {
        public List<string> IgnoreList { get; set; } = new List<string>();
        public List<string> WhitelistProcesses { get; set; } = new List<string>();
        public Dictionary<string, string> ProcessNameOverride { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// Key: name of group Value: list of processes in the group
        /// </summary>
        public Dictionary<string, List<string>> ProgramGroups { get; set; } = new Dictionary<string, List<string>>();


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

            if (!Directory.Exists(loadPath))
            {
                Console.Error.WriteLine($"'{loadPath}' doesn't exist.");
                return new Settings();
            }

            loadPath = Path.Combine(loadPath, "settings.ini");

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


        public static string GetSettingsDirectory()
        {
            if (Debugger.IsAttached)
                return Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Program Tracker\\Debugging Items");
            else
                return Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Program Tracker");
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

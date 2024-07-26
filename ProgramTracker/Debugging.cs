using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTracker
{
    internal static class Debugging
    {
        public static string GetDebugFilePath()
        {
            if (Debugger.IsAttached)
                return Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Program Tracker\\Debugging Items\\debug.log");
            else
                return Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Program Tracker\\debug.log");
        }

        /// <summary>
        /// Doesn't do anything if the program doesn't have debug mode enabled.
        /// </summary>
        public static void Log(string message, bool printToConsole=false)
        {
            if (Frm_Main.ProgSettings.DebugMode == false)
                return;

            string filePath = GetDebugFilePath();
            string timeStamp = $"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff")}]";

            //if (!File.Exists(filePath))
            //{
            //    using (StreamWriter sw = File.CreateText(filePath))
            //    {
            //    }
            //}

            // append text if the file exists else create the file
            StreamWriter sw = (File.Exists(filePath)) ? File.AppendText(filePath) : File.CreateText(filePath);

            message = $"{timeStamp} {message}";
            sw.WriteLine(message);

            sw.Close();

            if (printToConsole)
                Console.WriteLine(message);
        }
    }
}

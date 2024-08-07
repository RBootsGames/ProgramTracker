﻿using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using ProgramTracker.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

using sTimer = System.Timers.Timer;

namespace ProgramTracker
{
    public enum SortOrderType
    {
        Alphabetical,
        Duration,
        MostRecent,
        AlphabeticalAcending,
        DurationAcending,
        MostRecentAcending,
    }

    public partial class Frm_Main : Form
    {
        SortOrderType l_SortOrder;

        SortOrderType SortOrder
        {
            get => l_SortOrder;
            set
            {
                l_SortOrder = value;
                menu_Sort.SelectedIndexChanged -= menu_Sort_SelectionChange;

                for (int i = 0; i < menu_Sort.Items.Count; i++)
                {
                    menu_Sort.Items[i] = ((string)menu_Sort.Items[i]).Replace("↓", "");
                    menu_Sort.Items[i] = ((string)menu_Sort.Items[i]).Replace("↑", "");
                }

                if ((int)value >= Enum.GetNames(typeof(SortOrderType)).Length / 2)
                    menu_Sort.Items[menu_Sort.SelectedIndex] += "↑";
                else
                    menu_Sort.Items[menu_Sort.SelectedIndex] += "↓";


                menu_Sort.SelectedIndexChanged += menu_Sort_SelectionChange;
                SortAndFilterEntries();
            }
        }


        internal static Settings ProgSettings = new Settings();
        internal static MasterTrackerClass MasterTracker = new MasterTrackerClass();
        internal static Frm_Main MainForm = null;
        internal static Tracker selectedTrackingItem = null;
        internal bool ForceReloadProcesses = false;
        Tracker selectedTrackingItemForMenu = null;
        string currentGroupFilter = "";
        int lastClickedControlIndex = -1;

        Thread UpdateThread = null;
        sTimer tmr_CheckEventlessProcesses = new sTimer(1000);
        sTimer tmr_SearchBarCooldown = new sTimer(750);

        Ctrl_TrackingInfoPage trackingInfoPage = null;

        /// <summary>Only includes processes with Window Titles and process added to the whitelist.</summary>
        public static Dictionary<int, Process> OpenProcesses = new Dictionary<int, Process>();
        private List<Process> eventlessProcesses = new List<Process>();
        Dictionary<int, Process> OpenProcessesNoTitle = new Dictionary<int, Process>();
        IEnumerable<int> previousProcesses = Enumerable.Empty<int>();

        bool actuallyClosing = false;


        // debug variables
        bool isDebugging = false;


        public Frm_Main()
        {
            InitializeComponent();
            l_SortOrder = SortOrderType.AlphabeticalAcending;

            menu_Sort.SelectedIndex = 0;

            if (Debugger.IsAttached)
            {
                taskbarIcon.Icon = Resources.ghost_icon;
                taskbarIcon.Text = "Program Tracker (Debugging)";
            }

            tmr_CheckEventlessProcesses.Elapsed += tmr_CheckEventlessProcesses_Tick;
            tmr_SearchBarCooldown.Elapsed += eventSearchPrograms;

            ActiveControl = null;
            trackingInfoPage = new Ctrl_TrackingInfoPage();
            Controls.Add(trackingInfoPage);
            Controls.SetChildIndex(trackingInfoPage, 0);
            trackingInfoPage.Visible = false;
            MainForm = this;

            ToolTip tip = new ToolTip();
            tip.SetToolTip(btn_AddGroup, "Add new program group");

            lbl_RunAsAdmin.Visible = !IsAdministrator();


            // load and apply settings
            ProgSettings = Settings.Load();
            menuEdit_Minimized.Checked = ProgSettings.StartMinimized;
            menuEdit_Debug.Checked = ProgSettings.DebugMode;
            menuEdit_AutoStart.Checked = GetAutoStart();

            // just sets the index for sorting
            menu_Sort.SelectedIndex = (int)ProgSettings.SortOrder % (Enum.GetNames(typeof(SortOrderType)).Length / 2);
            menu_Sort.SelectedIndexChanged += menu_Sort_SelectionChange;
            SortOrder = ProgSettings.SortOrder;


            if (IsAdministrator() || ProgSettings.AcknowledgedNonAdminMessage)
            {
                lbl_RunAsAdmin.Visible = false;
            }

            if (ProgSettings.ProgramGroups.Count > 0)
            {
                foreach (string group in ProgSettings.ProgramGroups.Keys)
                {
                    AddButtonToGroupTabs(group);
                }

            }

            //if (ProgSettings.StartMinimized)
            if (!Debugger.IsAttached && ProgSettings.StartMinimized)
            {
                this.Shown += new EventHandler(delegate (Object sender, EventArgs e)
                {
                    tmr_UpdateTimes.Stop();
                    Hide();
                });
            }

            //UpdateLoop();
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                .IsInRole(WindowsBuiltInRole.Administrator);
        }

        void LoadProcesses()
        {
            Stopwatch processGetTimer = Stopwatch.StartNew();

            // compare open processes with last scan
            IEnumerable<Process> runningPs = Process.GetProcesses();
            var current = runningPs.Select(x => x.Id);

            var compare = current.Except(previousProcesses);
            // return if the process list hasn't changed
            if (ForceReloadProcesses == false && compare.Any() == false) // open processes is the same as before
            {
                processGetTimer.Stop();
                //Console.WriteLine($"Skipped processing processes. ({processGetTimer.ElapsedMilliseconds})");
                return;
            }
            ForceReloadProcesses = false;

            Console.WriteLine("getting processes");
            previousProcesses = current;

            // get all processes with window titles
            runningPs = runningPs.Where(x => !string.IsNullOrEmpty(x.MainWindowTitle))
            // remove ignored processes
                                 .Where(x => ProgSettings.IgnoreList.Contains(x.ProcessName) != true);

            // add whitelist processes without window titles
            foreach (string customProc in ProgSettings.WhitelistProcesses)
            {
                var temp = (Process.GetProcessesByName(customProc)).FirstOrDefault();

                if (temp != null && !runningPs.Select(x => x.ProcessName).Contains(temp.ProcessName))
                    runningPs = runningPs.Append(temp);
            }

            // add running processes to process dictionary

            var openProcessNames = OpenProcesses.Values.Select(x => x.ProcessName);
            foreach (var proc in runningPs)
            {
                // don't add process if the ID or process name already exists
                if (!OpenProcesses.ContainsKey(proc.Id) && !openProcessNames.Contains(proc.ProcessName))
                    OpenProcesses[proc.Id] = proc;
            }

            /* running processes should contain processes that match these rules
             * 
             * includes a window title unless the process name is on the whitelist
             * process is not on the blacklist
             * 
             */

            // loop through processes
            foreach (var item in runningPs)
            {
                // add event closing event to process or add to list if it doesn't work
                AddCloseEventToProcess(item);

                // get icons
                CustomExtensions.SaveIconFromExe(item);
                if (selectedTrackingItem?.ProcessName == item.ProcessName)
                {
                    trackingInfoPage.SetIcon(selectedTrackingItem.GetSavedIcon());
                }


                // This function should only be running every ~10 seconds.
                // If a new process showed up, use the process start time as the start time for the tracker.
                // If it was started before ~10 seconds ago, use current time.
                // This is supposed to prevent the same time being added if 'Program Tracker' was restarted.
                try
                {
                    DateTime compareTime = DateTime.Now - new TimeSpan((long)(tmr_CheckProcesses.Interval * 1.1f) * 10000);
                    DateTime? progStart = // This got pretty messy didn't it?
                        (compareTime <= item.StartTime)
                        ? item.StartTime : DateTime.Now;


                    MasterTracker.StartTrackingProcess(item.ProcessName, progStart);
                    if (selectedTrackingItem != null && selectedTrackingItem.ProcessName == item.ProcessName)
                    {
                        trackingInfoPage.AddNewEntry();
                    }
                }
                catch { }

            }

            SortAndFilterEntries();

            // start a timer that checks these processes
            if (eventlessProcesses.Count > 0 && tmr_CheckEventlessProcesses.Enabled == false)
                tmr_CheckEventlessProcesses.Start();
            else if (eventlessProcesses.Count == 0 && tmr_CheckEventlessProcesses.Enabled)
                tmr_CheckEventlessProcesses.Stop();

            // stop tracking programs that aren't running that failed to add an exit event


            processGetTimer.Stop();

            Debugging.Log($"process processing elapsed time: {processGetTimer.Elapsed.TotalSeconds} seconds", true);
        }

        /// <summary>
        /// This only adds an event to proccess that are in the OpenProcesses variable.
        /// </summary>
        void AddCloseEventToProcess(Process proc)
        {
            // if this process isn't in the OpenProcesses dictionary then don't add an event
            if (OpenProcesses.TryGetValue(proc.Id, out Process p))
            {
                // if raising events is true, then the closing event has already been added
                if (p.EnableRaisingEvents == false &&
                    !eventlessProcesses.Select(x=>x.Id).Contains(proc.Id))
                {
                    try
                    {
                        proc.EnableRaisingEvents = true;
                        proc.Exited += eventProgramExit;
                    }
                    catch
                    {
                        //throw;
                        OpenProcesses.Remove(proc.Id);
                        eventlessProcesses.AddWithoutDupes(proc);
                        Debugging.Log($"Couldn't use an event for {proc.ProcessName}, going eventless.", true);
                        //continue;
                    }
                }
            }

        }


        /// <summary>
        /// Sorts the running and stopped processes based on the filter.
        /// </summary>
        internal void SortAndFilterEntries()
        {
            pnl_TrackedProgs.UpdateOnThread(() =>
            {
                pnl_TrackedProgs.SuspendLayout();

                IEnumerable<Ctrl_TrackingItem> cti = pnl_TrackedProgs.Controls.OfType<Ctrl_TrackingItem>();

                // apply date filter
                if (ProgSettings.ShowFilteredOutDateEntries == false)
                {
                    cti = cti.Where(x =>
                    {
                        if (x.Duration == TimeSpan.Zero && !x.ParentTracker.IsRunning)
                        {
                            x.Visible = false;
                            return false;
                        }
                        return true;
                    });
                }

                // do sorting
                switch (SortOrder)
                {
                    case SortOrderType.Alphabetical:
                        cti = cti.OrderBy(x => x.GetVisibleName());
                        break;
                    case SortOrderType.Duration:
                        cti = cti.OrderBy(x=>x.GetVisibleName()).OrderByDescending(x => x.Duration);
                        break;
                    case SortOrderType.MostRecent:
                        cti = cti.OrderBy(x => x.GetVisibleName())
                            .OrderByDescending(x =>
                        {
                            var temp = x.ParentTracker.TimeMarkers.LastOrDefault();
                            if (temp == null)
                                return DateTime.MinValue;
                            else if (temp.IsRunning)
                                return temp.StartTime;
                            else
                                return temp.StopTime;
                        });
                        break;

                    // ====================== inverted sorting ======================
                    case SortOrderType.AlphabeticalAcending:
                        cti = cti.OrderByDescending(x => x.GetVisibleName());
                        break;
                    case SortOrderType.DurationAcending:
                        cti = cti.OrderBy(x => x.GetVisibleName()).OrderBy(x => x.Duration);
                        break;
                    case SortOrderType.MostRecentAcending:
                        cti = cti.OrderBy(x => x.GetVisibleName())
                            .OrderBy(x =>
                        {
                            var temp = x.ParentTracker.TimeMarkers.LastOrDefault();
                            if (temp == null)
                                return DateTime.MinValue;
                            else if (temp.IsRunning)
                                return temp.StartTime;
                            else
                                return temp.StopTime;
                        });
                        break;
                    default:
                        cti = cti.OrderBy(x => x.GetVisibleName());
                        break;
                }


                // apply group filtering
                if (ProgSettings.ProgramGroups.TryGetValue(currentGroupFilter, out var filtered))
                {
                    if (filtered.Count > 0)
                    {
                        foreach (var ctrl in cti)
                            ctrl.Visible = filtered.Contains(ctrl.ProcessName) && ctrl.FoundInSearch;
                    }
                    else
                    {
                        foreach (var ctrl in cti)
                            ctrl.Visible = false;
                    }
                }
                else
                {
                    foreach (var ctrl in cti)
                        ctrl.Visible = ctrl.FoundInSearch;
                }



                var first  = cti.Where(x => x.ParentTracker.IsRunning == true);
                var second = cti.Where(x => x.ParentTracker.IsRunning == false);


                var controls = first.Concat(second).Reverse().ToArray();


                int visibleIndex = 0;
                int offset = 0;
                if (second.Count() == 0)
                {
                    offset = 1;
                    pnl_TrackedProgs.Controls.SetChildIndex(pnl_Stopped, 0);
                }
                for (int i = 0; i < controls.Length; i++)
                {
                    pnl_TrackedProgs.Controls.SetChildIndex(controls[i], i+offset);
                    controls[i].UseAltColor = visibleIndex % 2 == 0;
                    if (controls[i].Visible)
                        visibleIndex++;

                    if (i == second.Count()-1)
                    {
                        offset = 1;
                        pnl_TrackedProgs.Controls.SetChildIndex(pnl_Stopped, i+1);
                    }
                }
                pnl_TrackedProgs.Controls.SetChildIndex(pnl_Running, controls.Length+1);


                pnl_TrackedProgs.ResumeLayout();
                
            });
        }


        void UpdateLoop()
        {
            if (UpdateThread == null || UpdateThread.IsAlive == false)
            {
                UpdateThread = new Thread(() =>
                    {
                        LoadProcesses();
                    });

                UpdateThread.Start();
            }
        }


        void eventlessProgramExit()
        {
            List<Process> removers = new List<Process>();

            foreach (var proc in eventlessProcesses)
            {
                string masterProcessName = MasterTracker.ProcessTrackers[proc.ProcessName].ProcessName;
                IEnumerable<Process> matching = Process.GetProcessesByName(masterProcessName);

                if (ProgSettings.AlternateProcessNames.TryGetValue(masterProcessName, out var alts))
                {
                    foreach (string alt in alts)
                    {
                        matching = matching.Append(Process.GetProcessesByName(alt).First());
                    }
                }

                if (matching.Count() == 0) // it is stopped
                {
                    removers.Add(proc);
                    MasterTracker.StopTrackingProcess(proc.ProcessName);
                    Console.WriteLine($"       {proc.ProcessName.PadRight(25)} (non-event) exited.");
                    Debugging.Log($"{proc.ProcessName} (non-event) exited.");
                }
                else
                {
                    if(!matching.Select(x=>x.Id).Contains(proc.Id))
                    {
                        AddCloseEventToProcess(matching.First());
                        removers.Add(proc);
                        Console.WriteLine($"{proc.Id} :: {proc.ProcessName} was replaced with {proc.Id} :: {proc.ProcessName}");
                        Debugging.Log($"{proc.Id} :: {proc.ProcessName} was replaced with {proc.Id} :: {proc.ProcessName}");
                    }
                }

            }
            foreach (var name in removers)
                eventlessProcesses.Remove(name);

            if (eventlessProcesses.Count == 0)
                tmr_CheckEventlessProcesses.Stop();

            SortAndFilterEntries();
        }

        void eventProgramExit(object sender, EventArgs e)
        {
            Stopwatch exitTimer = Stopwatch.StartNew();

            Process proc = sender as Process;
            Process replacedWith = null;

            bool didExit = proc.WaitForExit(4000);
            
            OpenProcesses.Remove(proc.Id);

            string masterProcessName = MasterTracker.ProcessTrackers[proc.ProcessName].ProcessName;
            var matching = Process.GetProcessesByName(masterProcessName).Where(x => x.Id != proc.Id);

            if (ProgSettings.AlternateProcessNames.TryGetValue(masterProcessName, out var alts))
            {
                foreach (string alt in alts)
                {
                    var adder = Process.GetProcessesByName(alt).Where(x => x.Id != proc.Id).FirstOrDefault();
                    if (adder != null)
                        matching = matching.Append(adder);
                }
            }

            bool stopTracking = true;
            //if (matching.Count() > 0)
            //{
            foreach (var replacement in matching)
            {
                if (replacement.HasExited == false)
                {
                    OpenProcesses[replacement.Id] = replacement;
                    AddCloseEventToProcess(replacement);
                    replacedWith = replacement;
                    stopTracking = false;
                    break;
                }
            }
            //}

            if (stopTracking)
            {
                MasterTracker.StopTrackingProcess(proc.ProcessName);
                Console.WriteLine($"{proc.Id} :: {proc.ProcessName.PadRight(25)} exited.");
                Debugging.Log($"\"{proc.ProcessName}\" exited.");
            }
            else
            {
                Console.WriteLine($"{proc.Id} :: {proc.ProcessName} was replaced with {replacedWith.Id} :: {replacedWith.ProcessName}.");
                Debugging.Log($"\"{proc.ProcessName}\" exited and was replaced by another process.");
            }


            SortAndFilterEntries();

            exitTimer.Stop();

            string exitMessage = $"Program exit event for \"{proc.ProcessName}\": {exitTimer.Elapsed.TotalSeconds} seconds";
            if (!didExit)
                exitMessage += " (wait for exit timer timed out)";

            Debugging.Log(exitMessage, true);
        }

        void AddProgramToGroup(string groupName, string processName)
        {
            //var groupName = sender as ToolStripMenuItem;
            //Tracker selection = selectedTrackingItemForMenu;

            if (ProgSettings.ProgramGroups.TryGetValue(groupName, out var currentList))
            {
                if (!currentList.Contains(processName))
                {
                    currentList.Add(processName);
                    var item = pnl_TrackedProgs.Controls.OfType<Ctrl_TrackingItem>()
                              .Where(x => x.ProcessName == processName).FirstOrDefault();

                    if (item != null)
                        item.Groups = MasterTracker.ProcessTrackers[processName].GetGroups();
                }
            }

            //ProgSettings.ProgramGroups[groupName.Text].Add(selection.ProcessName);
            ProgSettings.Save();
        }

        /// <summary>
        /// Checks the registry to see if this program exists in the autoruns.
        /// </summary>
        bool GetAutoStart()
        {
            if (!IsAdministrator())
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                return rk.GetValue(Application.ProductName) != null;
            }

            using (TaskService ts = new TaskService())
            {
                return ts.GetTask(@"\Custom\Program Tracker Autostart") != null;
            }
        }
        void SetAutoStart(bool autoStart)
        {
            if (autoStart)
            {
                if (!IsAdministrator())
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.SetValue(Application.ProductName, $"\"{Application.ExecutablePath}\"");
                }
                else
                {
                    using (TaskService ts = new TaskService())
                    {
                        SetAutoStart(false);

                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = "Starts Program Tracker on user logon and runs it as administrator.";

                        // run as admin
                        td.Principal.RunLevel = TaskRunLevel.Highest;

                        // create action
                        td.Actions.Add(new ExecAction($"{Application.ExecutablePath}"));

                        // create logon trigger
                        //td.Principal.UserId = WindowsIdentity.GetCurrent().Name; // current user only
                        //td.Principal.LogonType = TaskLogonType.InteractiveToken;
                        td.Triggers.Add(new LogonTrigger());

                        // register task in root
                        ts.RootFolder.RegisterTaskDefinition(@"\Custom\Program Tracker Autostart", td);
                        
                    }
                }

                return;
            }

            RegistryKey k = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            k.DeleteValue(Application.ProductName, false);

            if (IsAdministrator())
            {
                using (TaskService ts = new TaskService())
                    ts.RootFolder.DeleteTask(@"\Custom\Program Tracker Autostart", false);
            }
        }

        IEnumerable<Ctrl_TrackingItem> GetAllTrackingItems(bool excludeHidden=false)
        {
            var trackingItems = pnl_TrackedProgs.Controls.OfType<Ctrl_TrackingItem>();
            if (excludeHidden)
                return trackingItems.Where(x => x.Visible);
            else
                return trackingItems;
        }

        IEnumerable<Ctrl_TrackingItem> GetSelectedTrackingItems(bool getDeselectedInstead=false)
        {
            return GetAllTrackingItems(true).Where(x => x.IsMultiSelected == !getDeselectedInstead);
        }


        #region Form Controls

        #region Main Form Controls
        private void tmr_CheckProcesses_Tick(object sender, EventArgs e)
        {
            UpdateLoop();
        }

        private void tmr_UpdateTimes_Tick(object sender, EventArgs e)
        {
            if (selectedTrackingItem == null)
            {
                MasterTracker.UpdateAllTimes();
            }
            else if (selectedTrackingItem != null && selectedTrackingItem.IsRunning)
            {
                var t = selectedTrackingItem;
                t.GetMostRecentEntry().CalculateDuration();
                Controls.OfType<Ctrl_TrackingInfoPage>().First().UpdateTimeDuration();
            }
        }

        /// <summary>Auto save every 30 minutes.</summary>
        private void tmr_AutoSave_Tick(object sender, EventArgs e)
        {
            MasterTracker?.Save(keepProcsRunning: true);
        }


        private void tmr_CheckEventlessProcesses_Tick(object sender, ElapsedEventArgs e)
        {
            eventlessProgramExit();
        }


        /// <param name="triggeredByButton">Set this to false if you aren't
        /// clicking the close button in the tracking info page.</param>
        internal void MakeItemListFullscreen(Point scrollPoint, bool triggeredByButton=true)
        {
            if (selectedTrackingItem == null)
                return;

            if(!triggeredByButton)
                trackingInfoPage.CloseTrackingWindow();

            if (scrollPoint == null)
                scrollPoint = pnl_TrackedProgs.AutoScrollPosition;
            scrollPoint.Y = -scrollPoint.Y;
            
            pnl_TrackedProgs.Dock = DockStyle.Fill;
            foreach (var item in MasterTracker.ProcessTrackers.Values)
            {
                var ctrl = item.GetFormControl();
                ctrl.OnlyShowIcon = false;
            }
            pnl_TrackedProgs.AutoScrollPosition = scrollPoint;
            selectedTrackingItem = null;
        }


        private void Frm_Main_Load(object sender, EventArgs e)
        {
            MasterTracker = MasterTrackerClass.Load();

            // check if any processes didn't properly end on last exit
            foreach (var item in MasterTracker.ProcessTrackers.Values)
            {
                if(item.IsRunning)
                    item.StopTracking();

                // apply click events to tracking item controls
                item.GetFormControl().ControlClick += Ctrl_TrackingItems_Click;
                item.GetFormControl().ClickToggleSelect += TrackingControlSelectionToggled;
            }


            ApplyTimeRangeText();

            // find running programs, but do it before the timer ticks for the first time
            UpdateThread = new Thread(() =>
            {
                Thread.Sleep(500); // This may not be necessary, but I remember running into issues
                                    // in the past when running this process right at load time.
                LoadProcesses();
            });
            UpdateThread.Start();

            Debugging.Log("Program Tracker started");
        }



        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                actuallyClosing = true;


            //if (!actuallyClosing)
            if (!Debugger.IsAttached && !actuallyClosing)
            {
                tmr_UpdateTimes.Stop();
                Hide();
                MakeItemListFullscreen(new Point(0, 0), false);
                e.Cancel = true;
                return;
            }
            
            MasterTracker.Save();

            if (UpdateThread != null && UpdateThread.IsAlive)
                UpdateThread.Abort();

            Debugging.Log("Program Tracker closed");
        }

        private void pnl_TabsParent_Resize(object sender, EventArgs e)
        {
            if (pnl_Tabs.Width < pnl_TabsParent.Width)
                pnl_Tabs.Location = new Point(0, 0);
            else if (pnl_Tabs.Width + pnl_Tabs.Location.X < pnl_TabsParent.Width)
            {
                pnl_Tabs.Location = new Point(-(pnl_Tabs.Width - pnl_TabsParent.Width), 0);
            }
        }


        private void eventSearchPrograms(object sender, EventArgs e)
        {
            // prevent searching on every text change
            if (sender != tmr_SearchBarCooldown)
            {
                tmr_SearchBarCooldown.Stop();
                tmr_SearchBarCooldown.Start();
                return;
            }
            tmr_SearchBarCooldown.Stop();


            var ctrls = pnl_TrackedProgs.Controls.OfType<Ctrl_TrackingItem>().ToList();

            if (!string.IsNullOrEmpty(txbx_Search.RealText))
            {
                foreach (Ctrl_TrackingItem proc in ctrls)
                {
                    if (proc.DisplayName.ToLower().Contains(txbx_Search.Text.ToLower()) ||
                        proc.ProcessName.ToLower().Contains(txbx_Search.Text.ToLower()))
                    {
                        proc.FoundInSearch = true;
                    }
                    else
                    {
                        proc.FoundInSearch = false;
                    }
                }
            }
            else
            {
                foreach (Ctrl_TrackingItem proc in ctrls)
                {
                    proc.FoundInSearch = true;
                }
            }
            SortAndFilterEntries();
        }

        private void btn_ClearSearch_Click(object sender, EventArgs e)
        {
            txbx_Search.ClearText();
        }

        private void btn_ToggleSelectAll_Click(object sender, EventArgs e)
        {
            var trackingItems = GetAllTrackingItems();

            bool allSelected = GetSelectedTrackingItems(true).Count() == 0;

            foreach (var item in trackingItems)
                item.IsMultiSelected = !allSelected;

            if (allSelected) // technically this is inverted because the selection has been changed now
            {
                btn_ToggleSelectAll.Text = "Select All";
                menuEdit_DeleteSelection.Visible = false;
                menuTS_DeleteSelection.Visible = false;
            }
            else
            {
                btn_ToggleSelectAll.Text = "Deselect All";
                menuEdit_DeleteSelection.Visible = true;
                menuTS_DeleteSelection.Visible = true;
            }

        }

        private void menu_Sort_SelectionChange(object sender, EventArgs e)
        {
            SortOrderType sorter = (SortOrderType)menu_Sort.SelectedIndex;

            if (SortOrder == sorter)
                sorter = sorter + Enum.GetNames(typeof(SortOrderType)).Length / 2;

            SortOrder = sorter;
            ProgSettings.SortOrder = sorter;
            ProgSettings.Save();
            ActiveControl = null;
        }

        private void menu_TimeRange_Click(object sender, EventArgs e)
        {
            Frm_SetTimeRange timeRangeChange = new Frm_SetTimeRange(ProgSettings);

            timeRangeChange.Show();
            
            timeRangeChange.FormClosed += new FormClosedEventHandler(delegate (object _sender, FormClosedEventArgs _e)
            {
                if (timeRangeChange.Response == DialogResult.OK)
                {
                    ProgSettings.UseFilterDateStart = timeRangeChange.UseStartDate;
                    ProgSettings.UseFilterDateEnd = timeRangeChange.UseEndDate;
                    ProgSettings.ShowFilteredOutDateEntries = timeRangeChange.ShowFilteredOut;
                    ProgSettings.FilterDateStart = timeRangeChange.StartDate;
                    ProgSettings.FilterDateEnd = timeRangeChange.EndDate;

                    ProgSettings.Save();
                    ApplyTimeRangeText();

                    // this is kind of a lazy way of delaying the filter application until after
                    // the duration for the control/time entry is updated
                    new Thread(() =>
                    {
                        Thread.Sleep(500);
                        SortAndFilterEntries();
                    }).Start();

                    SortAndFilterEntries();
                    if (trackingInfoPage.Visible)
                        trackingInfoPage.ReloadData();
                }
            });
        }
        private void ApplyTimeRangeText()
        {
            this.Text = $"Program Tracker ({ProgSettings.RangeToString()})";
        }

        private void menu_ShowGraph_Click(object sender, EventArgs e)
        {
            var selections = GetSelectedTrackingItems().Select(x => x.GetVisibleName()).ToArray();
            Frm_Graph graph = new Frm_Graph(selections);
            graph.Show();
        }

        private void lbl_RunAsAdmin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Some programs have issues getting the icons and detecting when they close if " +
                "this program isn't being run as an administrator.\n\nDo you want to hide this message from the program?",
                "Program not being run as administrator",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ProgSettings.AcknowledgedNonAdminMessage = true;
                ProgSettings.Save();
                lbl_RunAsAdmin.Visible = false;
            }
        }

        private void Ctrl_TrackingItems_Click(object sender, EventArgs e)
        {
            // This is currently unused
        }

        private void chbx_ShowChecks_CheckedChanged(object sender, EventArgs e)
        {
            var trackingItems = GetAllTrackingItems();

            foreach (var item in trackingItems)
            {
                item.CheckboxVisible = chbx_ShowChecks.Checked;
                if (!chbx_ShowChecks.Checked && item.IsMultiSelected)
                    item.IsMultiSelected = false;
            }
        }

        #endregion
        #region Multi-select tracking item controls

        private void TrackingControlSelectionToggled(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Ctrl_TrackingItem))
                return;
            Ctrl_TrackingItem trackingItem = (Ctrl_TrackingItem)sender;
            //Console.WriteLine("clicked: " + trackingItem.GetVisibleName());

            int clickedIndex = trackingItem.Parent.Controls.IndexOf(trackingItem);

            //if ((ModifierKeys & Keys.Control) == Keys.Control)
            if (ModifierKeys == Keys.Control) // only control
            {
                trackingItem.IsMultiSelected = !trackingItem.IsMultiSelected;
            }
            //else if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            else if (ModifierKeys == Keys.Shift && lastClickedControlIndex != -1) // only shift
            {

                int interval = lastClickedControlIndex - clickedIndex;
                if (interval == 0)
                    interval = 1;
                interval = interval / Math.Abs(interval);

                int i = clickedIndex;
                while (i != lastClickedControlIndex)
                {
                    try
                    {
                        Ctrl_TrackingItem item = (Ctrl_TrackingItem)trackingItem.Parent.Controls[i];
                        item.IsMultiSelected = true;
                        //item.IsSelected = true;
                    }
                    catch{}

                    i += interval;
                }
            }

            lastClickedControlIndex = clickedIndex;

            bool allSelected = GetSelectedTrackingItems(true).Count() == 0;
            bool anythingSelected = GetSelectedTrackingItems().Count() > 0;

            // enable and disable controls based on something being selected
            if (anythingSelected)
            {
                menuEdit_DeleteSelection.Visible = true;
                menuTS_DeleteSelection.Visible = true;
                menuEdit_ExportSelection.Visible = true;
            }
            else
            {
                menuEdit_DeleteSelection.Visible = false;
                menuTS_DeleteSelection.Visible = false;
                menuEdit_ExportSelection.Visible = false;
            }

            if (allSelected)
                btn_ToggleSelectAll.Text = "Deselect All";
            else
                btn_ToggleSelectAll.Text = "Select All";
        }

        #endregion
        #region Group button controls

        void AddButtonToGroupTabs(string buttonText)
        {
            var btn = CustomExtensions.FilterGroupButton(buttonText);
            btn.ClickButton += btn_TabGroup_Click;
            btn.ClickX += btn_TabGroupDelete_Click;
            pnl_Tabs.Controls.Add(btn);
            pnl_Tabs.Controls.SetChildIndex(btn, 1);

            pnl_Tabs.Width = pnl_Tabs.Controls.OfType<Control>().Sum(x => x.Width);
        }
        void RemoveButtonFromGroupTabs(Ctrl_ButtonWithX ctrl)
        {
            var currentItems = MasterTracker.ProcessTrackers.Values
                              .Where(x => x.GetGroups().Contains(ctrl.ButtonText));

            foreach (var item in currentItems)
                item.GetFormControl().Groups = item.GetGroups().Where(x => x != ctrl.ButtonText).ToList();

            ctrl.Dispose();

            pnl_Tabs.Width = pnl_Tabs.Controls.OfType<Control>().Sum(x => x.Width);
            pnl_TabsParent_Resize(pnl_Tabs, new EventArgs());
        }

        void ScrollTabBar(bool moveRight)
        {
            var pos = pnl_Tabs.Location;

            pos.X += (moveRight) ? -50 : 50;

            if (pnl_Tabs.Width < pnl_TabsParent.Width)
                pos.X = 0;
            else if (pos.X < -(pnl_Tabs.Width - pnl_TabsParent.Width))
                pos.X = -(pnl_Tabs.Width - pnl_TabsParent.Width);
            else if (pos.X > 0)
                pos.X = 0;

            pnl_Tabs.Location = pos;
        }


        private void btn_AddGroup_Click(object sender, EventArgs e)
        {
            Tracker selection = selectedTrackingItemForMenu;

            Frm_PopupTextbox popup = new Frm_PopupTextbox("What is the name of the group you want to create?", "New Group", acceptButtonText:"Add");

            if (popup.ShowDialog() != DialogResult.OK)
                return;
            

            string groupName = popup.ReturnText;

            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Group name is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (ProgSettings.ProgramGroups.Keys.Contains(groupName))
            {
                MessageBox.Show($"A group with name '{groupName}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // actually create the group

            //ProgSettings.ProgramGroups.Add(groupName, new List<string>());
            ProgSettings.ProgramGroups[groupName] = new List<string>();

            AddButtonToGroupTabs(groupName);
            //var btn = CustomExtensions.FilterGroupButton(groupName);
            //btn.ClickButton += btn_TabGroup_Click;
            //btn.ClickX += btn_TabGroupDelete_Click;

            //pnl_Tabs.Controls.Add(btn);
            //pnl_Tabs.Controls.SetChildIndex(btn, 1);

            if (selection != null)
                AddProgramToGroup(groupName, selection.ProcessName);

            ProgSettings.Save();
        }

        private void btn_TabGroupDelete_Click(object sender, EventArgs e)
        {
            Ctrl_ButtonWithX btn = sender as Ctrl_ButtonWithX;

            
            if (MessageBox.Show($"Delete program group '{btn.ButtonText}'\nAre you sure?", "Delete?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RemoveButtonFromGroupTabs(btn);
                ProgSettings.ProgramGroups.Remove(btn.ButtonText);
                //btn.Dispose();
                ProgSettings.Save();

                currentGroupFilter = "";
                SortAndFilterEntries();
            }
        }

        private void btn_TabGroup_Click(object sender, EventArgs e)
        {
            if (sender != btn_GroupAll)
            {
                Ctrl_ButtonWithX btn = sender as Ctrl_ButtonWithX;

                currentGroupFilter = btn.ButtonText;
                SortAndFilterEntries();
            }
            else
            {
                currentGroupFilter = "";
                SortAndFilterEntries();
            }
        }

        private void btn_TabScroll_Click(object sender, EventArgs e)
        {
            if (sender == btn_TabLeft)
                ScrollTabBar(false);
            else if (sender == btn_TabRight)
                ScrollTabBar(true);
        }


        #endregion
        #region tracker item menus
        internal void OpenTrackerData(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                OpenTrackerSettingsMenu(sender, e);
                return;
            }

            try
            {
                // switch controls to only show icons
                foreach (var item in MasterTracker.ProcessTrackers.Values)
                {
                    var ctrl = item.GetFormControl();
                    ctrl.OnlyShowIcon = true;
                }

                // attempt to keep same location in scrolling position
                var scrollPoint = pnl_TrackedProgs.AutoScrollPosition;
                scrollPoint.Y = -scrollPoint.Y;

                // if something is already selected, unselect it
                if (selectedTrackingItem != null)
                    selectedTrackingItem.GetFormControl().IsSelected = false;
                Tracker t = sender as Tracker;

                //Ctrl_TrackingInfo info = new Ctrl_TrackingInfo(t);

                pnl_TrackedProgs.Dock = DockStyle.Right;
                pnl_TrackedProgs.Width = t.GetFormControl().GetIconWidth() + SystemInformation.VerticalScrollBarWidth;

                t.GetFormControl().IsSelected = true;


                trackingInfoPage.LoadData(t);
                trackingInfoPage.Visible = true;

                //pnl_TrackedProgs.AutoScrollPosition = scrollPoint;

                selectedTrackingItem = t;

            }
            catch { }
        }

        internal void OpenTrackerSettingsMenu(object sender, MouseEventArgs e)
        {
            try
            {
                if (removeSelectionTask!= null && removeSelectionTask.IsAlive)
                    removeSelectionTask.Abort();

                Tracker t = sender as Tracker;

                selectedTrackingItemForMenu = t;

                menuTS_RemoveFromGroup.DropDownItems.Clear();
                var currentGroups = selectedTrackingItemForMenu.GetGroups()
                                      .Select(x => CreateRemoveFromGroupItem(x)).ToArray();
                menuTS_RemoveFromGroup.DropDownItems.AddRange(currentGroups);

                menuTS_RemoveFromGroup.Visible = currentGroups.Length > 0;
                //menuTS_RemoveFromGroup.Visible = !string.IsNullOrEmpty(currentGroupFilter);

                menu_TrackerSettings.Show(MousePosition);
            }
            catch { }
        }

        Thread removeSelectionTask = null;
        private void CloseTrackerSettingsMenu(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (removeSelectionTask == null || removeSelectionTask.ThreadState == System.Threading.ThreadState.Aborted)
            {
                removeSelectionTask = new Thread(() =>
                {
                    Thread.Sleep(250);
                    //selectedTrackingItem = null;
                    selectedTrackingItemForMenu = null;
                });
            }
            if (removeSelectionTask.ThreadState == System.Threading.ThreadState.Running)
                removeSelectionTask.Start();
        }

        private ToolStripMenuItem CreateRemoveFromGroupItem(string text)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            item.Click += menuTS_RemoveFromGroupItem_Click;
            return item;
        }


        // TS for Tracker Settings
        private void menuTS_Rename_Click(object sender, EventArgs e)
        {
            Tracker selection = selectedTrackingItemForMenu;
            ProgSettings.ProcessNameOverride.TryGetValue(selection.ProcessName, out string currentName);
            currentName = (currentName == null) ? selection.ProcessName : currentName;

            Frm_PopupTextbox popup = new Frm_PopupTextbox(selection.ProcessName, "Rename Program", currentName, selection:selection);
            popup.FormClosed += RenameDisplayName_Close;

            popup.Show();
            popup.BringToFront();

        }
        private void RenameDisplayName_Close(object sender, EventArgs e)
        {
            Frm_PopupTextbox popup = (Frm_PopupTextbox)sender;
            if (popup.DialogResult == DialogResult.OK)
            {
                string newName = (popup.ReturnText == popup.SelectedTracker.ProcessName) ? "" : popup.ReturnText;
                ProgSettings.SetProcessDisplayName(popup.SelectedTracker.ProcessName, newName);

                if (selectedTrackingItem == popup.SelectedTracker)
                {
                    trackingInfoPage.SetTitle(popup.SelectedTracker.GetVisibleName());
                }

                popup.SelectedTracker.GetFormControl(true);

                SortAndFilterEntries();
            }
        }

        private void menuTS_SetIcon_Click(object sender, EventArgs e)
        {
            Tracker selection = selectedTrackingItemForMenu;
            Frm_SetIcon iconDialog = new Frm_SetIcon(selection.ProcessName);
            iconDialog.ShowDialog();

            if (iconDialog.IconChanged)
            {
                selection.GetFormControl(false).Icon = selection.GetSavedIcon();
                if (selectedTrackingItem == selection)
                {
                    trackingInfoPage.SetIcon(selection.GetSavedIcon());
                }
            }
        }

        internal void DeleteProcessItem(Tracker selection, bool skipDialog=false)
        {
            if (skipDialog ||
                MessageBox.Show($"You will lose all tracking data for '{selection.GetVisibleName()}'.", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // delete icon
                selectedTrackingItemForMenu = selection; // reapply just in case
                menuTS_DeleteIcon_Click(this, EventArgs.Empty);

                MasterTracker.RemoveTrackingData(selection.ProcessName);
                Process remover = Process.GetProcessesByName(selection.ProcessName).FirstOrDefault();
                if (remover != null)
                {
                    OpenProcesses.Remove(remover.Id);
                    remover.Exited -= eventProgramExit;
                }

                if (trackingInfoPage.Visible == true)
                    trackingInfoPage.CloseTrackingWindow();
            }
            SortAndFilterEntries();
        }
        private void menuTS_Delete_Click(object sender, EventArgs e)
        {
            DeleteProcessItem(selectedTrackingItemForMenu);
        }

        private void menuTS_DeleteSelection_Click(object sender, EventArgs e)
        {
            // Use the same event that is used in the 'Edit' menu. Yeah I know I could just assign this button to use that event the normal way.
            menuEdit_DeleteSelection_Click(sender, e);
        }

        private void menuTS_Blacklist_Click(object sender, EventArgs e)
        {
            Tracker selection = selectedTrackingItemForMenu;
            if (MessageBox.Show($"This will delete all tracking data for '{selection.GetVisibleName()}', and it won't be added again.", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // delete icon
                selectedTrackingItemForMenu = selection; // reapply just in case
                menuTS_DeleteIcon_Click(sender, e);

                MasterTracker.RemoveTrackingData(selection.ProcessName);

                // Remove from whitelist if it was a custom addition
                if (ProgSettings.WhitelistProcesses.Contains(selection.ProcessName))
                    ProgSettings.WhitelistProcesses.Remove(selection.ProcessName);
                
                ProgSettings.IgnoreList.Add(selection.ProcessName);

                ProgSettings.Save();

                if (trackingInfoPage.Visible == true)
                    trackingInfoPage.CloseTrackingWindow();
            }
            SortAndFilterEntries();
        }

        private void menuTS_DeleteIcon_Click(object sender, EventArgs e)
        {
            Tracker selection = selectedTrackingItemForMenu;
            string iconPath = Path.Combine(Settings.GetIconsDirectory(), selection.ProcessName + ".png");

            if (File.Exists(iconPath))
            {
                File.Delete(iconPath);
                selection.GetFormControl().Icon = null;
            }
            if (selectedTrackingItem == selection)
            {
                trackingInfoPage.SetIcon(selectedTrackingItem.GetFormControl(false).Icon);
            }

        }

        private void menuTS_AddToGroup_Open(object sender, EventArgs e)
        {
            Tracker selection = selectedTrackingItemForMenu;

            for (int i = menuTS_AddToGroup.DropDownItems.Count - 1; i >= 1; i--)
            {
                menuTS_AddToGroup.DropDownItems[i].Dispose();
            }

            foreach (var item in ProgSettings.ProgramGroups.Keys.Where(x => !ProgSettings.ProgramGroups[x].Contains(selection.ProcessName)).Reverse())
            {
                var a = new ToolStripMenuItem(item);
                a.Click += menuTS_AddToGroupElement_Click;

                menuTS_AddToGroup.DropDownItems.Add(a);
            }
        }
        private void menuTS_AddToGroupElement_Click(object sender, EventArgs e)
        {
            var groupName = sender as ToolStripMenuItem;
            Tracker selection = selectedTrackingItemForMenu;

            AddProgramToGroup(groupName.Text, selection.ProcessName);
        }

        private void menuTS_CreateNewGroup_Click(object sender, EventArgs e)
        {
            btn_AddGroup_Click(sender, e);
            selectedTrackingItemForMenu = null;
        }

        private void menuTS_RemoveFromGroupItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string removeFrom = item.Text;

            Tracker selection = selectedTrackingItemForMenu;

            try
            {
                ProgSettings.ProgramGroups[removeFrom].Remove(selection.ProcessName);
                ProgSettings.Save();
                selection.GetFormControl().Groups = selection.GetGroups();

                if (currentGroupFilter == removeFrom)
                    selection.GetFormControl().Visible = false;
            }
            catch
            {
                Console.WriteLine("failed to remove from group");
            }
        }


        #endregion
        #region Edit menu

        private void menuEdit_AddProcess_Click(object sender, EventArgs e)
        {
            Frm_AddProcess popup = new Frm_AddProcess();
            popup.Show();
            popup.Location = this.Location;
        }

        private void menuEdit_IgnoreList_Click(object sender, EventArgs e)
        {
            Frm_EditBlacklist popup = new Frm_EditBlacklist();
            popup.Show();
            popup.Location = this.Location;
        }

        private void menuEdit_Merge_Click(object sender, EventArgs e)
        {
            Frm_MergeProcesses popup = new Frm_MergeProcesses(MasterTracker);
            popup.Show();
        }

        private void menuEdit_DeleteSelection_Click(object sender, EventArgs e)
        {
            // can't use IEnumerable here because it gets messed up in the foreach loop while deleting items
            var selection = GetSelectedTrackingItems().Select(x => x.ParentTracker).ToList();
            string text = "";
            if (selection.Count() <= 10)
                text = string.Join("\n", selection.Select(x => x.GetVisibleName()));
            else
            {
                //var slice = new ArraySegment<string>(selection.Select(x => x.GetVisibleName()).ToArray(), 0, 10);
                var slice = selection.Take(10);
                text = string.Join("\n", slice.Select(x => x.GetVisibleName()));
                text += "\n...";
            }
            
            if (MessageBox.Show($"Delete all tracking data for {selection.Count()} item(s).\n\n{text}", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Tracker item in selection)
                    DeleteProcessItem(item, true);
            }

            //foreach (var item in GetSelectedTrackingItems())
            //{
            //    item.IsMultiSelected = false;
            //}
            SortAndFilterEntries();
        }

        private void menuEdit_Unmerge_Click(object sender, EventArgs e)
        {
            Frm_UnmergeProcesses popup = new Frm_UnmergeProcesses();
            popup.Show();
        }

        private void menuEdit_Minimized_Click(object sender, EventArgs e)
        {
            ProgSettings.StartMinimized = menuEdit_Minimized.Checked;
            ProgSettings.Save();
        }

        private void menuEdit_AutoStart_Click(object sender, EventArgs e)
        {
            SetAutoStart(menuEdit_AutoStart.Checked);
        }

        private void menuEdit_DeleteIcons_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Settings.GetIconsDirectory()))
                return;


            string[] allIcons = Directory.GetFiles(Settings.GetIconsDirectory(), "*.png");
            var allProcesses = MasterTracker.ProcessTrackers.Keys.ToList();
            List<string> removers = new List<string>();

            foreach (string icon in allIcons)
            {
                string pName = Path.GetFileNameWithoutExtension(icon);
                if (allProcesses.Contains(pName) == false)
                    removers.Add(icon);
            }

            if (MessageBox.Show($"This will remove {removers.Count} icon(s).\nDo you want to proceed?",
                                "Delete icons?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (string icon in removers)
                    File.Delete(icon);

            }
        }

        private void menuEdit_ExportSelection_Click(object sender, EventArgs e)
        {
            var selection = GetSelectedTrackingItems().Select(x => x.ParentTracker).ToArray();

            if (selection.Any() == false)
                return;

            Frm_ExportTrackers popup = new Frm_ExportTrackers(selection);

            popup.Show();
        }

        private void menuEdit_Debug_Click(object sender, EventArgs e)
        {
            ProgSettings.DebugMode = menuEdit_Debug.Checked;
            ProgSettings.Save();
        }

        #endregion
        #region Notify menu

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterTracker.UpdateAllTimes();
            Show();
            tmr_UpdateTimes.Start();
            WindowState = FormWindowState.Normal;
            Activate();
            SortAndFilterEntries();
            BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actuallyClosing = true;
            Close();
        }
        #endregion

        #endregion
    }
}

namespace ProgramTracker
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.tmr_CheckProcesses = new System.Windows.Forms.Timer(this.components);
            this.menu_TrackerSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuTS_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS_SetIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS_Blacklist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS_DeleteIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS_AddToGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS_CreateNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS_RemoveFromGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmr_UpdateTimes = new System.Windows.Forms.Timer(this.components);
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_AddProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_IgnoreList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_Merge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_Unmerge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_DeleteIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_Minimized = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_AutoStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Sort = new System.Windows.Forms.ToolStripComboBox();
            this.menu_TimeRange = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ShowGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.taskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_Notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_TrackedProgs = new System.Windows.Forms.Panel();
            this.pnl_Stopped = new System.Windows.Forms.Panel();
            this.lbl_Stopped = new System.Windows.Forms.Label();
            this.pnl_Running = new System.Windows.Forms.Panel();
            this.lbl_Running = new System.Windows.Forms.Label();
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.pnl_TabsParent = new System.Windows.Forms.Panel();
            this.pnl_Tabs = new System.Windows.Forms.Panel();
            this.btn_AddGroup = new System.Windows.Forms.Button();
            this.btn_GroupAll = new System.Windows.Forms.Button();
            this.pnl_TopRightButtons = new System.Windows.Forms.Panel();
            this.btn_TabRight = new System.Windows.Forms.Button();
            this.btn_TabLeft = new System.Windows.Forms.Button();
            this.btn_ClearSearch = new System.Windows.Forms.Button();
            this.lbl_RunAsAdmin = new System.Windows.Forms.Label();
            this.tmr_AutoSave = new System.Windows.Forms.Timer(this.components);
            this.txbx_Search = new ProgramTracker.TextBoxModified();
            this.menu_TrackerSettings.SuspendLayout();
            this.topMenu.SuspendLayout();
            this.menu_Notify.SuspendLayout();
            this.pnl_TrackedProgs.SuspendLayout();
            this.pnl_Stopped.SuspendLayout();
            this.pnl_Running.SuspendLayout();
            this.pnl_Top.SuspendLayout();
            this.pnl_TabsParent.SuspendLayout();
            this.pnl_Tabs.SuspendLayout();
            this.pnl_TopRightButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_CheckProcesses
            // 
            this.tmr_CheckProcesses.Enabled = true;
            this.tmr_CheckProcesses.Interval = 8500;
            this.tmr_CheckProcesses.Tick += new System.EventHandler(this.tmr_CheckProcesses_Tick);
            // 
            // menu_TrackerSettings
            // 
            this.menu_TrackerSettings.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menu_TrackerSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTS_Rename,
            this.menuTS_SetIcon,
            this.menuTS_Delete,
            this.menuTS_Blacklist,
            this.menuTS_DeleteIcon,
            this.menuTS_AddToGroup,
            this.menuTS_RemoveFromGroup});
            this.menu_TrackerSettings.Name = "menu_TrackerSettings";
            this.menu_TrackerSettings.Size = new System.Drawing.Size(204, 158);
            this.menu_TrackerSettings.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.CloseTrackerSettingsMenu);
            // 
            // menuTS_Rename
            // 
            this.menuTS_Rename.Name = "menuTS_Rename";
            this.menuTS_Rename.Size = new System.Drawing.Size(203, 22);
            this.menuTS_Rename.Text = "Change display name";
            this.menuTS_Rename.Click += new System.EventHandler(this.menuTS_Rename_Click);
            // 
            // menuTS_SetIcon
            // 
            this.menuTS_SetIcon.Name = "menuTS_SetIcon";
            this.menuTS_SetIcon.Size = new System.Drawing.Size(203, 22);
            this.menuTS_SetIcon.Text = "Change icon image";
            this.menuTS_SetIcon.Click += new System.EventHandler(this.menuTS_SetIcon_Click);
            // 
            // menuTS_Delete
            // 
            this.menuTS_Delete.Name = "menuTS_Delete";
            this.menuTS_Delete.Size = new System.Drawing.Size(203, 22);
            this.menuTS_Delete.Text = "Delete tracking data";
            this.menuTS_Delete.Click += new System.EventHandler(this.menuTS_Delete_Click);
            // 
            // menuTS_Blacklist
            // 
            this.menuTS_Blacklist.Name = "menuTS_Blacklist";
            this.menuTS_Blacklist.Size = new System.Drawing.Size(203, 22);
            this.menuTS_Blacklist.Text = "Don\'t track this program";
            this.menuTS_Blacklist.Click += new System.EventHandler(this.menuTS_Blacklist_Click);
            // 
            // menuTS_DeleteIcon
            // 
            this.menuTS_DeleteIcon.Name = "menuTS_DeleteIcon";
            this.menuTS_DeleteIcon.Size = new System.Drawing.Size(203, 22);
            this.menuTS_DeleteIcon.Text = "Delete Icon";
            this.menuTS_DeleteIcon.Click += new System.EventHandler(this.menuTS_DeleteIcon_Click);
            // 
            // menuTS_AddToGroup
            // 
            this.menuTS_AddToGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTS_CreateNewGroup});
            this.menuTS_AddToGroup.Name = "menuTS_AddToGroup";
            this.menuTS_AddToGroup.Size = new System.Drawing.Size(203, 22);
            this.menuTS_AddToGroup.Text = "Add to group";
            this.menuTS_AddToGroup.DropDownOpening += new System.EventHandler(this.menuTS_AddToGroup_Open);
            // 
            // menuTS_CreateNewGroup
            // 
            this.menuTS_CreateNewGroup.Name = "menuTS_CreateNewGroup";
            this.menuTS_CreateNewGroup.Size = new System.Drawing.Size(168, 22);
            this.menuTS_CreateNewGroup.Text = "Create new group";
            this.menuTS_CreateNewGroup.Click += new System.EventHandler(this.menuTS_CreateNewGroup_Click);
            // 
            // menuTS_RemoveFromGroup
            // 
            this.menuTS_RemoveFromGroup.Name = "menuTS_RemoveFromGroup";
            this.menuTS_RemoveFromGroup.Size = new System.Drawing.Size(203, 22);
            this.menuTS_RemoveFromGroup.Text = "Remove from group";
            // 
            // tmr_UpdateTimes
            // 
            this.tmr_UpdateTimes.Enabled = true;
            this.tmr_UpdateTimes.Interval = 1000;
            this.tmr_UpdateTimes.Tick += new System.EventHandler(this.tmr_UpdateTimes_Tick);
            // 
            // topMenu
            // 
            this.topMenu.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Edit,
            this.menu_Sort,
            this.menu_TimeRange,
            this.menu_ShowGraph});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.topMenu.Size = new System.Drawing.Size(519, 27);
            this.topMenu.TabIndex = 12;
            this.topMenu.Text = "menuStrip1";
            // 
            // menu_Edit
            // 
            this.menu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit_AddProcess,
            this.menuEdit_IgnoreList,
            this.menuEdit_Merge,
            this.menuEdit_Unmerge,
            this.menuEdit_DeleteIcons,
            this.menuEdit_Minimized,
            this.menuEdit_AutoStart});
            this.menu_Edit.Name = "menu_Edit";
            this.menu_Edit.Size = new System.Drawing.Size(39, 23);
            this.menu_Edit.Text = "Edit";
            // 
            // menuEdit_AddProcess
            // 
            this.menuEdit_AddProcess.Name = "menuEdit_AddProcess";
            this.menuEdit_AddProcess.Size = new System.Drawing.Size(187, 22);
            this.menuEdit_AddProcess.Text = "Add custom process";
            this.menuEdit_AddProcess.Click += new System.EventHandler(this.menuEdit_AddProcess_Click);
            // 
            // menuEdit_IgnoreList
            // 
            this.menuEdit_IgnoreList.Name = "menuEdit_IgnoreList";
            this.menuEdit_IgnoreList.Size = new System.Drawing.Size(187, 22);
            this.menuEdit_IgnoreList.Text = "Edit ignore list";
            this.menuEdit_IgnoreList.Click += new System.EventHandler(this.menuEdit_IgnoreList_Click);
            // 
            // menuEdit_Merge
            // 
            this.menuEdit_Merge.Name = "menuEdit_Merge";
            this.menuEdit_Merge.Size = new System.Drawing.Size(187, 22);
            this.menuEdit_Merge.Text = "Merge tracking data";
            this.menuEdit_Merge.Click += new System.EventHandler(this.menuEdit_Merge_Click);
            // 
            // menuEdit_Unmerge
            // 
            this.menuEdit_Unmerge.Name = "menuEdit_Unmerge";
            this.menuEdit_Unmerge.Size = new System.Drawing.Size(187, 22);
            this.menuEdit_Unmerge.Text = "Remove alt processes";
            this.menuEdit_Unmerge.Click += new System.EventHandler(this.menuEdit_Unmerge_Click);
            // 
            // menuEdit_DeleteIcons
            // 
            this.menuEdit_DeleteIcons.Name = "menuEdit_DeleteIcons";
            this.menuEdit_DeleteIcons.Size = new System.Drawing.Size(187, 22);
            this.menuEdit_DeleteIcons.Text = "Delete unused icons";
            this.menuEdit_DeleteIcons.Click += new System.EventHandler(this.menuEdit_DeleteIcons_Click);
            // 
            // menuEdit_Minimized
            // 
            this.menuEdit_Minimized.CheckOnClick = true;
            this.menuEdit_Minimized.Name = "menuEdit_Minimized";
            this.menuEdit_Minimized.Size = new System.Drawing.Size(187, 22);
            this.menuEdit_Minimized.Text = "Start minimized";
            this.menuEdit_Minimized.Click += new System.EventHandler(this.menuEdit_Minimized_Click);
            // 
            // menuEdit_AutoStart
            // 
            this.menuEdit_AutoStart.CheckOnClick = true;
            this.menuEdit_AutoStart.Name = "menuEdit_AutoStart";
            this.menuEdit_AutoStart.Size = new System.Drawing.Size(187, 22);
            this.menuEdit_AutoStart.Text = "Start with Windows";
            this.menuEdit_AutoStart.Click += new System.EventHandler(this.menuEdit_AutoStart_Click);
            // 
            // menu_Sort
            // 
            this.menu_Sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menu_Sort.Items.AddRange(new object[] {
            "Alphabetical   ",
            "Duration         ",
            "Most Recent   "});
            this.menu_Sort.Name = "menu_Sort";
            this.menu_Sort.Size = new System.Drawing.Size(114, 23);
            // 
            // menu_TimeRange
            // 
            this.menu_TimeRange.AccessibleName = "Time Range";
            this.menu_TimeRange.Name = "menu_TimeRange";
            this.menu_TimeRange.Size = new System.Drawing.Size(81, 23);
            this.menu_TimeRange.Text = "Time Range";
            this.menu_TimeRange.Click += new System.EventHandler(this.menu_TimeRange_Click);
            // 
            // menu_ShowGraph
            // 
            this.menu_ShowGraph.Name = "menu_ShowGraph";
            this.menu_ShowGraph.Size = new System.Drawing.Size(83, 23);
            this.menu_ShowGraph.Text = "Show Graph";
            this.menu_ShowGraph.Click += new System.EventHandler(this.menu_ShowGraph_Click);
            // 
            // taskbarIcon
            // 
            this.taskbarIcon.ContextMenuStrip = this.menu_Notify;
            this.taskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskbarIcon.Icon")));
            this.taskbarIcon.Text = "Program Tracker";
            this.taskbarIcon.Visible = true;
            this.taskbarIcon.DoubleClick += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // menu_Notify
            // 
            this.menu_Notify.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menu_Notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menu_Notify.Name = "menu_Notify";
            this.menu_Notify.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pnl_TrackedProgs
            // 
            this.pnl_TrackedProgs.AutoScroll = true;
            this.pnl_TrackedProgs.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_TrackedProgs.Controls.Add(this.pnl_Stopped);
            this.pnl_TrackedProgs.Controls.Add(this.pnl_Running);
            this.pnl_TrackedProgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_TrackedProgs.Location = new System.Drawing.Point(0, 69);
            this.pnl_TrackedProgs.Name = "pnl_TrackedProgs";
            this.pnl_TrackedProgs.Size = new System.Drawing.Size(519, 393);
            this.pnl_TrackedProgs.TabIndex = 13;
            // 
            // pnl_Stopped
            // 
            this.pnl_Stopped.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnl_Stopped.Controls.Add(this.lbl_Stopped);
            this.pnl_Stopped.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Stopped.Location = new System.Drawing.Point(0, 20);
            this.pnl_Stopped.Name = "pnl_Stopped";
            this.pnl_Stopped.Size = new System.Drawing.Size(519, 20);
            this.pnl_Stopped.TabIndex = 3;
            // 
            // lbl_Stopped
            // 
            this.lbl_Stopped.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_Stopped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Stopped.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Stopped.ForeColor = System.Drawing.Color.White;
            this.lbl_Stopped.Location = new System.Drawing.Point(0, 0);
            this.lbl_Stopped.Name = "lbl_Stopped";
            this.lbl_Stopped.Size = new System.Drawing.Size(519, 20);
            this.lbl_Stopped.TabIndex = 1;
            this.lbl_Stopped.Text = "Stopped Programs";
            this.lbl_Stopped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Running
            // 
            this.pnl_Running.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnl_Running.Controls.Add(this.lbl_Running);
            this.pnl_Running.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Running.Location = new System.Drawing.Point(0, 0);
            this.pnl_Running.Name = "pnl_Running";
            this.pnl_Running.Size = new System.Drawing.Size(519, 20);
            this.pnl_Running.TabIndex = 2;
            // 
            // lbl_Running
            // 
            this.lbl_Running.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_Running.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Running.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Running.ForeColor = System.Drawing.Color.White;
            this.lbl_Running.Location = new System.Drawing.Point(0, 0);
            this.lbl_Running.Name = "lbl_Running";
            this.lbl_Running.Size = new System.Drawing.Size(519, 20);
            this.lbl_Running.TabIndex = 0;
            this.lbl_Running.Text = "Running Programs";
            this.lbl_Running.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Top
            // 
            this.pnl_Top.Controls.Add(this.txbx_Search);
            this.pnl_Top.Controls.Add(this.pnl_TabsParent);
            this.pnl_Top.Controls.Add(this.pnl_TopRightButtons);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 27);
            this.pnl_Top.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(519, 42);
            this.pnl_Top.TabIndex = 0;
            // 
            // pnl_TabsParent
            // 
            this.pnl_TabsParent.Controls.Add(this.pnl_Tabs);
            this.pnl_TabsParent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_TabsParent.Location = new System.Drawing.Point(0, 19);
            this.pnl_TabsParent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.pnl_TabsParent.Name = "pnl_TabsParent";
            this.pnl_TabsParent.Size = new System.Drawing.Size(481, 23);
            this.pnl_TabsParent.TabIndex = 4;
            this.pnl_TabsParent.Resize += new System.EventHandler(this.pnl_TabsParent_Resize);
            // 
            // pnl_Tabs
            // 
            this.pnl_Tabs.Controls.Add(this.btn_AddGroup);
            this.pnl_Tabs.Controls.Add(this.btn_GroupAll);
            this.pnl_Tabs.Location = new System.Drawing.Point(0, 0);
            this.pnl_Tabs.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Tabs.Name = "pnl_Tabs";
            this.pnl_Tabs.Size = new System.Drawing.Size(464, 23);
            this.pnl_Tabs.TabIndex = 3;
            // 
            // btn_AddGroup
            // 
            this.btn_AddGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_AddGroup.FlatAppearance.BorderSize = 0;
            this.btn_AddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddGroup.Location = new System.Drawing.Point(52, 0);
            this.btn_AddGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_AddGroup.Name = "btn_AddGroup";
            this.btn_AddGroup.Size = new System.Drawing.Size(21, 23);
            this.btn_AddGroup.TabIndex = 0;
            this.btn_AddGroup.Text = "+";
            this.btn_AddGroup.UseVisualStyleBackColor = true;
            this.btn_AddGroup.Click += new System.EventHandler(this.btn_AddGroup_Click);
            // 
            // btn_GroupAll
            // 
            this.btn_GroupAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_GroupAll.Location = new System.Drawing.Point(0, 0);
            this.btn_GroupAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_GroupAll.Name = "btn_GroupAll";
            this.btn_GroupAll.Size = new System.Drawing.Size(52, 23);
            this.btn_GroupAll.TabIndex = 2;
            this.btn_GroupAll.Text = "All";
            this.btn_GroupAll.UseVisualStyleBackColor = true;
            this.btn_GroupAll.Click += new System.EventHandler(this.btn_TabGroup_Click);
            // 
            // pnl_TopRightButtons
            // 
            this.pnl_TopRightButtons.Controls.Add(this.btn_TabRight);
            this.pnl_TopRightButtons.Controls.Add(this.btn_TabLeft);
            this.pnl_TopRightButtons.Controls.Add(this.btn_ClearSearch);
            this.pnl_TopRightButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_TopRightButtons.Location = new System.Drawing.Point(481, 0);
            this.pnl_TopRightButtons.Name = "pnl_TopRightButtons";
            this.pnl_TopRightButtons.Size = new System.Drawing.Size(38, 42);
            this.pnl_TopRightButtons.TabIndex = 3;
            // 
            // btn_TabRight
            // 
            this.btn_TabRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_TabRight.FlatAppearance.BorderSize = 0;
            this.btn_TabRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TabRight.Location = new System.Drawing.Point(19, 19);
            this.btn_TabRight.Name = "btn_TabRight";
            this.btn_TabRight.Size = new System.Drawing.Size(19, 23);
            this.btn_TabRight.TabIndex = 4;
            this.btn_TabRight.Text = ">";
            this.btn_TabRight.UseVisualStyleBackColor = true;
            this.btn_TabRight.Click += new System.EventHandler(this.btn_TabScroll_Click);
            // 
            // btn_TabLeft
            // 
            this.btn_TabLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_TabLeft.FlatAppearance.BorderSize = 0;
            this.btn_TabLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TabLeft.Location = new System.Drawing.Point(0, 19);
            this.btn_TabLeft.Name = "btn_TabLeft";
            this.btn_TabLeft.Size = new System.Drawing.Size(19, 23);
            this.btn_TabLeft.TabIndex = 3;
            this.btn_TabLeft.Text = "<";
            this.btn_TabLeft.UseVisualStyleBackColor = true;
            this.btn_TabLeft.Click += new System.EventHandler(this.btn_TabScroll_Click);
            // 
            // btn_ClearSearch
            // 
            this.btn_ClearSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ClearSearch.FlatAppearance.BorderSize = 0;
            this.btn_ClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearSearch.Location = new System.Drawing.Point(0, 0);
            this.btn_ClearSearch.Name = "btn_ClearSearch";
            this.btn_ClearSearch.Size = new System.Drawing.Size(38, 19);
            this.btn_ClearSearch.TabIndex = 2;
            this.btn_ClearSearch.Text = "X";
            this.btn_ClearSearch.UseVisualStyleBackColor = true;
            this.btn_ClearSearch.Click += new System.EventHandler(this.btn_ClearSearch_Click);
            // 
            // lbl_RunAsAdmin
            // 
            this.lbl_RunAsAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_RunAsAdmin.AutoSize = true;
            this.lbl_RunAsAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_RunAsAdmin.Location = new System.Drawing.Point(362, 0);
            this.lbl_RunAsAdmin.Name = "lbl_RunAsAdmin";
            this.lbl_RunAsAdmin.Size = new System.Drawing.Size(157, 13);
            this.lbl_RunAsAdmin.TabIndex = 4;
            this.lbl_RunAsAdmin.Text = "Program is not running as admin";
            this.lbl_RunAsAdmin.Click += new System.EventHandler(this.lbl_RunAsAdmin_Click);
            // 
            // tmr_AutoSave
            // 
            this.tmr_AutoSave.Enabled = true;
            this.tmr_AutoSave.Interval = 1800000;
            this.tmr_AutoSave.Tag = "30 minutes";
            this.tmr_AutoSave.Tick += new System.EventHandler(this.tmr_AutoSave_Tick);
            // 
            // txbx_Search
            // 
            this.txbx_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbx_Search.ForeColor = System.Drawing.Color.Gray;
            this.txbx_Search.Location = new System.Drawing.Point(0, 0);
            this.txbx_Search.Margin = new System.Windows.Forms.Padding(2);
            this.txbx_Search.Name = "txbx_Search";
            this.txbx_Search.RealText = "";
            this.txbx_Search.Size = new System.Drawing.Size(481, 20);
            this.txbx_Search.TabIndex = 1;
            this.txbx_Search.Text = "Search Processes";
            this.txbx_Search.TextPlaceholder = "Search Processes";
            this.txbx_Search.TextPlaceholderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txbx_Search.TextChangedFixed += new System.EventHandler(this.eventSearchPrograms);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 462);
            this.Controls.Add(this.lbl_RunAsAdmin);
            this.Controls.Add(this.pnl_TrackedProgs);
            this.Controls.Add(this.pnl_Top);
            this.Controls.Add(this.topMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenu;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Frm_Main";
            this.Text = "Program Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.menu_TrackerSettings.ResumeLayout(false);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.menu_Notify.ResumeLayout(false);
            this.pnl_TrackedProgs.ResumeLayout(false);
            this.pnl_Stopped.ResumeLayout(false);
            this.pnl_Running.ResumeLayout(false);
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.pnl_TabsParent.ResumeLayout(false);
            this.pnl_Tabs.ResumeLayout(false);
            this.pnl_TopRightButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmr_CheckProcesses;
        private System.Windows.Forms.ContextMenuStrip menu_TrackerSettings;
        private System.Windows.Forms.ToolStripMenuItem menuTS_Rename;
        private System.Windows.Forms.ToolStripMenuItem menuTS_Delete;
        private System.Windows.Forms.ToolStripMenuItem menuTS_Blacklist;
        private System.Windows.Forms.Timer tmr_UpdateTimes;
        private System.Windows.Forms.ToolStripMenuItem menuTS_DeleteIcon;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem menu_Edit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_AddProcess;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_IgnoreList;
        private System.Windows.Forms.NotifyIcon taskbarIcon;
        private System.Windows.Forms.ContextMenuStrip menu_Notify;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        internal System.Windows.Forms.Panel pnl_TrackedProgs;
        private System.Windows.Forms.Panel pnl_Top;
        private TextBoxModified txbx_Search;
        private System.Windows.Forms.Label lbl_Running;
        private System.Windows.Forms.Label lbl_Stopped;
        private System.Windows.Forms.Panel pnl_Stopped;
        private System.Windows.Forms.Panel pnl_Running;
        private System.Windows.Forms.Button btn_ClearSearch;
        private System.Windows.Forms.Panel pnl_Tabs;
        private System.Windows.Forms.Button btn_AddGroup;
        private System.Windows.Forms.ToolStripMenuItem menuTS_AddToGroup;
        private System.Windows.Forms.ToolStripMenuItem menuTS_CreateNewGroup;
        private System.Windows.Forms.ToolStripMenuItem menuTS_RemoveFromGroup;
        private System.Windows.Forms.Button btn_GroupAll;
        private System.Windows.Forms.Panel pnl_TopRightButtons;
        private System.Windows.Forms.Button btn_TabRight;
        private System.Windows.Forms.Button btn_TabLeft;
        private System.Windows.Forms.Panel pnl_TabsParent;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_Minimized;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_Merge;
        private System.Windows.Forms.ToolStripComboBox menu_Sort;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_AutoStart;
        private System.Windows.Forms.Label lbl_RunAsAdmin;
        private System.Windows.Forms.Timer tmr_AutoSave;
        private System.Windows.Forms.ToolStripMenuItem menuTS_SetIcon;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_DeleteIcons;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_Unmerge;
        private System.Windows.Forms.ToolStripMenuItem menu_TimeRange;
        private System.Windows.Forms.ToolStripMenuItem menu_ShowGraph;
    }
}


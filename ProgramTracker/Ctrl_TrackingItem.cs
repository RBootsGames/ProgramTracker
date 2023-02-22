﻿using System;
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
    public partial class Ctrl_TrackingItem : UserControl
    {
        Tracker l_ParentTracker;
        TimeSpan l_Duration;
        string l_ProcessName;
        bool l_OnlyIcon = false;
        bool l_AltColor = false;
        bool l_IsSelected = false;
        bool isMouseOver = false;
        Color l_SelectedColor = Color.LightBlue;
        Font fontSmall = new Font("Microsoft Sans Serif", 6.5f);
        Font fontLarge = new Font("Microsoft Sans Serif", 9f);

        internal Tracker ParentTracker => l_ParentTracker;


        internal bool FoundInSearch = true;

        [Category("Item Settings")]
        public string ProcessName
        {
            get => l_ProcessName;
            set
            {
                l_ProcessName = value;
                lbl_Proc.Text = value.ToPrettyString();
            }
        }

        [Category("Item Settings")]
        public string DisplayName
        {
            get => lbl_DisplayName.Text;
            set
            {
                lbl_DisplayName.Text = value;
                
                // if display name is empty
                if (string.IsNullOrEmpty(value))
                {
                    lbl_DisplayName.Visible = false;
                    lbl_Proc.Visible = true;
                    lbl_Proc.Dock = DockStyle.Fill;
                    lbl_Proc.Font = fontLarge;
                }
                else
                {
                    lbl_DisplayName.Visible = true;
                    lbl_Proc.Visible = false;
                    lbl_Proc.Dock = DockStyle.Bottom;
                    lbl_Proc.Font = fontSmall;
                    lbl_DisplayName.Font = fontLarge;
                }
            }
        }

        [Category("Item Settings")]
        public TimeSpan Duration
        {
            get => l_Duration;
            set
            {
                l_Duration = value;

                string txt = "";

                if (l_Duration.Days == 1)
                    txt += $"{l_Duration.Days} day\n";
                else if (l_Duration.Days > 1)
                    txt += $"{l_Duration.Days} days\n";

                txt += $"{l_Duration.Hours.ToString("00")}:{l_Duration.Minutes.ToString("00")}:{l_Duration.Seconds.ToString("00")}";

                lbl_Time.Text = txt;
            }
        }

        [Category("Item Settings")]
        public Bitmap Icon
        {
            get => pict_Icon.Image as Bitmap;
            set => pict_Icon.Image = value;
        }

        [Category("Item Settings")]
        public bool UseAltColor
        {
            get => l_AltColor;
            set
            {
                l_AltColor = value;
                ApplyBGColor();
            }
        }

        [Category("Item Settings")]
        public bool IsSelected
        {
            get => l_IsSelected;
            set
            {
                l_IsSelected = value;
                if (l_IsSelected)
                    BackColor = SelectedColor;
                else
                    ApplyBGColor();
            }
        }

        [Category("Item Settings")]
        public Color SelectedColor
        {
            get => l_SelectedColor;
            set => l_SelectedColor = value;
        }

        [Category("Item Settings")]
        public bool OnlyShowIcon
        {
            get => l_OnlyIcon;
            set
            {
                l_OnlyIcon = value;
                if (l_OnlyIcon)
                {
                    lbl_DisplayName.Visible = false;
                    lbl_Proc.Visible = false;
                    lbl_Time.Visible = false;
                    btn_Settings.Visible = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(DisplayName))
                        lbl_Proc.Visible = true;
                    else
                        lbl_DisplayName.Visible = true;
                    lbl_Time.Visible = true;
                    btn_Settings.Visible = true;
                }
            }
        }


        [Category("Action")]
        public event EventHandler SettingClick;

        [Category("Action")]
        public event EventHandler ControlClick;


        internal Ctrl_TrackingItem(Tracker _parentTracker)
        {
            InitializeComponent();
            l_ParentTracker = _parentTracker;
            DisplayName = "";
            Dock = DockStyle.Top;
        }

        internal Ctrl_TrackingItem(string _processName, Tracker _parentTracker, TimeSpan? _duration=null, string _displayName="")
        {
            InitializeComponent();
            ProcessName = _processName;
            l_ParentTracker = _parentTracker;

            Duration = (_duration == null) ? TimeSpan.Zero : (TimeSpan)_duration;
            DisplayName = _displayName;
            Dock = DockStyle.Top;
        }


        public int GetIconWidth() => spacer.Width + pict_Icon.Width + 15;

        private void ApplyBGColor()
        {
            if (IsSelected)
                BackColor = SelectedColor;
            else if (isMouseOver)
                BackColor = Color.LightGray;
            else if (UseAltColor)
                BackColor = SystemColors.ControlLight;
            else if (!UseAltColor)
                BackColor = DefaultBackColor;
            //BackColor = (UseAltColor) ? SystemColors.ControlLight : DefaultBackColor;
        }


        /// <summary></summary>
        /// <returns>Returns the display name if the control has one, otherwise returns the process name.</returns>
        public string GetVisibleName()
        {
            return (string.IsNullOrEmpty(DisplayName)) ? ProcessName.ToPrettyString() : DisplayName;
        }


        private void ControlMouseEnter(object sender, EventArgs e)
        {
            //BackColor = Color.LightGray;
            isMouseOver = true;
            ApplyBGColor();
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            isMouseOver = false;
            ApplyBGColor();
        }

        private void ControlClickEvent(object sender, EventArgs e)
        {

            if (Frm_Main.MasterTracker.ProcessTrackers.TryGetValue(ProcessName, out Tracker t))
            {
                Frm_Main.MainForm.OpenTrackerData(t, (MouseEventArgs)e);
            }

            if (ControlClick != null)
                ControlClick(this, e);
        }

        private void SettingClickEvent(object sender, EventArgs e)
        {
            if (Frm_Main.MasterTracker.ProcessTrackers.TryGetValue(ProcessName, out Tracker t))
            {
                Frm_Main.MainForm.OpenTrackerSettingsMenu(t, (MouseEventArgs)e);
            }


            if (SettingClick != null)
                SettingClick(this, e);
        }

        private void lbl_DisplayName_MouseHover(object sender, EventArgs e)
        {
            if (OnlyShowIcon)
                toolTip1.SetToolTip(sender as Control, (!string.IsNullOrEmpty(DisplayName)) ? DisplayName : ProcessName.ToPrettyString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        bool l_IsMultiSelected = false;
        bool l_IsGrayedOut = false;
        bool isMouseOver = false;
        Color l_SelectedColor = Color.LightBlue;
        Color l_MultiSelectedColor = Color.LightBlue;
        Font fontSmall = new Font("Microsoft Sans Serif", 6.5f);
        Font fontLarge = new Font("Microsoft Sans Serif", 9f);

        internal Tracker ParentTracker => l_ParentTracker;


        internal bool FoundInSearch = true;

        public List<string> Groups
        {
            set
            {
                pnl_Groups.Controls.Clear();
                value.Sort();
                value.Reverse();

                foreach (var group in value)
                {
                    Label lbl = new Label()
                    {
                        Text = group,
                        Dock = DockStyle.Left,
                        AutoSize = true,
                        BorderStyle= BorderStyle.FixedSingle,
                    };

                    lbl.Click += ControlClickEvent;
                    lbl.MouseEnter += ControlMouseEnter;
                    lbl.MouseHover += ControlMouseHover;
                    lbl.MouseLeave += ControlMouseLeave;

                    pnl_Groups.Controls.Add(lbl);
                }

                if (value.Count > 0 && pnl_Groups.Visible == false)
                {
                    Height += pnl_Groups.Height;
                    pnl_Groups.Visible = true;
                    //lbl_DisplayName.TextAlign = ContentAlignment.BottomCenter;
                    //lbl_Proc.TextAlign = ContentAlignment.BottomCenter;
                }
                else if (value.Count == 0 && pnl_Groups.Visible == true)
                {
                    Height -= pnl_Groups.Height;
                    pnl_Groups.Visible = false;
                    //lbl_DisplayName.TextAlign = ContentAlignment.MiddleCenter;
                    //lbl_Proc.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
        }

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
        public bool IsMultiSelected
        {
            get => l_IsMultiSelected;
            set
            {
                l_IsMultiSelected = value;
                checkBox1.Checked = value;
                if (l_IsMultiSelected)
                    BackColor = MultiSelectedColor;
                ApplyBGColor();
            }
        }

        [Category("Item Settings")]
        public bool IsGrayedOut
        {
            get => l_IsGrayedOut;
            set
            {
                l_IsGrayedOut = value;
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
        public Color MultiSelectedColor
        {
            get => l_MultiSelectedColor;
            set => l_MultiSelectedColor = value;
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

        [Category("Item Settings")]
        public bool CheckboxVisible
        {
            get => checkBox1.Visible;
            set
            {
                if (value) // if setting visibility to true
                {
                    spacerLeft.Click -= ControlClickEvent;
                    spacerLeft.Click += CheckboxClickExtendedEvent;
                }
                else
                {
                    spacerLeft.Click -= CheckboxClickExtendedEvent;
                    spacerLeft.Click += ControlClickEvent;
                }
                checkBox1.UpdateOnThread(()=> checkBox1.Visible = value);
            }
        }


        [Category("Action")]
        public event EventHandler SettingClick;

        [Category("Action")]
        public event EventHandler ControlClick;

        [Category("Action")]
        public event EventHandler ClickToggleSelect;


        internal Ctrl_TrackingItem(Tracker _parentTracker)
        {
            InitializeComponent();
            l_ParentTracker = _parentTracker;
            DisplayName = "";
            Dock = DockStyle.Top;
        }

        internal Ctrl_TrackingItem(string _processName, Tracker _parentTracker, TimeSpan? _duration=null, string _displayName="")
            :this(_parentTracker)
        {
            ProcessName = _processName;

            Duration = (_duration == null) ? TimeSpan.Zero : (TimeSpan)_duration;
            DisplayName = _displayName;

            Groups = new List<string>();
        }


        public int GetIconWidth() => spacerLeft.Width + pict_Icon.Width + 15;

        private void ApplyBGColor()
        {
            //if (IsSelected)
            //    BackColor = SelectedColor;
            //else if (IsMultiSelected)
            //    BackColor = MultiSelectedColor;
            //else if (isMouseOver)
            //    BackColor = Color.LightGray; // rgb(211, 211, 211)(#d3d3d3)
            //else if (UseAltColor)
            //    BackColor = SystemColors.ControlLight; // rgb(227, 227, 227)(#e3e3e3)
            //else if (!UseAltColor)
            //    BackColor = DefaultBackColor; // Control rgb(240, 240, 240)(#f0f0f0)
            
            
            if (IsSelected)
                BackColor = SelectedColor;
            else if (IsMultiSelected)
                BackColor = MultiSelectedColor;
            else
                BackColor = DefaultBackColor; // Control rgb(240, 240, 240)(#f0f0f0)

            if (isMouseOver)
            {
                int amount = -29;
                Color c = BackColor;
                BackColor = Color.FromArgb(
                    (c.R + amount).Clamp(0, 255),
                    (c.G + amount).Clamp(0, 255),
                    (c.B + amount).Clamp(0, 255));
                //BackColor = Color.LightGray; // rgb(211, 211, 211)(#d3d3d3)
            }
            else if (UseAltColor)
            {
                int amount = -13;
                Color c = BackColor;
                BackColor = Color.FromArgb(
                    (c.R + amount).Clamp(0, 255),
                    (c.G + amount).Clamp(0, 255),
                    (c.B + amount).Clamp(0, 255));
                //BackColor = SystemColors.ControlLight; // rgb(227, 227, 227)(#e3e3e3)
            }


            if (Duration == TimeSpan.Zero || IsGrayedOut)
            {
                Color c = BackColor;
                BackColor = Color.FromArgb(
                    (int)(c.R * .9),
                    (int)(c.G * .9),
                    (int)(c.B * .9));

                lbl_DisplayName.ForeColor = SystemColors.GrayText;
                lbl_Proc.ForeColor = SystemColors.GrayText;
                lbl_Time.ForeColor = SystemColors.GrayText;
            }
            else
            {
                lbl_DisplayName.ForeColor = DefaultForeColor;
                lbl_Proc.ForeColor = DefaultForeColor;
                lbl_Time.ForeColor = DefaultForeColor;
            }
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

        private void CheckboxClickExtendedEvent(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            checkBox1_MouseClick(sender, e);
        }

        private void ControlClickEvent(object sender, EventArgs e)
        {
            ControlClick?.Invoke(this, e);

            // don't open the tracking data if control or shift are pressed
            if ((ModifierKeys & Keys.Control) == Keys.Control ||
                (ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ClickToggleSelect?.Invoke(this, e);
                return;
            }
            
            if (Frm_Main.MasterTracker.ProcessTrackers.TryGetValue(ProcessName, out Tracker t))
            {
                Frm_Main.MainForm.OpenTrackerData(t, (MouseEventArgs)e);
            }
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

        private void ControlMouseHover(object sender, EventArgs e)
        {
            if (OnlyShowIcon)
                toolTip1.SetToolTip(sender as Control, (!string.IsNullOrEmpty(DisplayName)) ? DisplayName : ProcessName.ToPrettyString());
        }

        private void checkBox1_MouseClick(object sender, EventArgs e)
        {
            IsMultiSelected = checkBox1.Checked;
        }
    }
}

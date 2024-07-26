namespace ProgramTracker
{
    partial class Ctrl_TrackingItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ctrl_TrackingItem));
            this.lbl_Proc = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_DisplayName = new System.Windows.Forms.Label();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.pict_Icon = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.spacerLeft = new System.Windows.Forms.Splitter();
            this.spacerLeft2 = new System.Windows.Forms.Splitter();
            this.pnl_Groups = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Proc
            // 
            this.lbl_Proc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_Proc.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.76F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Proc.Location = new System.Drawing.Point(123, 21);
            this.lbl_Proc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Proc.Name = "lbl_Proc";
            this.lbl_Proc.Size = new System.Drawing.Size(117, 16);
            this.lbl_Proc.TabIndex = 0;
            this.lbl_Proc.Text = "Process Name";
            this.lbl_Proc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Proc.Click += new System.EventHandler(this.ControlClickEvent);
            this.lbl_Proc.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.lbl_Proc.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.lbl_Proc.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // lbl_Time
            // 
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Time.Location = new System.Drawing.Point(240, 0);
            this.lbl_Time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(82, 37);
            this.lbl_Time.TabIndex = 1;
            this.lbl_Time.Text = "2 days\r\n10 h 50 m 25s";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Time.Click += new System.EventHandler(this.ControlClickEvent);
            this.lbl_Time.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.lbl_Time.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // lbl_DisplayName
            // 
            this.lbl_DisplayName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DisplayName.Location = new System.Drawing.Point(123, 0);
            this.lbl_DisplayName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DisplayName.Name = "lbl_DisplayName";
            this.lbl_DisplayName.Size = new System.Drawing.Size(117, 21);
            this.lbl_DisplayName.TabIndex = 2;
            this.lbl_DisplayName.Text = "Display Name";
            this.lbl_DisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DisplayName.Click += new System.EventHandler(this.ControlClickEvent);
            this.lbl_DisplayName.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.lbl_DisplayName.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.lbl_DisplayName.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // btn_Settings
            // 
            this.btn_Settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Settings.BackgroundImage")));
            this.btn_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Settings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Settings.FlatAppearance.BorderSize = 0;
            this.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Settings.Location = new System.Drawing.Point(322, 0);
            this.btn_Settings.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(20, 37);
            this.btn_Settings.TabIndex = 3;
            this.btn_Settings.TabStop = false;
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.SettingClickEvent);
            // 
            // pict_Icon
            // 
            this.pict_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pict_Icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pict_Icon.Location = new System.Drawing.Point(33, 0);
            this.pict_Icon.Name = "pict_Icon";
            this.pict_Icon.Size = new System.Drawing.Size(28, 37);
            this.pict_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict_Icon.TabIndex = 4;
            this.pict_Icon.TabStop = false;
            this.pict_Icon.Click += new System.EventHandler(this.ControlClickEvent);
            this.pict_Icon.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.pict_Icon.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.pict_Icon.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // spacerLeft
            // 
            this.spacerLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.spacerLeft.Location = new System.Drawing.Point(0, 0);
            this.spacerLeft.Name = "spacerLeft";
            this.spacerLeft.Size = new System.Drawing.Size(13, 37);
            this.spacerLeft.TabIndex = 6;
            this.spacerLeft.TabStop = false;
            this.spacerLeft.Click += new System.EventHandler(this.ControlClickEvent);
            this.spacerLeft.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.spacerLeft.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.spacerLeft.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // spacerLeft2
            // 
            this.spacerLeft2.Cursor = System.Windows.Forms.Cursors.Default;
            this.spacerLeft2.Location = new System.Drawing.Point(61, 0);
            this.spacerLeft2.Name = "spacerLeft2";
            this.spacerLeft2.Size = new System.Drawing.Size(62, 37);
            this.spacerLeft2.TabIndex = 7;
            this.spacerLeft2.TabStop = false;
            this.spacerLeft2.Click += new System.EventHandler(this.ControlClickEvent);
            this.spacerLeft2.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.spacerLeft2.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.spacerLeft2.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // pnl_Groups
            // 
            this.pnl_Groups.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Groups.Location = new System.Drawing.Point(0, 37);
            this.pnl_Groups.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Groups.Name = "pnl_Groups";
            this.pnl_Groups.Size = new System.Drawing.Size(342, 15);
            this.pnl_Groups.TabIndex = 8;
            this.pnl_Groups.Click += new System.EventHandler(this.ControlClickEvent);
            this.pnl_Groups.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.pnl_Groups.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.pnl_Groups.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // checkBox1
            // 
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox1.Location = new System.Drawing.Point(13, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(20, 37);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBox1_MouseClick);
            this.checkBox1.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.checkBox1.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.checkBox1.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // Ctrl_TrackingItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lbl_DisplayName);
            this.Controls.Add(this.lbl_Proc);
            this.Controls.Add(this.spacerLeft2);
            this.Controls.Add(this.pict_Icon);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.spacerLeft);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.pnl_Groups);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ctrl_TrackingItem";
            this.Size = new System.Drawing.Size(342, 52);
            this.Click += new System.EventHandler(this.ControlClickEvent);
            this.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pict_Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Proc;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_DisplayName;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.PictureBox pict_Icon;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Splitter spacerLeft;
        private System.Windows.Forms.Splitter spacerLeft2;
        private System.Windows.Forms.Panel pnl_Groups;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

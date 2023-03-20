namespace ProgramTracker
{
    partial class Frm_EditTimeEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.dtp_Stop = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.num_Days = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.num_Hours = new System.Windows.Forms.NumericUpDown();
            this.num_Minutes = new System.Windows.Forms.NumericUpDown();
            this.num_Seconds = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chbx_Lock = new System.Windows.Forms.CheckBox();
            this.tmr_Update = new System.Windows.Forms.Timer(this.components);
            this.btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_Start
            // 
            this.dtp_Start.CustomFormat = "MM/dd/yy - hh:mm:ss tt";
            this.dtp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Start.Location = new System.Drawing.Point(75, 8);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(207, 20);
            this.dtp_Start.TabIndex = 3;
            // 
            // dtp_Stop
            // 
            this.dtp_Stop.CustomFormat = "MM/dd/yy - hh:mm:ss tt";
            this.dtp_Stop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Stop.Location = new System.Drawing.Point(75, 31);
            this.dtp_Stop.Name = "dtp_Stop";
            this.dtp_Stop.Size = new System.Drawing.Size(207, 20);
            this.dtp_Stop.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stop Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_Days
            // 
            this.num_Days.Location = new System.Drawing.Point(75, 76);
            this.num_Days.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.num_Days.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_Days.Name = "num_Days";
            this.num_Days.Size = new System.Drawing.Size(50, 20);
            this.num_Days.TabIndex = 6;
            this.num_Days.ValueChanged += new System.EventHandler(this.numericUpDown_Changed);
            this.num_Days.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Duration";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_Hours
            // 
            this.num_Hours.Location = new System.Drawing.Point(127, 76);
            this.num_Hours.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.num_Hours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.num_Hours.Name = "num_Hours";
            this.num_Hours.Size = new System.Drawing.Size(50, 20);
            this.num_Hours.TabIndex = 8;
            this.num_Hours.ValueChanged += new System.EventHandler(this.numericUpDown_Changed);
            this.num_Hours.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // num_Minutes
            // 
            this.num_Minutes.Location = new System.Drawing.Point(180, 76);
            this.num_Minutes.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.num_Minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.num_Minutes.Name = "num_Minutes";
            this.num_Minutes.Size = new System.Drawing.Size(50, 20);
            this.num_Minutes.TabIndex = 9;
            this.num_Minutes.ValueChanged += new System.EventHandler(this.numericUpDown_Changed);
            this.num_Minutes.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // num_Seconds
            // 
            this.num_Seconds.Location = new System.Drawing.Point(232, 76);
            this.num_Seconds.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.num_Seconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.num_Seconds.Name = "num_Seconds";
            this.num_Seconds.Size = new System.Drawing.Size(50, 20);
            this.num_Seconds.TabIndex = 10;
            this.num_Seconds.ValueChanged += new System.EventHandler(this.numericUpDown_Changed);
            this.num_Seconds.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(74, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "days";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(125, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "hours";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(177, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "minutes";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(232, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "seconds";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbx_Lock
            // 
            this.chbx_Lock.AutoSize = true;
            this.chbx_Lock.Location = new System.Drawing.Point(7, 76);
            this.chbx_Lock.Name = "chbx_Lock";
            this.chbx_Lock.Size = new System.Drawing.Size(64, 30);
            this.chbx_Lock.TabIndex = 17;
            this.chbx_Lock.Text = "Lock\r\nduration";
            this.chbx_Lock.UseVisualStyleBackColor = true;
            // 
            // tmr_Update
            // 
            this.tmr_Update.Interval = 250;
            this.tmr_Update.Tick += new System.EventHandler(this.tmr_Update_Tick);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(204, 102);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 16;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Frm_EditTimeEntry
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 134);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.chbx_Lock);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.num_Seconds);
            this.Controls.Add(this.num_Minutes);
            this.Controls.Add(this.num_Hours);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_Days);
            this.Controls.Add(this.dtp_Stop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_Start);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_EditTimeEntry";
            this.Text = "Edit time entry";
            this.Deactivate += new System.EventHandler(this.Frm_EditTimeEntry_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_EditTimeEntry_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.num_Days)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Seconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.DateTimePicker dtp_Stop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_Days;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Hours;
        private System.Windows.Forms.NumericUpDown num_Minutes;
        private System.Windows.Forms.NumericUpDown num_Seconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbx_Lock;
        private System.Windows.Forms.Timer tmr_Update;
        private System.Windows.Forms.Button btn_Save;
    }
}
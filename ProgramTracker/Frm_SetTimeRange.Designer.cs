namespace ProgramTracker
{
    partial class Frm_SetTimeRange
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
            this.dt_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dt_StartTime = new System.Windows.Forms.DateTimePicker();
            this.chbx_UseEndDate = new System.Windows.Forms.CheckBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dt_EndDate = new System.Windows.Forms.DateTimePicker();
            this.chbx_UseStartDate = new System.Windows.Forms.CheckBox();
            this.chbx_ShowFilteredOut = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // dt_StartDate
            // 
            this.dt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_StartDate.Location = new System.Drawing.Point(12, 76);
            this.dt_StartDate.Name = "dt_StartDate";
            this.dt_StartDate.Size = new System.Drawing.Size(160, 22);
            this.dt_StartDate.TabIndex = 2;
            // 
            // dt_StartTime
            // 
            this.dt_StartTime.CustomFormat = "h:mm tt";
            this.dt_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartTime.Location = new System.Drawing.Point(12, 131);
            this.dt_StartTime.Name = "dt_StartTime";
            this.dt_StartTime.ShowUpDown = true;
            this.dt_StartTime.Size = new System.Drawing.Size(160, 22);
            this.dt_StartTime.TabIndex = 3;
            // 
            // chbx_UseEndDate
            // 
            this.chbx_UseEndDate.AutoSize = true;
            this.chbx_UseEndDate.Location = new System.Drawing.Point(219, 21);
            this.chbx_UseEndDate.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.chbx_UseEndDate.Name = "chbx_UseEndDate";
            this.chbx_UseEndDate.Size = new System.Drawing.Size(110, 20);
            this.chbx_UseEndDate.TabIndex = 5;
            this.chbx_UseEndDate.Text = "Use end date";
            this.chbx_UseEndDate.UseVisualStyleBackColor = true;
            this.chbx_UseEndDate.CheckedChanged += new System.EventHandler(this.chbx_UseEndDate_CheckedChanged);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Location = new System.Drawing.Point(171, 174);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 28);
            this.btn_Cancel.TabIndex = 20;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.Location = new System.Drawing.Point(279, 174);
            this.btn_Accept.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(100, 28);
            this.btn_Accept.TabIndex = 21;
            this.btn_Accept.Text = "Save";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Start Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "End Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "End Date";
            // 
            // dt_EndTime
            // 
            this.dt_EndTime.CustomFormat = "h:mm tt";
            this.dt_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndTime.Location = new System.Drawing.Point(219, 131);
            this.dt_EndTime.Name = "dt_EndTime";
            this.dt_EndTime.ShowUpDown = true;
            this.dt_EndTime.Size = new System.Drawing.Size(160, 22);
            this.dt_EndTime.TabIndex = 11;
            // 
            // dt_EndDate
            // 
            this.dt_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_EndDate.Location = new System.Drawing.Point(219, 76);
            this.dt_EndDate.Name = "dt_EndDate";
            this.dt_EndDate.Size = new System.Drawing.Size(160, 22);
            this.dt_EndDate.TabIndex = 10;
            // 
            // chbx_UseStartDate
            // 
            this.chbx_UseStartDate.AutoSize = true;
            this.chbx_UseStartDate.Location = new System.Drawing.Point(12, 21);
            this.chbx_UseStartDate.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.chbx_UseStartDate.Name = "chbx_UseStartDate";
            this.chbx_UseStartDate.Size = new System.Drawing.Size(112, 20);
            this.chbx_UseStartDate.TabIndex = 1;
            this.chbx_UseStartDate.Text = "Use start date";
            this.chbx_UseStartDate.UseVisualStyleBackColor = true;
            this.chbx_UseStartDate.CheckedChanged += new System.EventHandler(this.chbx_UseStartDate_CheckedChanged);
            // 
            // chbx_ShowFilteredOut
            // 
            this.chbx_ShowFilteredOut.AutoSize = true;
            this.chbx_ShowFilteredOut.Location = new System.Drawing.Point(12, 179);
            this.chbx_ShowFilteredOut.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.chbx_ShowFilteredOut.Name = "chbx_ShowFilteredOut";
            this.chbx_ShowFilteredOut.Size = new System.Drawing.Size(126, 20);
            this.chbx_ShowFilteredOut.TabIndex = 19;
            this.chbx_ShowFilteredOut.Text = "Show filtered out";
            this.chbx_ShowFilteredOut.UseVisualStyleBackColor = true;
            // 
            // Frm_SetTimeRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 217);
            this.Controls.Add(this.chbx_ShowFilteredOut);
            this.Controls.Add(this.chbx_UseStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dt_EndTime);
            this.Controls.Add(this.dt_EndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_StartTime);
            this.Controls.Add(this.dt_StartDate);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.chbx_UseEndDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_SetTimeRange";
            this.Text = "Time Range Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_StartDate;
        private System.Windows.Forms.DateTimePicker dt_StartTime;
        private System.Windows.Forms.CheckBox chbx_UseEndDate;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dt_EndTime;
        private System.Windows.Forms.DateTimePicker dt_EndDate;
        private System.Windows.Forms.CheckBox chbx_UseStartDate;
        private System.Windows.Forms.CheckBox chbx_ShowFilteredOut;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
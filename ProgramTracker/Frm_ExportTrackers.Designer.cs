namespace ProgramTracker
{
    partial class Frm_ExportTrackers
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
            this.pnl_Trackers = new System.Windows.Forms.Panel();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.btn_ToggleDateFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnl_Bottom.SuspendLayout();
            this.pnl_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Trackers
            // 
            this.pnl_Trackers.AutoScroll = true;
            this.pnl_Trackers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Trackers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Trackers.Location = new System.Drawing.Point(0, 71);
            this.pnl_Trackers.Name = "pnl_Trackers";
            this.pnl_Trackers.Size = new System.Drawing.Size(671, 291);
            this.pnl_Trackers.TabIndex = 1;
            // 
            // dtp_Start
            // 
            this.dtp_Start.CustomFormat = "M/d/yyyy  hh:ss tt";
            this.dtp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Start.Location = new System.Drawing.Point(251, 12);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(175, 22);
            this.dtp_Start.TabIndex = 1;
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "M/d/yyyy  hh:ss tt";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(251, 40);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(175, 22);
            this.dtp_End.TabIndex = 2;
            // 
            // btn_ToggleDateFilter
            // 
            this.btn_ToggleDateFilter.Location = new System.Drawing.Point(12, 12);
            this.btn_ToggleDateFilter.Name = "btn_ToggleDateFilter";
            this.btn_ToggleDateFilter.Size = new System.Drawing.Size(162, 53);
            this.btn_ToggleDateFilter.TabIndex = 0;
            this.btn_ToggleDateFilter.Text = "Use Individual\r\nDate Filter";
            this.btn_ToggleDateFilter.UseVisualStyleBackColor = true;
            this.btn_ToggleDateFilter.Click += new System.EventHandler(this.btn_ToggleDateFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Date";
            // 
            // btn_Export
            // 
            this.btn_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Export.Location = new System.Drawing.Point(576, 6);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(86, 30);
            this.btn_Export.TabIndex = 4;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.Controls.Add(this.btn_Export);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 362);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(671, 44);
            this.pnl_Bottom.TabIndex = 8;
            // 
            // pnl_Top
            // 
            this.pnl_Top.Controls.Add(this.label2);
            this.pnl_Top.Controls.Add(this.btn_ToggleDateFilter);
            this.pnl_Top.Controls.Add(this.label1);
            this.pnl_Top.Controls.Add(this.dtp_Start);
            this.pnl_Top.Controls.Add(this.dtp_End);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(671, 71);
            this.pnl_Top.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.FileName = "trackingdata.json";
            this.saveFileDialog1.Filter = "json|*.json";
            this.saveFileDialog1.Title = "Export Tracking Data";
            // 
            // Frm_ExportTrackers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 406);
            this.Controls.Add(this.pnl_Trackers);
            this.Controls.Add(this.pnl_Top);
            this.Controls.Add(this.pnl_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_ExportTrackers";
            this.Text = "Export Tracking Data";
            this.pnl_Bottom.ResumeLayout(false);
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_Trackers;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.Button btn_ToggleDateFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
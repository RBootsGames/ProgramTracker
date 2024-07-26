namespace ProgramTracker
{
    partial class Ctrl_ExportControl
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
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.cbx_Exclude = new System.Windows.Forms.CheckBox();
            this.lbl_ProcessName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_Start
            // 
            this.dtp_Start.CustomFormat = "M/d/yyyy  hh:ss tt";
            this.dtp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Start.Location = new System.Drawing.Point(44, 0);
            this.dtp_Start.Margin = new System.Windows.Forms.Padding(0);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(200, 22);
            this.dtp_Start.TabIndex = 0;
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "M/d/yyyy  hh:ss tt";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(44, 22);
            this.dtp_End.Margin = new System.Windows.Forms.Padding(0);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(200, 22);
            this.dtp_End.TabIndex = 1;
            // 
            // cbx_Exclude
            // 
            this.cbx_Exclude.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbx_Exclude.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbx_Exclude.Location = new System.Drawing.Point(443, 0);
            this.cbx_Exclude.Name = "cbx_Exclude";
            this.cbx_Exclude.Size = new System.Drawing.Size(90, 44);
            this.cbx_Exclude.TabIndex = 2;
            this.cbx_Exclude.Text = "Exclude";
            this.cbx_Exclude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbx_Exclude.UseVisualStyleBackColor = true;
            // 
            // lbl_ProcessName
            // 
            this.lbl_ProcessName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_ProcessName.Location = new System.Drawing.Point(0, 0);
            this.lbl_ProcessName.Name = "lbl_ProcessName";
            this.lbl_ProcessName.Size = new System.Drawing.Size(187, 44);
            this.lbl_ProcessName.TabIndex = 3;
            this.lbl_ProcessName.Text = "Process Name";
            this.lbl_ProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp_Start);
            this.panel1.Controls.Add(this.dtp_End);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(202, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 44);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "End";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 44);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(533, 1);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // Ctrl_ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbx_Exclude);
            this.Controls.Add(this.lbl_ProcessName);
            this.Controls.Add(this.splitter1);
            this.Name = "Ctrl_ExportControl";
            this.Size = new System.Drawing.Size(533, 45);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.CheckBox cbx_Exclude;
        private System.Windows.Forms.Label lbl_ProcessName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
    }
}

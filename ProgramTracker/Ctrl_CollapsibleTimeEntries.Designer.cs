namespace ProgramTracker
{
    partial class Ctrl_CollapsibleTimeEntries
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Duration = new System.Windows.Forms.Label();
            this.lbl_StartDate = new System.Windows.Forms.Label();
            this.pnl_Contents = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Duration, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_StartDate, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.ControlClickEvent);
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // lbl_Duration
            // 
            this.lbl_Duration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Duration.Location = new System.Drawing.Point(211, 0);
            this.lbl_Duration.Name = "lbl_Duration";
            this.lbl_Duration.Size = new System.Drawing.Size(203, 28);
            this.lbl_Duration.TabIndex = 1;
            this.lbl_Duration.Text = "Duration";
            this.lbl_Duration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Duration.Click += new System.EventHandler(this.ControlClickEvent);
            this.lbl_Duration.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.lbl_Duration.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_StartDate.Location = new System.Drawing.Point(3, 0);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(202, 28);
            this.lbl_StartDate.TabIndex = 0;
            this.lbl_StartDate.Text = "Start Date";
            this.lbl_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_StartDate.Click += new System.EventHandler(this.ControlClickEvent);
            this.lbl_StartDate.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.lbl_StartDate.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // pnl_Contents
            // 
            this.pnl_Contents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Contents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Contents.Location = new System.Drawing.Point(0, 28);
            this.pnl_Contents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_Contents.Name = "pnl_Contents";
            this.pnl_Contents.Size = new System.Drawing.Size(417, 122);
            this.pnl_Contents.TabIndex = 1;
            // 
            // Ctrl_CollapsibleTimeEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_Contents);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Ctrl_CollapsibleTimeEntries";
            this.Size = new System.Drawing.Size(417, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_StartDate;
        private System.Windows.Forms.Panel pnl_Contents;
        private System.Windows.Forms.Label lbl_Duration;
    }
}

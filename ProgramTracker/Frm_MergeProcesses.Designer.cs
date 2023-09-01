namespace ProgramTracker
{
    partial class Frm_MergeProcesses
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
            this.list_Mergers = new System.Windows.Forms.CheckedListBox();
            this.list_Master = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.btn_OneTime = new System.Windows.Forms.Button();
            this.btn_Permanent = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnl_Left = new System.Windows.Forms.Panel();
            this.pnl_Right = new System.Windows.Forms.Panel();
            this.pnl_Bottom.SuspendLayout();
            this.pnl_Left.SuspendLayout();
            this.pnl_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_Mergers
            // 
            this.list_Mergers.CheckOnClick = true;
            this.list_Mergers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Mergers.FormattingEnabled = true;
            this.list_Mergers.Location = new System.Drawing.Point(0, 13);
            this.list_Mergers.Name = "list_Mergers";
            this.list_Mergers.Size = new System.Drawing.Size(273, 294);
            this.list_Mergers.TabIndex = 0;
            this.list_Mergers.SelectedIndexChanged += new System.EventHandler(this.list_Master_SelectedIndexChanged);
            // 
            // list_Master
            // 
            this.list_Master.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Master.FormattingEnabled = true;
            this.list_Master.Location = new System.Drawing.Point(0, 13);
            this.list_Master.Name = "list_Master";
            this.list_Master.Size = new System.Drawing.Size(262, 294);
            this.list_Master.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Master Process";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Merge Processes";
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.Controls.Add(this.btn_OneTime);
            this.pnl_Bottom.Controls.Add(this.btn_Permanent);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 307);
            this.pnl_Bottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(539, 35);
            this.pnl_Bottom.TabIndex = 4;
            // 
            // btn_OneTime
            // 
            this.btn_OneTime.Enabled = false;
            this.btn_OneTime.Location = new System.Drawing.Point(328, 4);
            this.btn_OneTime.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OneTime.Name = "btn_OneTime";
            this.btn_OneTime.Size = new System.Drawing.Size(98, 24);
            this.btn_OneTime.TabIndex = 0;
            this.btn_OneTime.Text = "One Time Merge";
            this.btn_OneTime.UseVisualStyleBackColor = true;
            this.btn_OneTime.Click += new System.EventHandler(this.btn_OneTime_Click);
            // 
            // btn_Permanent
            // 
            this.btn_Permanent.Enabled = false;
            this.btn_Permanent.Location = new System.Drawing.Point(432, 4);
            this.btn_Permanent.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Permanent.Name = "btn_Permanent";
            this.btn_Permanent.Size = new System.Drawing.Size(100, 24);
            this.btn_Permanent.TabIndex = 1;
            this.btn_Permanent.Text = "Permanent Merge";
            this.btn_Permanent.UseVisualStyleBackColor = true;
            this.btn_Permanent.Click += new System.EventHandler(this.btn_Permanent_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(262, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 307);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // pnl_Left
            // 
            this.pnl_Left.Controls.Add(this.list_Master);
            this.pnl_Left.Controls.Add(this.label1);
            this.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Left.Location = new System.Drawing.Point(0, 0);
            this.pnl_Left.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Left.Name = "pnl_Left";
            this.pnl_Left.Size = new System.Drawing.Size(262, 307);
            this.pnl_Left.TabIndex = 6;
            // 
            // pnl_Right
            // 
            this.pnl_Right.Controls.Add(this.list_Mergers);
            this.pnl_Right.Controls.Add(this.label2);
            this.pnl_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Right.Location = new System.Drawing.Point(266, 0);
            this.pnl_Right.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Right.Name = "pnl_Right";
            this.pnl_Right.Size = new System.Drawing.Size(273, 307);
            this.pnl_Right.TabIndex = 7;
            // 
            // Frm_MergeProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 342);
            this.Controls.Add(this.pnl_Right);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnl_Left);
            this.Controls.Add(this.pnl_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_MergeProcesses";
            this.Text = "Merge Processes";
            this.ResizeBegin += new System.EventHandler(this.Frm_MergeProcesses_ResizeBegin);
            this.ClientSizeChanged += new System.EventHandler(this.Frm_MergeProcesses_ClientSizeChanged);
            this.pnl_Bottom.ResumeLayout(false);
            this.pnl_Left.ResumeLayout(false);
            this.pnl_Right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox list_Mergers;
        private System.Windows.Forms.ListBox list_Master;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnl_Left;
        private System.Windows.Forms.Panel pnl_Right;
        private System.Windows.Forms.Button btn_OneTime;
        private System.Windows.Forms.Button btn_Permanent;
    }
}
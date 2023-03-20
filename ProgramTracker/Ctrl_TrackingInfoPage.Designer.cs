namespace ProgramTracker
{
    partial class Ctrl_TrackingInfoPage
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pict_Icon = new System.Windows.Forms.PictureBox();
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Duration = new System.Windows.Forms.Label();
            this.pnl_AdderPanel = new System.Windows.Forms.Panel();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.btn_AddEntry = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Icon)).BeginInit();
            this.pnl_Top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnl_AdderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.Location = new System.Drawing.Point(332, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(20, 260);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "<\r\n<\r\n<";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(332, 22);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "label1";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pict_Icon
            // 
            this.pict_Icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pict_Icon.Image = global::ProgramTracker.Properties.Resources.circle_plus;
            this.pict_Icon.Location = new System.Drawing.Point(147, 1);
            this.pict_Icon.Margin = new System.Windows.Forms.Padding(1);
            this.pict_Icon.Name = "pict_Icon";
            this.pict_Icon.Size = new System.Drawing.Size(38, 26);
            this.pict_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict_Icon.TabIndex = 3;
            this.pict_Icon.TabStop = false;
            // 
            // pnl_Top
            // 
            this.pnl_Top.Controls.Add(this.tableLayoutPanel1);
            this.pnl_Top.Controls.Add(this.lbl_Title);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(332, 50);
            this.pnl_Top.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99825F));
            this.tableLayoutPanel1.Controls.Add(this.pict_Icon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Duration, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnl_AdderPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_Duration
            // 
            this.lbl_Duration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Duration.Location = new System.Drawing.Point(189, 0);
            this.lbl_Duration.Name = "lbl_Duration";
            this.lbl_Duration.Size = new System.Drawing.Size(140, 28);
            this.lbl_Duration.TabIndex = 4;
            this.lbl_Duration.Text = "Duration";
            this.lbl_Duration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_AdderPanel
            // 
            this.pnl_AdderPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_AdderPanel.Controls.Add(this.label1);
            this.pnl_AdderPanel.Controls.Add(this.btn_AddEntry);
            this.pnl_AdderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_AdderPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_AdderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_AdderPanel.Name = "pnl_AdderPanel";
            this.pnl_AdderPanel.Size = new System.Drawing.Size(146, 28);
            this.pnl_AdderPanel.TabIndex = 5;
            // 
            // pnl_Main
            // 
            this.pnl_Main.AutoScroll = true;
            this.pnl_Main.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Main.Location = new System.Drawing.Point(0, 50);
            this.pnl_Main.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(332, 210);
            this.pnl_Main.TabIndex = 5;
            // 
            // btn_AddEntry
            // 
            this.btn_AddEntry.BackgroundImage = global::ProgramTracker.Properties.Resources.circle_plus;
            this.btn_AddEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AddEntry.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_AddEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddEntry.Location = new System.Drawing.Point(0, 0);
            this.btn_AddEntry.Name = "btn_AddEntry";
            this.btn_AddEntry.Size = new System.Drawing.Size(28, 28);
            this.btn_AddEntry.TabIndex = 5;
            this.btn_AddEntry.UseVisualStyleBackColor = true;
            this.btn_AddEntry.Click += new System.EventHandler(this.btn_AddEntry_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(28, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add Entry";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ctrl_TrackingInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.pnl_Top);
            this.Controls.Add(this.btn_Close);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ctrl_TrackingInfoPage";
            this.Size = new System.Drawing.Size(352, 260);
            ((System.ComponentModel.ISupportInitialize)(this.pict_Icon)).EndInit();
            this.pnl_Top.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnl_AdderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pict_Icon;
        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Duration;
        internal System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Panel pnl_AdderPanel;
        private System.Windows.Forms.Button btn_AddEntry;
        private System.Windows.Forms.Label label1;
    }
}

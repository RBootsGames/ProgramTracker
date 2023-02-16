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
            this.pnl_Main = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Icon)).BeginInit();
            this.pnl_Top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.Location = new System.Drawing.Point(443, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(27, 320);
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
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(443, 27);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "label1";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pict_Icon
            // 
            this.pict_Icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pict_Icon.Image = global::ProgramTracker.Properties.Resources.circle_plus;
            this.pict_Icon.Location = new System.Drawing.Point(199, 4);
            this.pict_Icon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pict_Icon.Name = "pict_Icon";
            this.pict_Icon.Size = new System.Drawing.Size(45, 27);
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
            this.pnl_Top.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(443, 62);
            this.pnl_Top.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99825F));
            this.tableLayoutPanel1.Controls.Add(this.pict_Icon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Duration, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(443, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_Duration
            // 
            this.lbl_Duration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Duration.Location = new System.Drawing.Point(252, 0);
            this.lbl_Duration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Duration.Name = "lbl_Duration";
            this.lbl_Duration.Size = new System.Drawing.Size(187, 35);
            this.lbl_Duration.TabIndex = 4;
            this.lbl_Duration.Text = "Duration";
            this.lbl_Duration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_Main
            // 
            this.pnl_Main.AutoScroll = true;
            this.pnl_Main.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Main.Location = new System.Drawing.Point(0, 62);
            this.pnl_Main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(443, 258);
            this.pnl_Main.TabIndex = 5;
            // 
            // Ctrl_TrackingInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.pnl_Top);
            this.Controls.Add(this.btn_Close);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Ctrl_TrackingInfoPage";
            this.Size = new System.Drawing.Size(470, 320);
            ((System.ComponentModel.ISupportInitialize)(this.pict_Icon)).EndInit();
            this.pnl_Top.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pict_Icon;
        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Duration;
    }
}

﻿namespace ProgramTracker
{
    partial class Ctrl_TimeEntry
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
            this.lbl_Start = new System.Windows.Forms.Label();
            this.lbl_Duration = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Start
            // 
            this.lbl_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Start.Location = new System.Drawing.Point(4, 0);
            this.lbl_Start.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Start.Name = "lbl_Start";
            this.lbl_Start.Size = new System.Drawing.Size(216, 24);
            this.lbl_Start.TabIndex = 5;
            this.lbl_Start.Text = "Start";
            this.lbl_Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Duration
            // 
            this.lbl_Duration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Duration.Location = new System.Drawing.Point(228, 0);
            this.lbl_Duration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Duration.Name = "lbl_Duration";
            this.lbl_Duration.Size = new System.Drawing.Size(217, 24);
            this.lbl_Duration.TabIndex = 3;
            this.lbl_Duration.Text = "Duration";
            this.lbl_Duration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Duration, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Start, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 24);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // Ctrl_TimeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ctrl_TimeEntry";
            this.Size = new System.Drawing.Size(449, 24);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_Start;
        private System.Windows.Forms.Label lbl_Duration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

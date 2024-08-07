﻿namespace ProgramTracker
{
    partial class Frm_Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Graph));
            this.clb_DataSelector = new System.Windows.Forms.CheckedListBox();
            this.pnl_Left = new System.Windows.Forms.Panel();
            this.pnl_LeftTop = new System.Windows.Forms.Panel();
            this.btn_Update = new System.Windows.Forms.Button();
            this.searchBar = new ProgramTracker.TextBoxModified();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.chbx_CountEntries = new System.Windows.Forms.CheckBox();
            this.graphTypeSelector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.granSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.date_End = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.date_Start = new System.Windows.Forms.DateTimePicker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lbl_DurationLabels = new System.Windows.Forms.Label();
            this.pnl_Left.SuspendLayout();
            this.pnl_LeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.pnl_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // clb_DataSelector
            // 
            this.clb_DataSelector.CheckOnClick = true;
            this.clb_DataSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_DataSelector.FormattingEnabled = true;
            this.clb_DataSelector.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.clb_DataSelector.Location = new System.Drawing.Point(0, 40);
            this.clb_DataSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clb_DataSelector.Name = "clb_DataSelector";
            this.clb_DataSelector.Size = new System.Drawing.Size(207, 351);
            this.clb_DataSelector.TabIndex = 5;
            this.clb_DataSelector.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_DataSelector_ItemCheck);
            // 
            // pnl_Left
            // 
            this.pnl_Left.Controls.Add(this.clb_DataSelector);
            this.pnl_Left.Controls.Add(this.pnl_LeftTop);
            this.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Left.Location = new System.Drawing.Point(0, 0);
            this.pnl_Left.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Left.Name = "pnl_Left";
            this.pnl_Left.Size = new System.Drawing.Size(207, 391);
            this.pnl_Left.TabIndex = 1;
            // 
            // pnl_LeftTop
            // 
            this.pnl_LeftTop.Controls.Add(this.btn_Update);
            this.pnl_LeftTop.Controls.Add(this.searchBar);
            this.pnl_LeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_LeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnl_LeftTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_LeftTop.Name = "pnl_LeftTop";
            this.pnl_LeftTop.Size = new System.Drawing.Size(207, 40);
            this.pnl_LeftTop.TabIndex = 2;
            // 
            // btn_Update
            // 
            this.btn_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Update.Location = new System.Drawing.Point(0, 20);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(207, 20);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "Update Graph";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.UpdateGraph_Event);
            // 
            // searchBar
            // 
            this.searchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.searchBar.Location = new System.Drawing.Point(0, 0);
            this.searchBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchBar.Name = "searchBar";
            this.searchBar.RealText = "";
            this.searchBar.Size = new System.Drawing.Size(207, 20);
            this.searchBar.TabIndex = 0;
            this.searchBar.TextPlaceholder = null;
            this.searchBar.TextPlaceholderColor = System.Drawing.Color.Gray;
            this.searchBar.TextChangedFixed += new System.EventHandler(this.searchBar_TextChangedFixed);
            // 
            // dataChart
            // 
            chartArea1.AxisY.Title = "Hours";
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            this.dataChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.dataChart.Legends.Add(legend1);
            this.dataChart.Location = new System.Drawing.Point(209, 68);
            this.dataChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataChart.Name = "dataChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.dataChart.Series.Add(series1);
            this.dataChart.Series.Add(series2);
            this.dataChart.Size = new System.Drawing.Size(537, 323);
            this.dataChart.TabIndex = 2;
            this.dataChart.Text = "chart1";
            // 
            // pnl_Top
            // 
            this.pnl_Top.Controls.Add(this.chbx_CountEntries);
            this.pnl_Top.Controls.Add(this.graphTypeSelector);
            this.pnl_Top.Controls.Add(this.label4);
            this.pnl_Top.Controls.Add(this.label3);
            this.pnl_Top.Controls.Add(this.granSelector);
            this.pnl_Top.Controls.Add(this.label2);
            this.pnl_Top.Controls.Add(this.date_End);
            this.pnl_Top.Controls.Add(this.label1);
            this.pnl_Top.Controls.Add(this.date_Start);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(209, 0);
            this.pnl_Top.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(537, 40);
            this.pnl_Top.TabIndex = 3;
            // 
            // chbx_CountEntries
            // 
            this.chbx_CountEntries.AutoSize = true;
            this.chbx_CountEntries.Location = new System.Drawing.Point(408, 20);
            this.chbx_CountEntries.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbx_CountEntries.Name = "chbx_CountEntries";
            this.chbx_CountEntries.Size = new System.Drawing.Size(115, 17);
            this.chbx_CountEntries.TabIndex = 8;
            this.chbx_CountEntries.Text = "Count Time Entries";
            this.chbx_CountEntries.UseVisualStyleBackColor = true;
            this.chbx_CountEntries.CheckedChanged += new System.EventHandler(this.UpdateGraph_Event);
            // 
            // graphTypeSelector
            // 
            this.graphTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphTypeSelector.FormattingEnabled = true;
            this.graphTypeSelector.Items.AddRange(new object[] {
            "Column",
            "Doughnut",
            "Pie",
            "Pyramid",
            "Funnel",
            "Line",
            "Area",
            "Spline",
            "SplineArea",
            "Bar",
            "Point",
            "Bubble",
            "StepLine"});
            this.graphTypeSelector.Location = new System.Drawing.Point(298, 18);
            this.graphTypeSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.graphTypeSelector.Name = "graphTypeSelector";
            this.graphTypeSelector.Size = new System.Drawing.Size(106, 21);
            this.graphTypeSelector.TabIndex = 7;
            this.graphTypeSelector.SelectedIndexChanged += new System.EventHandler(this.graphTypeSelector_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Graph Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Granularity:";
            // 
            // granSelector
            // 
            this.granSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.granSelector.FormattingEnabled = true;
            this.granSelector.Items.AddRange(new object[] {
            "Month",
            "Week",
            "Day"});
            this.granSelector.Location = new System.Drawing.Point(208, 18);
            this.granSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.granSelector.Name = "granSelector";
            this.granSelector.Size = new System.Drawing.Size(86, 21);
            this.granSelector.TabIndex = 4;
            this.granSelector.SelectedIndexChanged += new System.EventHandler(this.granSelector_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date_End
            // 
            this.date_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_End.Location = new System.Drawing.Point(112, 20);
            this.date_End.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.date_End.Name = "date_End";
            this.date_End.Size = new System.Drawing.Size(89, 20);
            this.date_End.TabIndex = 2;
            this.date_End.ValueChanged += new System.EventHandler(this.UpdateGraph_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date Range:";
            // 
            // date_Start
            // 
            this.date_Start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_Start.Location = new System.Drawing.Point(2, 20);
            this.date_Start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.date_Start.Name = "date_Start";
            this.date_Start.Size = new System.Drawing.Size(89, 20);
            this.date_Start.TabIndex = 0;
            this.date_Start.ValueChanged += new System.EventHandler(this.UpdateGraph_Event);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(207, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 391);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // lbl_DurationLabels
            // 
            this.lbl_DurationLabels.BackColor = System.Drawing.Color.White;
            this.lbl_DurationLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_DurationLabels.Location = new System.Drawing.Point(209, 40);
            this.lbl_DurationLabels.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DurationLabels.Name = "lbl_DurationLabels";
            this.lbl_DurationLabels.Size = new System.Drawing.Size(537, 28);
            this.lbl_DurationLabels.TabIndex = 5;
            this.lbl_DurationLabels.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Frm_Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 391);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.lbl_DurationLabels);
            this.Controls.Add(this.pnl_Top);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnl_Left);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Frm_Graph";
            this.Text = "Program Tracker Graph";
            this.pnl_Left.ResumeLayout(false);
            this.pnl_LeftTop.ResumeLayout(false);
            this.pnl_LeftTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_DataSelector;
        private System.Windows.Forms.Panel pnl_Left;
        private TextBoxModified searchBar;
        private System.Windows.Forms.Panel pnl_LeftTop;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DateTimePicker date_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_End;
        private System.Windows.Forms.ComboBox granSelector;
        private System.Windows.Forms.ComboBox graphTypeSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_DurationLabels;
        private System.Windows.Forms.CheckBox chbx_CountEntries;
    }
}
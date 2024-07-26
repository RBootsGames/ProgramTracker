using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static ProgramTracker.Frm_Main;

namespace ProgramTracker
{
    public partial class Frm_Graph : Form
    {
        enum Granularity { Month, Week, Day, Hour }

        /// <summary>
        /// Hourly doesn't work with the chart correctly by default.
        /// </summary>
        Granularity graphGranularity = Granularity.Day;
        SeriesChartType graphType = SeriesChartType.Column;


        Dictionary<string, bool> itemSelections = new Dictionary<string, bool>();
        Dictionary<string, Tracker> itemTrackers = new Dictionary<string, Tracker>();

        public Frm_Graph(params string[] preSelected)
        {
            InitializeComponent();

            graphTypeSelector.SelectedIndex = 0;
            granSelector.SelectedIndex = 2;


            date_Start.Value = ((ProgSettings.UseFilterDateStart) ? ProgSettings.FilterDateStart : MasterTracker.GetOldestDate()).StartOfDay();
            date_End.Value = ((ProgSettings.UseFilterDateEnd) ? ProgSettings.FilterDateEnd: DateTime.Now).EndOfDay();

            clb_DataSelector.Items.Clear();
            //foreach (var proc in MasterTracker.ProcessTrackers.Keys)

            bool autoGenerate = preSelected.Length > 0;

            foreach (var proc in MasterTracker.ProcessTrackers.Values)
            {
                string text = GetDisplayName(proc);

                itemSelections[text] = false;
                itemTrackers[text] = proc;

                int index = clb_DataSelector.Items.Add(text);

                if (preSelected.Contains(proc.GetVisibleName()))
                {
                    Console.WriteLine(index);
                    clb_DataSelector.SetItemChecked(index, true);
                }
            }
        }

        private void searchBar_TextChangedFixed(object sender, EventArgs e)
        {
            List<string> match = itemSelections.Keys.Where(x => x.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            clb_DataSelector.Items.Clear();

            foreach (string item in match)
            {
                clb_DataSelector.Items.Add(item, itemSelections[item]);
            }
        }
        
        private void UpdateGraph_Event(object sender, EventArgs e)
        {
            GraphData();
        }

        private void granSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphGranularity = (Granularity)granSelector.SelectedIndex;
            GraphData();
        }


        private void clb_DataSelector_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool value = e.NewValue == CheckState.Checked;
            string item = clb_DataSelector.Items[e.Index].ToString();

            itemSelections[item] = value;

            GraphData();
        }

        private string GetDisplayName(Tracker tracker) // this was copied from Frm_MergeProcesses
        {
            string text = tracker.GetDisplayNameOverride().ToPrettyString();
            if (!string.IsNullOrEmpty(text))
                text += $" [ {tracker.ProcessName} ]";
            else
                text = tracker.ProcessName;

            return text;
        }


        List<string> GetSelectedItems()
        {
            //List<string> items = new List<string>();
            //foreach(string key in itemSelections.Keys)
            //{
            //    if (itemSelections[key] == true)
            //        items.Add(key);
            //}
            //return items;
            return itemSelections
                   .Where(pair => pair.Value) // get true values
                   .Select(pair => pair.Key) // select keys
                   .ToList();
        }

        //SeriesChartType GetChartType()
        //{
        //    return (SeriesChartType)Enum.Parse(typeof(SeriesChartType), graphTypeSelector.Text, true);
        //}

        void GraphData()
        {
            dataChart.Series.Clear();
            dataChart.ChartAreas[0].AxisY.Title =
                        (chbx_CountEntries.Checked) ? "Launch Count" : "Hours";

            lbl_DurationLabels.Text = string.Empty;
            List<string> selections = GetSelectedItems();

            // pie, doughnut, funnel and pyramid graph types
            if (graphType == SeriesChartType.Pie || graphType == SeriesChartType.Doughnut ||
                graphType == SeriesChartType.Funnel || graphType == SeriesChartType.Pyramid)
            {
                var graphData = CreateSeriesObject("Programs");
                //graphData.Label = "#VALX (#VAL hours)";
                foreach (string proc in selections)
                {
                    Tracker tracker = itemTrackers[proc];
                    string name = tracker.GetVisibleName();
                    TrackingPoint[] allPoints = tracker.GetDatesWithinRange(date_Start.Value, date_End.Value).ToArray(); // points within range

                    if (chbx_CountEntries.Checked)
                    {
                        int count = allPoints.Length;
                        graphData.Points.AddXY(name, count);
                        lbl_DurationLabels.Text += $"{name}: {count} Launches   ";
                    }
                    else
                    {
                        double duration = TrackingPoint.GetDuration(allPoints).TotalHours;

                        graphData.Points.AddXY(name, duration);
                        lbl_DurationLabels.Text += $"{name}: {duration.ToString("#.##")} hours   ";
                    }
                }

                dataChart.Series.Add(graphData);
                return;
            }

            // all other graph types
            foreach (string proc in selections)
            {
                Tracker tracker = itemTrackers[proc];
                Series graphData = CreateSeriesObject(tracker.GetVisibleName());
                List<TrackingPoint> allPoints = tracker.GetDatesWithinRange(date_Start.Value, date_End.Value); // points within range
                IEnumerable<IGrouping<DateTime, TrackingPoint>> groupedPoints = GetGroupedTrackingPoints(allPoints, graphGranularity);

                foreach (var day in groupedPoints)
                {
                    DateTime dateTime = day.ToList()[0].StartTime.Date;
                    switch (graphGranularity)
                    {
                        case Granularity.Month:
                            dateTime = new DateTime(dateTime.Year, dateTime.Month, 1);
                            break;
                        case Granularity.Week:
                            dateTime = StartOfWeek(dateTime);
                            break;
                        case Granularity.Hour:
                            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                          dateTime.Hour, 0, 0);
                            break;
                    }

                    if (chbx_CountEntries.Checked)
                    {
                        int count = day.Count();

                        graphData.Points.AddXY(dateTime, count);
                    }
                    else
                    {
                        TimeSpan duration = new TimeSpan();

                        foreach (TrackingPoint point in day)
                        {
                            duration += point.GetDuration();
                        }

                        graphData.Points.AddXY(dateTime, duration.TotalHours);
                    }
                }

                dataChart.Series.Add(graphData);
            }

            dataChart.ChartAreas[0].RecalculateAxesScale();
        }

        IEnumerable<IGrouping<DateTime, TrackingPoint>> GetGroupedTrackingPoints(List<TrackingPoint> points, Granularity granularity)
        {
            switch (granularity)
            {
                case Granularity.Month:
                    return points.GroupBy(x => new DateTime(x.StartTime.Year, x.StartTime.Month, 1));
                    
                case Granularity.Week:
                    return points.GroupBy(x => StartOfWeek(x.StartTime));
                    
                case Granularity.Day:
                    return points.GroupBy(x => x.StartTime.Date);
                    
                case Granularity.Hour:
                    return points.GroupBy(x => new DateTime(x.StartTime.Year, x.StartTime.Month, x.StartTime.Day,
                                          x.StartTime.Hour, 0, 0));
                    
                default:
                    return points.GroupBy(x => x.StartTime.Date);
            }
        }
        /// <summary>
        /// This is used to help grouping tracking points by week
        /// </summary>
        static DateTime StartOfWeek(DateTime dateTime)
        {
            DayOfWeek startDay = DayOfWeek.Sunday;
            int diff = dateTime.DayOfWeek - startDay;
            if (diff < 0)
            {
                diff += 7;
            }

            return dateTime.Date.AddDays(-diff).Date;
        }
        Series CreateSeriesObject(string seriesName)
        {
            Series s = new Series(seriesName);
            s.ChartType = graphType;
            s.Points.Clear();

            //s.ChartType = SeriesChartType.Line;
            //s.ChartType = SeriesChartType.Spline;
            s.XValueType = ChartValueType.DateTime;

            return s;
        }

        private void graphTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), graphTypeSelector.Text, true);
            GraphData();
            //if (GetChartType() == SeriesChartType.Pie || GetChartType() == SeriesChartType.Doughnut)
            //{
            //    return;
            //}

            //foreach (var item in dataChart.Series)
            //{
            //    lbl_DurationLabels.Text = string.Empty;
            //    item.ChartType = GetChartType();
            //    //if (Enum.TryParse(graphTypeSelector.Text, out SeriesChartType cType))
            //    //{
            //    //}
            //}

        }
    }
}

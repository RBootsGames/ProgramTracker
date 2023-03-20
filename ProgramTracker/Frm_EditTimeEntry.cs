using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public partial class Frm_EditTimeEntry : Form
    {
        TrackingPoint trackingPoint;
        TrackingPoint updatedPoint;
        Tracker TrackerParentOverride;

        bool isRunning => trackingPoint.IsRunning;
        bool mergeHappened = false;

        internal Frm_EditTimeEntry(TrackingPoint _trackingPoint, Tracker trackerParentOverride=null)
        {
            InitializeComponent();
            trackingPoint = _trackingPoint;
            updatedPoint = trackingPoint.Clone();
            TrackerParentOverride = trackerParentOverride;

            dtp_Start.Value = trackingPoint.StartTime;
            dtp_Stop.Value = (trackingPoint.IsRunning) ? DateTime.Now : (DateTime)trackingPoint.StopTime;

            TimeSpan duration = trackingPoint.GetDuration(true);
            SetTimeSpan(duration, true);


            Button btn_Cancel = new Button();
            btn_Cancel.Click += new EventHandler(delegate (object sender, EventArgs e)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            });

            trackingPoint.StoppedTracking += OnStoppedTracking;
            CancelButton = btn_Cancel;
            tmr_Update.Enabled = isRunning;
            UpdateIfRunning();


            // add event listeners here
            dtp_Start.ValueChanged += new EventHandler(this.dateTimePicker_Changed);
            dtp_Stop.ValueChanged += new EventHandler(this.dateTimePicker_Changed);
        }

        void UpdateIfRunning()
        {
            if (!isRunning)
                return;

            foreach (Control item in new Control[]
            {dtp_Stop, num_Days, num_Hours, num_Minutes, num_Seconds, chbx_Lock})
            {
                item.Enabled = false;
            }

            //dtp_Stop.Value = (DateTime)trackingPoint.StopTime;
            dtp_Stop.Value = DateTime.Now;
            SetTimeSpan(updatedPoint.GetDuration(true));
        }

        void SetTimeSpan(TimeSpan duration, bool isLoadingData = false)
        {
            NumericUpDown[] ctrls = new NumericUpDown[] { num_Days, num_Hours, num_Minutes, num_Seconds };
            if (isLoadingData)
                foreach (var item in ctrls)
                    item.ValueChanged -= numericUpDown_Changed;

            num_Days.Value = duration.Days;
            num_Hours.Value = duration.Hours;
            num_Minutes.Value = duration.Minutes;
            num_Seconds.Value = duration.Seconds;

            if (isLoadingData)
                foreach (var item in ctrls)
                    item.ValueChanged += numericUpDown_Changed;
        }
        void SetStopFromDuration()
        {
            TimeSpan duration = new TimeSpan(
                    (int)num_Days.Value, (int)num_Hours.Value, (int)num_Minutes.Value, (int)num_Seconds.Value);


            dtp_Stop.ValueChanged -= dateTimePicker_Changed;
            dtp_Stop.Value = dtp_Start.Value + duration;
            updatedPoint.StopTime = dtp_Stop.Value;
            dtp_Stop.ValueChanged += dateTimePicker_Changed;
        }

        public bool DidMergeHappen() => mergeHappened;


        internal TrackingPoint GetUpdatedTrackingData() => updatedPoint;

        /// <summary>
        /// Returns true if the data is valid.
        /// </summary>
        bool ValidateData()
        {
            // check if end date isn't newer than now
            if (updatedPoint.StopTime > DateTime.Now)
            {
                MessageBox.Show("Stop date cannot be newer than right now.", "Invalid stop date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // check if duration is less than 1 second
            if (updatedPoint.GetDuration() < new TimeSpan(10000000))// 1 second?
            {
                MessageBox.Show("Duration needs to be 1 second or greater.", "Invalid duration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // in case this is being used to add a new point instead of editing an existing one
            if (TrackerParentOverride == null)
            {   // check if point doesn't overlap existing points
                // potentially merge with overlapping points
                var overlaps = trackingPoint.ParentTracker.CheckForOverlap(trackingPoint, updatedPoint);
                if (overlaps.Count > 0)
                {
                    var answer = MessageBox.Show("This time entry overlaps with existing time entries. Do you want to merge them into one entry?\n\n" + 
                                String.Join("\n", overlaps.Select(x => x.StartTime)), "Overlapping data found", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.No)
                        return false;
                    else
                    {
                        overlaps.Add(trackingPoint);
                        overlaps.Add(updatedPoint);
                        trackingPoint.ParentTracker.Merge(overlaps.ToArray());
                        mergeHappened = true;
                    }
                }
            }
            else
            {
                // check if point doesn't overlap existing points
                // potentially merge with overlapping points
                var overlaps = TrackerParentOverride.CheckForOverlap(null, updatedPoint);
                if (overlaps.Count > 0)
                {
                    var answer = MessageBox.Show("This time entry overlaps with existing time entries. Do you want to merge them into one entry?\n\n" +
                                String.Join("\n", overlaps.Select(x => x.StartTime)), "Overlapping data found", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.No)
                        return false;
                    else
                    {
                        overlaps.Add(trackingPoint);
                        overlaps.Add(updatedPoint);
                        trackingPoint.ParentTracker.Merge(overlaps.ToArray());
                        mergeHappened = true;
                    }
                }
            }

            return true;
        }


        void OnStoppedTracking(object sender, EventArgs e)
        {
            foreach (Control item in new Control[]
            {dtp_Stop, num_Days, num_Hours, num_Minutes, num_Seconds, chbx_Lock})
            {
                item.UpdateOnThread(() => { item.Enabled = true; });
            }

        }

        private void Frm_EditTimeEntry_Deactivate(object sender, EventArgs e)
        {
            //Close();
        }

        private void dateTimePicker_Changed(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if (updatedPoint == null)
                return;


            if (chbx_Lock.Checked)
            {
                if (dtp == dtp_Start)
                    dtp_Stop.Value = dtp_Start.Value + updatedPoint.GetDuration();
                else if (dtp == dtp_Stop)
                    dtp_Start.Value = dtp_Stop.Value - updatedPoint.GetDuration();
            }
            else
            {
                if (dtp_Start.Value > updatedPoint.StopTime)
                    dtp_Start.Value = updatedPoint.StartTime;
                else if (dtp_Stop.Value < updatedPoint.StartTime)
                    dtp_Stop.Value = (DateTime)updatedPoint.StopTime;
            }

            updatedPoint.StartTime = dtp_Start.Value;
            updatedPoint.StopTime = dtp_Stop.Value;

            SetTimeSpan(updatedPoint.GetDuration());
        }

        private void numericUpDown_Changed(object sender, EventArgs e)
        {
            if (num_Days.Value + num_Hours.Value + num_Minutes.Value == 0)
                num_Seconds.Minimum = 1;
            else
                num_Seconds.Minimum = 0;
            SetStopFromDuration();
        }

        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            NumericUpDown ctrl = sender as NumericUpDown;

            ctrl.Select(0, ctrl.Value.ToString().Length);
        }

        private void tmr_Update_Tick(object sender, EventArgs e)
        {
            tmr_Update.Enabled = isRunning;
            UpdateIfRunning();
        }

        private void Frm_EditTimeEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            trackingPoint.StoppedTracking -= OnStoppedTracking;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false)
                return;

            this.ActiveControl = btn_Save;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

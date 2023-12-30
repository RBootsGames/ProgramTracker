using System;

namespace ProgramTracker
{
    public class TrackingPoint
    {
        DateTime l_StartTime;
        DateTime? l_StopTime;
        Ctrl_TimeEntry l_TimeEntryControl = null;

        public Tracker ParentTracker = null;
        public DateTime StartTime
        {
            get => l_StartTime;
            set
            {
                bool updated = false;
                if (!l_StartTime.Equals(value))
                    updated = true;

                l_StartTime = value;
                if (updated)
                    OnUpdateTracker(EventArgs.Empty);
            }
        }
        public DateTime? StopTime
        {
            get => l_StopTime;
            set
            {
                bool stopped = false;
                bool updated = false;
                if (l_StopTime == null && value != null)
                    stopped = true;

                if (!l_StopTime.Equals(value))
                    updated = true;

                l_StopTime = value;

                if (stopped)
                    OnStoppedTracking(EventArgs.Empty);

                if (updated)
                    OnUpdateTracker(EventArgs.Empty);
            }
        }

        internal bool IsFilteredOut
        {
            get
            {
                // if not using a filter
                if (!Frm_Main.ProgSettings.UseFilterDateStart && !Frm_Main.ProgSettings.UseFilterDateEnd)
                    return false;

                // is running and end date not used
                if (!Frm_Main.ProgSettings.UseFilterDateEnd && IsRunning)
                    return false;
                // using end date and start is after
                if (Frm_Main.ProgSettings.UseFilterDateEnd && StartTime >= Frm_Main.ProgSettings.FilterDateEnd)
                    return true;
                // using start date and end is before
                if (Frm_Main.ProgSettings.UseFilterDateStart && StopTime <= Frm_Main.ProgSettings.FilterDateStart)
                    return true;

                return false;
                //return ((Frm_Main.ProgSettings.UseFilterDateEnd && StartTime >= Frm_Main.ProgSettings.FilterDateEnd) ||
                //        (Frm_Main.ProgSettings.UseFilterDateStart && StopTime <= Frm_Main.ProgSettings.FilterDateStart));
            }
        }

        internal bool IsRunning => StopTime == null;

        public event EventHandler StoppedTracking;

        public event EventHandler UpdatedTracker;


        public TrackingPoint() { }
        public TrackingPoint(DateTime? _startTime, DateTime? _stopTime = null, Tracker parent = null)
        {
            StartTime = (_startTime == null) ? DateTime.Now : (DateTime)_startTime;
            StopTime = _stopTime;
            ParentTracker = parent;
        }

        public void SetTimeEntryControl(Ctrl_TimeEntry ctrl) => l_TimeEntryControl = ctrl;
        public Ctrl_TimeEntry GetTimeEntryControl() => l_TimeEntryControl;

        public TrackingPoint Clone()
        {
            // This will also clone the events
            var clone = this.MemberwiseClone() as TrackingPoint;
            if (clone.ParentTracker != null)
            {
                clone.UpdatedTracker -= clone.ParentTracker.OnItemUpdated;
                clone.ParentTracker = null;
            }

            return clone;
        }

        internal TimeSpan GetDuration(bool calculateIfActive=false, bool useTimeFilter=false)
        {
            if (useTimeFilter)
            {
                DateTime? start = GetStartTimeFiltered();
                DateTime? end = GetEndTimeFiltered();

                // start or end should only be null if the time range is outside of the filter
                if (!start.HasValue || !end.HasValue)
                    return TimeSpan.Zero;


                return (!IsRunning) ? (DateTime)end - (DateTime)start :
                    (calculateIfActive) ? DateTime.Now - (DateTime)start : TimeSpan.Zero;
            }
            else
            {
                return (!IsRunning) ? (DateTime)StopTime - StartTime :
                    (calculateIfActive) ? DateTime.Now - StartTime : TimeSpan.Zero;
            }
        }


        /// <summary>
        /// This will adjust the start time in order to fit within the time filter parameters.
        /// </summary>
        /// <returns>Will return null if the time entry is filtered out.</returns>
        public DateTime? GetStartTimeFiltered()
        {
            if (IsFilteredOut)
                return null;
            else if (Frm_Main.ProgSettings.UseFilterDateStart == false)
                return StartTime;
            else if (StartTime < Frm_Main.ProgSettings.FilterDateStart)
                return Frm_Main.ProgSettings.FilterDateStart;
            else
                return StartTime;
        }

        /// <summary>
        /// This will adjust the end time in order to fit within the time filter parameters.
        /// </summary>
        /// <returns>Will return null if the time entry is filtered out.</returns>
        public DateTime? GetEndTimeFiltered()
        {
            if (IsRunning)
                return DateTime.Now;
            else if (IsFilteredOut)
                return null;
            else if (Frm_Main.ProgSettings.UseFilterDateEnd == false)
                return StopTime;
            else if (StopTime > Frm_Main.ProgSettings.FilterDateEnd)
                return Frm_Main.ProgSettings.FilterDateEnd;
            else
                return StopTime;
        }


        /// <summary>
        /// Adds the duration of all the tracking points in the parameters.
        /// </summary>
        public static TimeSpan GetDuration(params TrackingPoint[] entries)
        {
            TimeSpan duration = TimeSpan.Zero;

            foreach (TrackingPoint point in entries)
            {
                duration += point.GetDuration(useTimeFilter: true);
                //duration += (!point.IsRunning) ? (DateTime)point.StopTime - point.StartTime:
                //    DateTime.Now - point.StartTime;
            }

            return duration;
        }



        protected virtual void OnStoppedTracking(EventArgs e)
        {
            StoppedTracking?.Invoke(this, e);
        }
        protected virtual void OnUpdateTracker(EventArgs e)
        {
            UpdatedTracker?.Invoke(this, e);
        }
    }
}

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

        internal TimeSpan GetDuration(bool calculateIfActive=false)
        {
            return (!IsRunning) ? (DateTime)StopTime - StartTime :
                (calculateIfActive) ? DateTime.Now - StartTime : TimeSpan.Zero;
        }


        /// <summary>
        /// Adds the duration of all the tracking points in the parameters.
        /// </summary>
        public static TimeSpan GetDuration(params TrackingPoint[] entries)
        {
            TimeSpan duration = TimeSpan.Zero;

            foreach (TrackingPoint point in entries)
            {
                duration += (!point.IsRunning) ? (DateTime)point.StopTime - point.StartTime:
                    DateTime.Now - point.StartTime;
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

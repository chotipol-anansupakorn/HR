using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class WorkingPeriod
    {
        public WorkingPeriod()
        {
            WorkingShifts = new HashSet<WorkingShift>();
        }

        public int WorkingHrsId { get; set; }
        public TimeSpan WorkingStartTime { get; set; }
        public TimeSpan WorkingStopTime { get; set; }

        public virtual ICollection<WorkingShift> WorkingShifts { get; set; }
    }
}

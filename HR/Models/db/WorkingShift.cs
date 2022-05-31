using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class WorkingShift
    {
        public int ShiftId { get; set; }
        public int EmpId { get; set; }
        public int WorkingHrsId { get; set; }
        public DateTime ShiftStartDate { get; set; }
        public DateTime ShiftStopDate { get; set; }
        public DateTime RegistDateTime { get; set; }

        public virtual WorkingPeriod WorkingHrs { get; set; } = null!;
    }
}

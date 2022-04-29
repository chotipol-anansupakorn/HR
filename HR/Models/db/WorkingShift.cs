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
        public byte[] RegistDateTime1 { get; set; } = null!;
        public string RegistBy { get; set; } = null!;
    }
}

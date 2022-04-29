using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Leave
    {
        public int LeaveId { get; set; }
        public string LeaveType { get; set; } = null!;
        public int LeaveDays { get; set; }
    }
}

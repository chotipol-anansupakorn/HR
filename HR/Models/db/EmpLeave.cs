using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpLeave
    {
        public int EmpId { get; set; }
        public int LeaveId { get; set; }
        public DateTime LeaveStart { get; set; }
        public DateTime LeaveStop { get; set; }
        public byte[] RegistDateTime { get; set; } = null!;
        public string RegistBy { get; set; } = null!;
    }
}

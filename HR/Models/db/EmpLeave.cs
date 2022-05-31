using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpLeave
    {
        public int Id { get; set; }
        public string EmpId { get; set; } = null!;
        public int LeaveId { get; set; }
        public DateTime LeaveStart { get; set; }
        public DateTime LeaveStop { get; set; }
        public byte[] RegistDateTime { get; set; } = null!;
        public string ApproveBy { get; set; } = null!;

        public virtual Leave Leave { get; set; } = null!;
    }
}

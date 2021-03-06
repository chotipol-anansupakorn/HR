using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpTimestamp
    {
        public int Id { get; set; }
        public string EmpId { get; set; } = null!;
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public virtual Employee Emp { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpTimestamp
    {
        public int EmpId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}

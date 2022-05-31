using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpOt
    {
        public int Id { get; set; }
        public string EmpId { get; set; } = null!;
        public DateTime OtDate { get; set; }
        public TimeSpan OtHrs { get; set; }
        public int OtId { get; set; }
        public DateTime RegistDateTime { get; set; }
        public string ApproveBy { get; set; } = null!;

        public virtual Employee Emp { get; set; } = null!;
        public virtual Ot Ot { get; set; } = null!;
    }
}

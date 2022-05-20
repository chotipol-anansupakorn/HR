using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpSlibing
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? EmpSlibingName { get; set; }
        public string? EmpSlibingSurname { get; set; }
        public DateTime? EmpSlibingDob { get; set; }
        public string? EmpSlibingJob { get; set; }
        public string? EmpSlibingTel { get; set; }

        public virtual Employee? Emp { get; set; }
    }
}

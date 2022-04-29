using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpSlibing
    {
        public int EmpId { get; set; }
        public string EmpSlibingName { get; set; } = null!;
        public string EmpSlibingSurname { get; set; } = null!;
        public DateTime EmpSlibingDob { get; set; }
        public string EmpSlibingJob { get; set; } = null!;
        public string EmpSlibingTel { get; set; } = null!;
    }
}

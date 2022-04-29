using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpChild
    {
        public int EmpId { get; set; }
        public string EmpChildName { get; set; } = null!;
        public string EmpChildSurname { get; set; } = null!;
        public DateTime EmpChildDob { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpChild
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? EmpChildName { get; set; }
        public string? EmpChildSurname { get; set; }
        public DateTime? EmpChildDob { get; set; }

        public virtual Employee? Emp { get; set; }
    }
}

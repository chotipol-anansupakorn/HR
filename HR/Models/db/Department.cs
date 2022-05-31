using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
    }
}

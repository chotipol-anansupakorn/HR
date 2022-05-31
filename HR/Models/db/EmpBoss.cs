using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpBoss
    {
        public int Id { get; set; }
        public string EmpId { get; set; } = null!;
        public string BossId { get; set; } = null!;
    }
}

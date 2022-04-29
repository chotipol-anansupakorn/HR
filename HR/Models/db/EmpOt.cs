using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpOt
    {
        public int EmpId { get; set; }
        public DateTime OtDate { get; set; }
        public TimeSpan OtStart { get; set; }
        public TimeSpan OtStop { get; set; }
        public byte[] RegistDateTime { get; set; } = null!;
        public string RegistBy { get; set; } = null!;
    }
}

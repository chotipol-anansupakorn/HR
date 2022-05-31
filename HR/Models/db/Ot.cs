using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Ot
    {
        public Ot()
        {
            EmpOts = new HashSet<EmpOt>();
        }

        public int OtId { get; set; }
        public double OtMutiple { get; set; }

        public virtual ICollection<EmpOt> EmpOts { get; set; }
    }
}

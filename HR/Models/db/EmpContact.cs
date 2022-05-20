using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpContact
    {
        public int Id { get; set; }
        public string EmpId { get; set; } = null!;
        public string EmpDadName { get; set; } = null!;
        public string EmpDadSurname { get; set; } = null!;
        public DateTime EmpDadDob { get; set; }
        public string EmpDadJob { get; set; } = null!;
        public string EmpDadTel { get; set; } = null!;
        public string EmpMomName { get; set; } = null!;
        public string EmpMomSurname { get; set; } = null!;
        public DateTime EmpMomDob { get; set; }
        public string EmpMomJob { get; set; } = null!;
        public string EmpMomTel { get; set; } = null!;
        public string? EmpSpouseName { get; set; }
        public string? EmpSpouseSurname { get; set; }
        public DateTime? EmpSpouseDob { get; set; }
        public string? EmpSpouseJob { get; set; }
        public string? EmpSpouseTel { get; set; }
        public string EmergencyContactName { get; set; } = null!;
        public string EmergencyContactSurname { get; set; } = null!;
        public string EmergencyContactTel { get; set; } = null!;
        public string EmergencyContactRelation { get; set; } = null!;

        public virtual Employee Emp { get; set; } = null!;
    }
}

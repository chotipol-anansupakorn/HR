using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class EmpContact
    {
        public int EmpId { get; set; }
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
        public string EmpSpouseName { get; set; } = null!;
        public string EmpSpouseSurname { get; set; } = null!;
        public DateTime EmpSpouseDob { get; set; }
        public string EmpSpouseJob { get; set; } = null!;
        public string EmpSpouseTel { get; set; } = null!;
        public string EmergencyContactName { get; set; } = null!;
        public string EmergencyContactSurname { get; set; } = null!;
        public string EmergencyContactTel { get; set; } = null!;
        public string EmergencyContactRelation { get; set; } = null!;
    }
}

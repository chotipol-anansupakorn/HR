using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Employee
    {
        public Employee()
        {
            EmpChildren = new HashSet<EmpChild>();
            EmpContacts = new HashSet<EmpContact>();
            EmpOts = new HashSet<EmpOt>();
            EmpSlibings = new HashSet<EmpSlibing>();
            EmpTimestamps = new HashSet<EmpTimestamp>();
        }

        public int Id { get; set; }
        public string EmpId { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public string EmpSurname { get; set; } = null!;
        public string EmpIdno { get; set; } = null!;
        public DateTime? Bod { get; set; }
        public int EmpGenderId { get; set; }
        public int EmpMarrySatatusId { get; set; }
        public string EmpTel { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public string? EmpImage { get; set; }
        public string EmpIdcardAddress { get; set; } = null!;
        public string EmpCurrentAddress { get; set; } = null!;
        public int SubDistrict { get; set; }
        public int District { get; set; }
        public int Province { get; set; }
        public int Zipcode { get; set; }
        public DateTime EmpStart { get; set; }
        public DateTime? EmpEnd { get; set; }
        public int Probation { get; set; }
        public string EmpJobName { get; set; } = null!;
        public int EmpPositionId { get; set; }
        public int EmpDepartmentId { get; set; }
        public int WorkingHrsId { get; set; }
        public double BaseSalary { get; set; }
        public double SkillSalary { get; set; }
        public DateTime RegistDateTime { get; set; }
        public string? RegistBy { get; set; }
        public int? IsDelete { get; set; }

        public virtual ICollection<EmpChild> EmpChildren { get; set; }
        public virtual ICollection<EmpContact> EmpContacts { get; set; }
        public virtual ICollection<EmpOt> EmpOts { get; set; }
        public virtual ICollection<EmpSlibing> EmpSlibings { get; set; }
        public virtual ICollection<EmpTimestamp> EmpTimestamps { get; set; }
    }
}

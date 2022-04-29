using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmpId { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public string EmpSurname { get; set; } = null!;
        public string EmpIdno { get; set; } = null!;
        public int EmpGenderId { get; set; }
        public int EmpMarrySatatusId { get; set; }
        public string EmpTel { get; set; } = null!;
        public string? EmpEmail { get; set; }
        public string EmpImage { get; set; } = null!;
        public string EmpIdcardAddress { get; set; } = null!;
        public string EmpCurrentAddress { get; set; } = null!;
        public string SubDistrict { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string Zipcode { get; set; } = null!;
        public DateTime EmpStart { get; set; }
        public DateTime? EmpEnd { get; set; }
        public string EmpJobName { get; set; } = null!;
        public int EmpPositionId { get; set; }
        public int EmpDepartmentId { get; set; }
        public int WorkingHrsId { get; set; }
        public double BaseSalary { get; set; }
        public double SkillSalary { get; set; }
        public byte[] RegistDateTime { get; set; } = null!;
        public string RegistBy { get; set; } = null!;
        public int? IsDelete { get; set; }
    }
}

using HR.Models.db;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Models.Viewmodels
{
    public class RegistEmp
    {
        //--Employee---//  

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
        public IFormFile? ImageUpload { get; set; }
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

        //---End---//

        //---EmpContact---//   
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
        public Nullable<DateTime> EmpSpouseDob { get; set; } 
        public string? EmpSpouseJob { get; set; }
        public string? EmpSpouseTel { get; set; }
        public string EmergencyContactName { get; set; } = null!;
        public string EmergencyContactSurname { get; set; } = null!;
        public string EmergencyContactTel { get; set; } = null!;
        public string EmergencyContactRelation { get; set; } = null!;

        //--END---

        //---EmpSliblings---//  
        public string? EmpSlibingName { get; set; }
        public string? EmpSlibingSurname { get; set; }
        public Nullable<DateTime> EmpSlibingDob { get; set; }  
        public string? EmpSlibingJob { get; set; }
        public string? EmpSlibingTel { get; set; } 
        public List<EmpSlibing>? SlibingList { get; set; } 
        //---End---//

        //---EmpChild---// 
        public string? EmpChildName { get; set; }
        public string? EmpChildSurname { get; set; }
        public Nullable<DateTime> EmpChildDob { get; set; }
        public List<EmpChild>? ChildernList { get; set; }
        //---End---//

        //----Work hrs-----//
        public int WorkingId { get; set; }
        public string? WorkingTime{ get; set; }
 
    }
}

using HR.Models.db;
using System.ComponentModel;
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

        public int Id { get; set; }

        [DisplayName("รหัสพนักงาน")]
        public string EmpId { get; set; } = null!;

        [DisplayName("ชื่อ")]
        public string EmpName { get; set; } = null!;
        [DisplayName("นามสกุล")]
        public string EmpSurname { get; set; } = null!;
        [DisplayName("เลขปชช.")]
        public string EmpIdno { get; set; } = null!;
        [DisplayName("วันเกิด")] 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Bod { get; set; }
        public int EmpGenderId { get; set; }
        [DisplayName("เพศ")]
        public string? EmpGender { get; set; }
        public int EmpMarrySatatusId { get; set; }
        [DisplayName("สถานะ")]
        public string? EmpMarrySatatus { get; set; }
        [DisplayName("โทร")]
        public string EmpTel { get; set; } = null!;
        [DisplayName("อีเมล์")]
        public string EmpEmail { get; set; } = null!;

        [DisplayName("รูปภาพ")]
        public string? EmpImage { get; set; }
        public IFormFile? ImageUpload { get; set; }
        [DisplayName("ที่อยู่ตามบัตรประชาชน")]
        public string EmpIdcardAddress { get; set; } = null!;

        [DisplayName("ที่อยู่ตามบัตรปัจจุบัน")]
        public string EmpCurrentAddress { get; set; } = null!;
        public int SubDistrict { get; set; }

        [DisplayName("แขวง")]
        public string? SubDistrictName { get; set; }
        public int District { get; set; }
        [DisplayName("เขค")]
        public string? DistrictName { get; set; }

        public int Province { get; set; }
        [DisplayName("จังหวัด")]
        public string? ProvinceName { get; set; } 
        public int Zipcode { get; set; }
        [DisplayName("รหัาไปรษณีย์")]
        public string? ZipcodeName { get; set; }
        [DisplayName("วันเริ่มงาน")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EmpStart { get; set; }

        [DisplayName("วันสิ้นสุดการทำงาน")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? EmpEnd { get; set; }
        [DisplayName("สถานะทดลองงาน")]
        public int Probation { get; set; }
        [DisplayName("อาชีพ")]
        public string EmpJobName { get; set; } = null!;
        public int EmpPositionId { get; set; }
        [DisplayName("ตำแหน่ง")]
        public string? EmpPosition { get; set; }
        public int EmpDepartmentId { get; set; }
        [DisplayName("แผนก")]
        public string? EmpDepartment { get; set; }
        public int WorkingHrsId { get; set; }
        [DisplayName("เวลาทำงาน")]
        public string? WorkingHrs { get; set; }
        [DisplayName("ฐานเงินเดือน")]
        public double BaseSalary { get; set; }
        [DisplayName("ค่าทักษะ")]
        public double SkillSalary { get; set; }
        [DisplayName("วันเวลาลงทะเบัยน")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime RegistDateTime { get; set; }
        [DisplayName("ลงทะเบึยนโดย")]
        public string? RegistBy { get; set; }
        public int? IsDelete { get; set; }

        //---End---//

        //---EmpContact---//   
        public string EmpDadName { get; set; } = null!;
        public string EmpDadSurname { get; set; } = null!;
        [DisplayName("วันเกิด")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EmpDadDob { get; set; }
        public string EmpDadJob { get; set; } = null!;
        public string EmpDadTel { get; set; } = null!;
        public string EmpMomName { get; set; } = null!;
        public string EmpMomSurname { get; set; } = null!;
        [DisplayName("วันเกิด")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EmpMomDob { get; set; }
        public string EmpMomJob { get; set; } = null!;
        public string EmpMomTel { get; set; } = null!;
        public string? EmpSpouseName { get; set; }
        public string? EmpSpouseSurname { get; set; }
        [DisplayName("วันเกิด")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<DateTime> EmpSpouseDob { get; set; }
        public string? EmpSpouseJob { get; set; }
        public string? EmpSpouseTel { get; set; }
        public string EmergencyContactName { get; set; } = null!;
        public string EmergencyContactSurname { get; set; } = null!;
        public string EmergencyContactTel { get; set; } = null!;
        public string EmergencyContactRelation { get; set; } = null!;
        public List<EmpContact>? ContactList { get; set; }

        //--END---

        //---EmpSliblings---//  
        [DisplayName("ชื่อพี่-น้อง")]
        public string? EmpSlibingName { get; set; } 
        public string? EmpSlibingSurname { get; set; }
        [DisplayName("วันเกิด")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<DateTime> EmpSlibingDob { get; set; }  
        public string? EmpSlibingJob { get; set; }
        public string? EmpSlibingTel { get; set; }  
        public List<EmpSlibing>? SlibingList { get; set; } 
        //---End---//

        //---EmpChild---// 
        public string? EmpChildName { get; set; }
        public string? EmpChildSurname { get; set; }
        [DisplayName("วันเกิด")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<DateTime> EmpChildDob { get; set; }
        public List<EmpChild>? ChildernList { get; set; }
        //---End---//

        //----Work hrs-----//
        /* public int WorkingId { get; set; }
         public string? WorkingTime{ get; set; }*/

        //------- Boss---------------//
        [DisplayName("หัวหน้า")]
        public string? BossId { get; set; }
        public string? BossName { get; set; }
        public string? BossSurName { get; set; }
        public List<BossList>? BossBossList { get; set; }    
    }
}

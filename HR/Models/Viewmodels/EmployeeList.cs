using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR.Models.Viewmodels
{
    public class EmployeeList
    {
        public int Id { get; set; }
        [DisplayName("รหัส")]
        public string? EmpId { get; set; }

        [DisplayName("ชื่อ")]
        public string? EmpName { get; set; }

        [DisplayName("สกุล")]
        public string? EmpSurname { get; set; }

        [DisplayName("งาน")] 
        public string? EmpJobName { get; set; }

        [DisplayName("ตำแหน่ง")]
        public string? EmpPosition { get; set; }

        [DisplayName("แผนก")]
        public string? EmpDepartment { get; set; }

        [DisplayName("รูป")]
        public string? EmpImage { get; set; }
    }
}

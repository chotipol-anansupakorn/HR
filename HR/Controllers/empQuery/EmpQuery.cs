using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR.Models.db;
using System.Linq;
using System;
using System.Collections;
using HR.Models.Viewmodels;

namespace HR.Controllers.edit
{
    public class EmpQuery :  Controller
    {
        private readonly IkkmContext _context;
          
        public EmpQuery(IkkmContext context)
        {
            _context = context;
        }
        public RegistEmp? GetAllEmpInfo(string id)
        { 
            var bs = (from b in _context.EmpSlibings where b.EmpId == id select b).ToList();
            var con = (from a in _context.EmpContacts where a.EmpId == id select a).ToList();
            var child = (from a in _context.EmpChildren where a.EmpId == id select a).ToList();

            var boss = (from a in _context.EmpBosses
                        join b in _context.Employees
                        on a.BossId equals b.Id.ToString()
                        select new BossList
                        {
                            BossId = b.Id.ToString(),
                            BossName = b.EmpName,
                            BossSurname = b.EmpSurname,
                        }).ToList();


            var employee = (from emp in _context.Employees

                            join gender in _context.Genders on emp.EmpGenderId equals gender.GenderId

                            join marry in _context.MarryStatuses on emp.EmpMarrySatatusId equals marry.MarryStatusId

                            join sub in _context.Subdistricts on emp.SubDistrict equals sub.Id

                            join dis in _context.Districts on emp.District equals dis.Id

                            join pro in _context.Provinces on emp.Province equals pro.Id

                            join zip in _context.Zipcodes on emp.Zipcode equals zip.Id

                            join position in _context.Positions on emp.EmpPositionId equals position.PositionId

                            join dept in _context.Departments on emp.EmpDepartmentId equals dept.DepartmentId

                            join hrs in _context.WorkingPeriods on emp.WorkingHrsId equals hrs.WorkingHrsId

                            from a in _context.EmpBosses
                            join b in _context.Employees on a.BossId equals b.Id.ToString()

                            /*join con in _context.EmpContacts on emp.EmpId equals con.EmpId*/


                            select new RegistEmp
                            {
                                Id = emp.Id,
                                EmpId = emp.EmpId,
                                EmpName = emp.EmpName,
                                EmpSurname = emp.EmpSurname,
                                EmpIdno = emp.EmpIdno,
                                Bod = emp.Bod,
                                EmpGender = gender.GenderName,
                                EmpMarrySatatus = marry.MarryStatus1,
                                EmpTel = emp.EmpTel,
                                EmpEmail = emp.EmpEmail,
                                EmpImage = emp.EmpImage,
                                EmpIdcardAddress = emp.EmpIdcardAddress,
                                EmpCurrentAddress = emp.EmpCurrentAddress,
                                SubDistrictName = sub.SubdistrictName,
                                DistrictName = dis.DistrictName,
                                ProvinceName = pro.ProvinceName,
                                ZipcodeName = zip.ZipcodeName,
                                EmpStart = emp.EmpStart,
                                EmpEnd = emp.EmpEnd,
                                Probation = emp.Probation,
                                EmpJobName = emp.EmpJobName,
                                EmpPosition = position.PositionName,
                                EmpDepartment = dept.DepartmentName,
                                WorkingHrs = hrs.WorkingStartTime.ToString(@"hh\:mm") + " - " + hrs.WorkingStopTime.ToString(@"hh\:mm"),
                                BaseSalary = emp.BaseSalary,
                                SkillSalary = emp.SkillSalary,
                                RegistDateTime = emp.RegistDateTime,

                                SlibingList = bs,

                                ContactList = con,

                                ChildernList = child,

                                BossName = b.EmpName,
                                BossSurName = b.EmpSurname,
                            }).FirstOrDefault(x => x.EmpId.Equals(id));
            return  employee;
        } 
    }
}

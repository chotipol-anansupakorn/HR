//nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.EntityFrameworkCore;
using HR.Models.db;
using HR.Models.Viewmodels;

namespace HR.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IkkmContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeesController(IkkmContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Employees 
        public async Task<IActionResult> Index()
        {
            var empList = from emp in _context.Employees
                          join position in _context.Positions
                          on emp.EmpPositionId equals position.PositionId
                          join dept in _context.Departments
                          on emp.EmpDepartmentId equals dept.DepartmentId
                          select new EmployeeList
                          {
                              EmpId = emp.EmpId,
                              EmpName = emp.EmpName,
                              EmpSurname = emp.EmpSurname,
                              EmpJobName = emp.EmpJobName,
                              EmpPosition = position.PositionName,
                              EmpDepartment = dept.DepartmentName,
                              EmpImage = emp.EmpImage,
                          };
            if (empList != null)
            {
                return View(await empList.ToListAsync());
            }
            return NotFound();
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            //----Cretae auto id ------//
            var result = "";
            DateTime date = DateTime.Today;
            var year = date.Year;
            int month = date.Month;

            var id = (from a in _context.Employees
                      where (a.RegistDateTime.Year == year &&
                         a.RegistDateTime.Month == month)
                      select a).Count();
            if (id < 1)
            {
                result = date.ToString("yMM") + "001";
            }
            else
            {
                result = date.ToString("yMM") + (id + 1).ToString("000");
            }

            ViewData["id"] = result;
            //-----------------------------------//

            //-----generate province dropdown---------//
            var data = (from province in _context.Provinces
                        select province).ToList();
            ViewData["provinces"] = new SelectList(data, "Id", "ProvinceName");

            //-----------------------------------//

            //-------- create gender-----------//

            var gender = (from a in _context.Genders
                          select a).ToList();
            ViewData["sexs"] = new SelectList(gender, "GenderId", "GenderName");
            //---------------------------------//

            //-------- create marray status-----------//

            var marry = (from a in _context.MarryStatuses
                         select a).ToList();
            ViewData["marry"] = new SelectList(marry, "MarryStatusId", "MarryStatus1");
            //---------------------------------//

            //-------- create dept----------//

            var dept = (from a in _context.Departments
                        select a).ToList();
            ViewData["dept"] = new SelectList(dept, "DepartmentId", "DepartmentName");
            //---------------------------------//


            //-------- create position----------//

            var position = (from a in _context.Positions
                            select a).ToList();
            ViewData["position"] = new SelectList(position, "PositionId", "PositionName");
            //---------------------------------//


            //-------- create hrs----------//

            var hrs = (from a in _context.WorkingPeriods
                       select new RegistEmp
                       {
                           WorkingId = a.WorkingHrsId,
                           WorkingTime = a.WorkingStartTime.ToString("hh\\:mm") + " - " + a.WorkingStopTime.ToString("hh\\:mm"),
                       }).ToList();

            ViewData["hrs"] = new SelectList(hrs, "WorkingId", "WorkingTime");
            //---------------------------------//

            return View();
        }

        [HttpGet("api/district/{Id}")]
        public IEnumerable<Models.db.District> Districts(int Id)
        {
            return _context.Districts.ToList()
                .Where(m => m.ProvinceId == Id);
        }

        [HttpGet("api/subdistrict/{Id}")]
        public IEnumerable<Models.db.Subdistrict> Subdistricts(int Id)
        {
            return _context.Subdistricts.ToList()
                .Where(m => m.DistrictId == Id);
        }

        [HttpGet("api/zipcode/{Id}")]
        public IEnumerable<Models.db.Zipcode> Zipcodes(int Id)
        {
            return _context.Zipcodes
                .Where(m => m.SubdistrictId == Id);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistEmp registEmployee)
        {
            var pathSave = _hostEnvironment.WebRootPath.ToString();
            string filename = Path.GetFileNameWithoutExtension(registEmployee.ImageUpload.FileName);
            string extension = Path.GetExtension(registEmployee.ImageUpload.FileName);
            filename += extension;

            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    EmpId = registEmployee.EmpId,
                    EmpName = registEmployee.EmpName,
                    EmpSurname = registEmployee.EmpSurname,
                    EmpIdno = registEmployee.EmpIdno,
                    Bod = registEmployee.Bod,
                    EmpGenderId = registEmployee.EmpGenderId,
                    EmpMarrySatatusId = registEmployee.EmpMarrySatatusId,
                    EmpTel = registEmployee.EmpTel,
                    EmpEmail = registEmployee.EmpEmail,
                    EmpImage = filename,
                    EmpIdcardAddress = registEmployee.EmpIdcardAddress,
                    EmpCurrentAddress = registEmployee.EmpCurrentAddress,
                    SubDistrict = registEmployee.SubDistrict,
                    District = registEmployee.District,
                    Province = registEmployee.Province,
                    Zipcode = registEmployee.Zipcode,
                    EmpStart = registEmployee.EmpStart,
                    EmpEnd = registEmployee.EmpEnd,
                    EmpJobName = registEmployee.EmpJobName,
                    EmpPositionId = registEmployee.EmpPositionId,
                    EmpDepartmentId = registEmployee.EmpDepartmentId,
                    WorkingHrsId = registEmployee.WorkingHrsId,
                    BaseSalary = registEmployee.BaseSalary,
                    SkillSalary = registEmployee.SkillSalary,
                    RegistBy = registEmployee.RegistBy
                };
                _context.Employees.Add(employee); 


                string path = Path.Combine(pathSave + "/image", filename);

                if (!Directory.Exists(pathSave + "/image"))
                {
                    Directory.CreateDirectory(pathSave + "/image");
                }

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    registEmployee.ImageUpload.CopyToAsync(fileStream);
                }




                if (registEmployee.SlibingList.Count > 0)
                {
                    var list = new List<EmpSlibing>();
                    foreach (var item in registEmployee.SlibingList)
                    { 

                        var Sibling = new EmpSlibing()
                        {
                            EmpId = registEmployee.EmpId,
                            EmpSlibingName = item.EmpSlibingName,
                            EmpSlibingSurname = item.EmpSlibingSurname,
                            EmpSlibingDob = item.EmpSlibingDob,
                            EmpSlibingJob = item.EmpSlibingJob,
                            EmpSlibingTel = item.EmpSlibingTel,
                        };
                        list.Add(Sibling);

                    }
                    _context.EmpSlibings.AddRange(list);
                }

                if (registEmployee.ChildernList.Count > 0)
                {
                    var list = new List<EmpChild>();

                    foreach (var item in registEmployee.ChildernList)
                    {
                       
                        var Child = new EmpChild()
                        {
                            EmpId = registEmployee.EmpId,
                            EmpChildName = item.EmpChildName,
                            EmpChildSurname = item.EmpChildSurname,
                            EmpChildDob = item.EmpChildDob,
                        };
                        list.Add(Child);
                    }
                    _context.EmpChildren.AddRange(registEmployee.ChildernList);
                }

                var contact = new EmpContact()
                {
                    EmpId = registEmployee.EmpId,
                    EmpDadName = registEmployee.EmpDadName,
                    EmpDadSurname = registEmployee.EmpDadSurname,
                    EmpDadDob = registEmployee.EmpDadDob,
                    EmpDadJob = registEmployee.EmpDadJob,
                    EmpDadTel = registEmployee.EmpDadTel,
                    EmpMomName = registEmployee.EmpMomName,
                    EmpMomSurname = registEmployee.EmpMomSurname,
                    EmpMomDob = registEmployee.EmpMomDob,
                    EmpMomJob = registEmployee.EmpMomJob,
                    EmpMomTel = registEmployee.EmpMomTel,
                    EmpSpouseName = registEmployee.EmpSpouseName,
                    EmpSpouseSurname = registEmployee.EmpSpouseSurname,
                    EmpSpouseDob = registEmployee.EmpSpouseDob,
                    EmpSpouseJob = registEmployee.EmpSpouseJob,
                    EmpSpouseTel = registEmployee.EmpSpouseTel,
                    EmergencyContactName = registEmployee.EmergencyContactName,
                    EmergencyContactSurname = registEmployee.EmergencyContactSurname,
                    EmergencyContactTel = registEmployee.EmergencyContactTel,
                    EmergencyContactRelation = registEmployee.EmergencyContactRelation
                };
                _context.EmpContacts.Add(contact);
                _context.SaveChanges();

                TempData["message"] = "Create successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewData["message"] = "Create fail";
            return View(registEmployee);
        }


        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,EmpId,EmpName,EmpSurname,EmpIdno,EmpGenderId,EmpMarrySatatusId,EmpTel,EmpEmail,EmpImage,EmpIdcardAddress,EmpCurrentAddress,SubDistrict,District,Province,Zipcode,EmpStart,EmpEnd,EmpJobName,EmpPositionId,EmpDepartmentId,WorkingHrsId,BaseSalary,SkillSalary,RegistDateTime,RegistBy,IsDelete")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}

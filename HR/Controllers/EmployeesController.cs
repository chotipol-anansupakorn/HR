#nullable disable
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

        public EmployeesController(IkkmContext context)
        {
            _context = context;
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
                              EmpDepartment = dept.DepartmentName
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
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpId,EmpName,EmpSurname,EmpIdno,EmpGenderId,EmpMarrySatatusId,EmpTel,EmpEmail,EmpImage,EmpIdcardAddress,EmpCurrentAddress,SubDistrict,District,Province,Zipcode,EmpStart,EmpEnd,EmpJobName,EmpPositionId,EmpDepartmentId,WorkingHrsId,BaseSalary,SkillSalary,RegistDateTime,RegistBy,IsDelete")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
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

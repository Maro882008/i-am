using Microsoft.AspNetCore.Mvc;
using MVC.Models.Entities;
using MVC.Controllers;
using MVC.Models;
using Microsoft.EntityFrameworkCore;
using MVC.viewModel;
namespace MVC.Controllers
{
      public class EmployeeController : Controller
      {
        //    private static List<Employee> employees = new List<Employee>()
        //    {
        //        new Employee {Id = 1,name= "maro",Postion="manager",Salary=50000},
        //        new Employee {Id = 2,name= "Rahma",Postion="ceo",Salary=50000}
        //    };
        //    public IActionResult index()
        //    {

        //        return View(employees);
        //    }
        //    public IActionResult create()
        //    {

        //        return View();
        //    }
        //    [HttpPost]
        //    public IActionResult create(Employee employee)
        //    {
        //        if (employee != null)
        //        {
        //            employee.Id = employees.Count() + 1;
        //            employees.Add(employee);
        //            return RedirectToAction("Index");
        //        }
        //        return View();

        //    }
        public readonly AppDbContext db;
        public EmployeeController(AppDbContext app1)
        {
            this.db = app1;
        }
        public async Task<IActionResult> Index()
        {
            var emp = await db.Employees.Include(x => x.Department).ToListAsync();
            return View(emp);
        }
        [HttpGet]
        public async Task<IActionResult> add()
        {
            var dep = await db.Department.ToListAsync();
            EmployeeViewModel v1 = new EmployeeViewModel()
            {
                Departments = dep,
            };
            return View(v1);
        }

        [HttpPost]
        public async Task<IActionResult> add(EmployeeViewModel v1)
        {
            Employee employee =  new Employee()
            {
                 name = v1.Name,
                 Salary = v1.salary,
                 depid = v1.DepId,
            };
            await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var dep = await db.Department.ToListAsync();
            EmployeeViewModel v1 = new EmployeeViewModel()
            {
                Name = employee.name,
                salary = employee.Salary,
                DepId = employee.depid,
                Departments = dep
            };

            return View(v1);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel v1)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.name = v1.Name;
            employee.Salary = v1.salary;
            employee.depid = v1.DepId;

            db.Employees.Update(employee);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}


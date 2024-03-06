using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private CampanyContext context;
        public EmployeeController()
        {
            context=new CampanyContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(s => s.Id == id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Add()
        {
            EmployeeVM emp = new EmployeeVM()
            {
                departments = new SelectList(context.Departments, "Id", "Name")
            };

            return View(emp);
        }
        [HttpPost]
        public IActionResult Add(EmployeeVM employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    fname=employee.Fname,
                    lname=employee.Lname,
                    address=employee.Address,
                    salary=employee.Salary,
                    dno=employee.dept_id
                };
                context.Employees.Add(emp);
                context.SaveChanges();
            return RedirectToAction(nameof(Index));
            }
        List<Department> departments = context.Departments.ToList();
        employee.departments=new SelectList(departments,"Id","Name");
            return View(employee);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        CampanyContext context;
        public DepartmentController()
        {
            context = new CampanyContext();
        }
        public IActionResult Index()
        {
            List<Department> departments = context.Departments.ToList();
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            List<Employee> employees = context.Employees.ToList();
            List<Employee> managers = context.Departments.Select(e => e.managr).ToList();
            List<Employee> nomanager = employees.Except(managers).ToList();

            ViewData["nomanager"] = nomanager;
            Department department = context.Departments.SingleOrDefault(d => d.Id == id);
            return View(department);
        }

        //creat
        //display data
        public IActionResult Add()
        {
            List<Employee> employees = context.Employees.ToList();
            List<Employee>managers=context.Departments.Select(e=>e.managr).ToList();
            List<Employee>nomanager= employees.Except(managers).ToList();
            
            ViewData["nomanager"] = nomanager;
            return View();
        }

        //get form data
        public IActionResult AddDB(Department department)
        {
            if (department.Name != null)
            {

            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                List<Employee> managers = context.Departments.Select(e => e.managr).ToList();
                return View("Add");
            }
        }

        public IActionResult Edit(int id)
        {
            Department? department = context.Departments.SingleOrDefault(i => i.Id == id);
            List<Employee> employees = context.Employees.ToList();
            List<Employee> managers = context.Departments.Where(d=>d.Id != id).Select(e => e.managr).ToList();
            List<Employee> nomanager = employees.Except(managers).ToList();

            ViewData["nomanager"] = nomanager;
            return View(department);
        }

      
        public IActionResult EditDB(Department department)
        {
            
            if (department.Name != null)
            {
                context.Departments.Update(department);
                context.SaveChanges();

                return RedirectToAction("Index", "Department");
            }
            else
            {
                ViewBag.departments = context.Departments.ToList();
                return View("Edit");
            }

        }
        public IActionResult Delete(int id)
        {
            Department? department = context.Departments.SingleOrDefault(i => i.Id == id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Models;
using static WebApplication1.Models.Work_for;
namespace WebApplication1.Controllers
{
    public class ProjectController : Controller
    {
        CampanyContext context;
        public ProjectController()
        {
            context = new CampanyContext();
        }
        public IActionResult Index()
        {
            List<Project> projects = context.Projects.ToList();
            return View(projects);
        }

        public IActionResult Details(int id)
        {
            Project project = context.Projects.SingleOrDefault(i => i.Id == id);
            return View(project);
        }
        
        //creat
        //display data
        public IActionResult GetAddForm()
        {
            List<Department> departments=context.Departments.ToList();
            ViewData["departments"] = departments;
            return View();
        }

        //get form data
        public IActionResult GetFormData(string name, string city, string location, int dept_id)
        {
            Project project = new()
            {
                pname = name,
                plocation = location,
                city = city,
                dnum=dept_id
            };
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditFormData(int id)
        {
            Project? project = context.Projects.SingleOrDefault(i=>i.Id==id);
            List<Department> departments = context.Departments.ToList();
            ViewData["departments"] = departments;
            return View(project);
        }
        
        public IActionResult Update(int id,string name, string city, string location, int dept_id)
        {
            Project? project = context.Projects.SingleOrDefault(i => i.Id == id);
            project.pname = name;
            project.plocation = location;
            project.city = city;
            project.dnum = dept_id;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Project? project = context.Projects.SingleOrDefault(i => i.Id == id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //public IActionResult Get(int id)
        //{
        //    List<Project> project = context.Projects.Where(p=>p.Id == id).ToList();
        //    return View("_ProjHourPartial", project);
        //}

        //public IActionResult GetData(int id)
        //{
        //    List<Project> project = context.Projects.Where(p => p.Id == id).ToList();

        //    return Json(project);
        //}
    }
}

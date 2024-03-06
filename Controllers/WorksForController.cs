using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using static WebApplication1.Models.Work_for;

namespace WebApplication1.Controllers
{
    public class WorksForController : Controller
    {
        private CampanyContext context;
        public WorksForController()
        {
            context = new CampanyContext();
        }
        public IActionResult Index()
        {
            List<works_for> work_Fors= context.works_Fors.ToList();
            foreach (var item in work_Fors)
            {
                if (item.houres < 5)
                {
                    
                    ViewData[$"color_{item.essn}_{item.pnum}"] = "red";
                }
                else
                {
                    ViewData[$"color_{item.essn}_{item.pnum}"] = "green";
                }
            }

            return View(work_Fors);
        }
        public IActionResult Details(int id)
        {
            List<works_for> works = context.works_Fors.Where(i => i.essn == id).ToList();
            foreach (var item in works)
            {
                if (item.houres < 5)
                {

                    ViewData[$"color_{item.essn}_{item.pnum}"] = "red";
                }
                else
                {
                    ViewData[$"color_{item.essn}_{item.pnum}"] = "green";
                }
            }
            return View(works);
        }
        #region employee
        public IActionResult EmployeeProject(int id)
        {
            var works = context.works_Fors.Where(w => w.essn == id).GroupBy(w => new { w.essn }).Select(group => (dynamic)new
            {
                EmployeeName = group.Select(g => g.employee.fname).FirstOrDefault(),
                Projects = group.Select(g => g.project.pname).ToList(),
                totalHours = group.Sum(g => g.houres)
            }).ToList();

            foreach (var item in works)
            {
                if (item.totalHours < 5)
                {

                    ViewData[$"color_{item.EmployeeName}"] = "red";
                }
                else
                {
                    ViewData[$"color_{item.EmployeeName}"] = "green";
                }
            }
            return View(works);
        }
        
        
        public IActionResult AllEmployees()
        {
            var works = context.works_Fors.GroupBy(w => new { w.essn }).Select(group =>(dynamic) new
            {
                EmployeeName = group.Select(g=>g.employee.fname).FirstOrDefault(),
                Projects = group.Select(g => g.project.pname).ToList(),
                totalHours = group.Sum(g => g.houres)
            }).ToList();

            foreach (var item in works)
            {
                if (item.totalHours < 5)
                {

                    ViewData[$"color_{item.EmployeeName}"] = "red";
                }
                else
                {
                    ViewData[$"color_{item.EmployeeName}"] = "green";
                }
            }
            return View(works);
        }

        public IActionResult EmployeeWithoutTotal()
        {
            var works = context.works_Fors.GroupBy(w => new { w.essn }).Select(group => (dynamic)new
            {
                EmployeeName = group.Select(g => g.employee.fname).FirstOrDefault(),
                Projects = group.Select(g => g.project.pname).ToList(),
                Hours = group.Select(g => g.houres).ToList()
            }).ToList();

            foreach (var item in works)
            {
                for (int i = 0; i < item.Hours.Count; i++)
                {
                    bool isRed = item.Hours[i] < 5;
                    ViewData[$"color_{item.Projects[i]}"] = isRed ? "red" : "green";
                  
                }
            }

            return View(works);
        }
        #endregion
        public IActionResult Add()
        {
            List<works_for> work_Fors = context.works_Fors.ToList();
            List<Employee> employeeList = context.Employees.ToList();
            List<Project> projectList = context.Projects.ToList();
            List<Project> projectsWithEmployees = context.works_Fors.Select(p=>p.project).ToList();
            List<Project> projectsWithoutEmployees = projectList.Except(projectsWithEmployees).ToList();
            ViewData["projectsWithoutEmployees"] = projectsWithoutEmployees;
            ViewData["employeeList"] = employeeList;
            return View(work_Fors);
        }
        [HttpPost]
        public IActionResult AddDB(int employeeId, int[] projectId, int houres)
        {
            

            if (employeeId != 0 && projectId !=null)
            {
                foreach (var project in projectId)
                {
                    works_for works = new works_for()
                    {
                        essn = employeeId,
                        pnum = project,
                        houres = houres
                    };
                    context.works_Fors.Add(works);
                }
                context.SaveChanges();
                return RedirectToAction(nameof(EmployeeWithoutTotal));
            }
            
            return View(nameof(Add));
        }   
        public IActionResult EditEmployeeProjects()
        {
            List<works_for> work_Fors = context.works_Fors.ToList();
            List<Employee> employeeList = context.Employees.ToList();
            List<Project> projects = context.Projects.ToList();
            ViewData["employeeList"] = employeeList;
            ViewData["projects"] = projects;
   
            return View(work_Fors);  
        }
        public IActionResult Get(int id)
        {
            List<works_for> project = context.works_Fors.Where(w => w.essn == id).ToList();
            return PartialView("_ProjHourPartial", project);
        }

        public IActionResult GetHours(int id)
        {
            List<works_for> Hours = context.works_Fors.Where(w => w.pnum == id).ToList();
            return PartialView("_HoursPartial", Hours);
        }
        public IActionResult EditHours(int id,int hours)
        {
            works_for project = context.works_Fors.SingleOrDefault(w => w.pnum == id);
            if(project != null)
            {
                project.houres = hours;
                context.SaveChanges();
                return RedirectToAction("EmployeeWithoutTotal");
            }
            return RedirectToAction("EditEmployeeProjects");
        }
        
    }
}

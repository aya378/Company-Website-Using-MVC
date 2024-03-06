using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        CampanyContext context;
        public AccountController()
        {
            context = new CampanyContext();
        }
        //display form
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginDB(string name,string password)
        {
            Employee employee = context.Employees.SingleOrDefault(i => i.fname == name && i.Id ==int.Parse(password));
            if(employee != null)
            {
                HttpContext.Session.SetString("name", employee.fname);
                HttpContext.Session.SetInt32("Password", employee.Id);

                return RedirectToAction("Index", "Project");
            }
            return View("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("login");
        }

    }
}

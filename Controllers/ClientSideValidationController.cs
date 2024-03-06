using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ClientSideValidationController : Controller
    {
        public IActionResult SalaryRange(decimal salary)
        {
            if(salary<=10000 || salary >= 15000) {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
        public IActionResult NameLength(string name)
        {
            if (name.Length < 3 || name.Length > 30)
                return Json(false);
            else
                return Json(true);
        }
    }
}

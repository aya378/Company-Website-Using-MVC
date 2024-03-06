using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;
using WebApplication1.ServerValidation;

namespace WebApplication1.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [UniqueName]
        //[Remote("NameLength", "ClientSideValidation", ErrorMessage = "First name must be 3 up to 30 Characters")]
        [Required]
        public string Fname { get; set; }
        //[Remote("NameLength", "ClientSideValidation", ErrorMessage = " Last name must be 3 up to 30 Characters")]
        [UniqueName]
        [Required]
        public string Lname { get; set; }
        [RegularExpression("^Alex|Giza|Cairo$",ErrorMessage ="Address must be Alex , Giza oe Cairo")]
        [Required(ErrorMessage ="*")]
        public string Address { get; set; }
        [Remote("SalaryRange","ClientSideValidation",ErrorMessage ="Salary must be between 10000 and 15000")]
        public int Salary { get; set; }
        [Compare("ConfirmPassword",ErrorMessage ="Password must match ConfirmPassword")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="ConfirmPassword must match Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "*")]
        public  int dept_id { get; set; }
       [ValidateNever]
        public SelectList departments { set; get; }
    }
}

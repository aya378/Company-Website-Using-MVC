using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ServerValidation
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            EmployeeVM emp =(EmployeeVM) validationContext.ObjectInstance;
            CampanyContext context = new();
            var existingEmployee=context.Employees.FirstOrDefault(e=>e.fname==emp.Fname && e.lname==emp.Lname && e.dno == emp.dept_id);

            if (existingEmployee!=null)
            {
                return new ValidationResult("That Name already exist");
            }
            return ValidationResult.Success;
        }
    }
}

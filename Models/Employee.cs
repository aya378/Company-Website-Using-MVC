using static WebApplication1.Models.Work_for;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? fname { get; set; }
        public string? lname { get; set; }
        public DateOnly? bdate { get; set; }
        public string? address { get; set; }
        [Column(TypeName = "money")]
        public decimal? salary { get; set; }

        public string? Sex { get; set; }

        [ForeignKey("manager")]
        public int? superssn { get; set; }

        [ForeignKey("department")]
        public int? dno { get; set; }

        public virtual Department department { get; set; }

        public virtual Department manageDepartment { get; set; }


        public virtual List<works_for> Works_Fors { get; set; } = new List<works_for>();

        public virtual Employee manager { get; set; }

        [InverseProperty("manager")]
        public virtual List<Employee> group { get; set; }

        public virtual List<Depentent> Dependants { get; set; } = new List<Depentent>();
    }
}

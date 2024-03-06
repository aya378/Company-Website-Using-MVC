using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("managr")]
        public int? MGRssn { get; set; }
        public DateOnly? startdate { get; set; }

        [InverseProperty("manageDepartment")]
        public virtual Employee managr { get; set; }

        [InverseProperty("Department")]
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();

        public virtual List<Project> Projects { get; set; } = new List<Project>();

    }
}

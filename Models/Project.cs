using static WebApplication1.Models.Work_for;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string pname { get; set; }
        public string? plocation { get; set; }
        public string? city { get; set; }

        [ForeignKey("department")]
        public int dnum { get; set; }

        public virtual Department department { get; set; }

        public virtual List<works_for> Works_Fors { get; set; } = new List<works_for>();

    }
}

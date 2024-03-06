using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Work_for
    {
        [PrimaryKey("essn", "pnum")]
        public class works_for
        {
            [ForeignKey("employee")]
            public int essn { get; set; }

            [ForeignKey("project")]
            public int pnum { get; set; }
            public int houres { get; set; }

            public virtual Project project { get; set; }

            public virtual Employee employee { get; set; }
        }
    }
}

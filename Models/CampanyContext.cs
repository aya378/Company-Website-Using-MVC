using Microsoft.EntityFrameworkCore;
using static WebApplication1.Models.Work_for;

namespace WebApplication1.Models
{
    public class CampanyContext:DbContext
    {
        public CampanyContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.;Database=Companydata;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Depentent>().HasKey(d => new { d.essn, d.dependant_name });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Depentent> Dependants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<works_for> works_Fors { get; set; }

    }
}

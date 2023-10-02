using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Server.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John Doe", JoinDate = new DateTime(2022, 1, 1), IsWorking = true, ImageUrl = "/image/male.png" },
                new Employee { Id = 2, Name = "Jane Smith", JoinDate = new DateTime(2022, 2, 1), IsWorking = false, ImageUrl = "/image/female.png" }
            );

            // Seed data for Experiences
            modelBuilder.Entity<Experience>().HasData(
                new Experience { Id = 1, PositionName = "Software Developer", CompanyName = "Tech Corp", EmployeeId = 1 },
                new Experience { Id = 2, PositionName = "Senior Software Developer", CompanyName = "Innovative Solutions", EmployeeId = 1 },
                new Experience { Id = 3, PositionName = "Web Developer", CompanyName = "Web Experts", EmployeeId = 2 },
                new Experience { Id = 4, PositionName = "Senior Web Developer", CompanyName = "Web Innovators", EmployeeId = 2 }
            );
        }
    }
}

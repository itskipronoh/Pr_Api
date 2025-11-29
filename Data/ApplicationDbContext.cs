using Microsoft.EntityFrameworkCore;
using PR.Models.Entities;

namespace PR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your DbSets here
        // Example: public DbSet<YourEntity> YourEntities { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<Goal> Goals { get; set; }

        public  DbSet<KPI> KPIs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>(); // store enum as a string

            base.OnModelCreating(modelBuilder);
            // seed data 
            SeedData(modelBuilder, GetKPIs());
        }

        private DbSet<KPI> GetKPIs()
        {
            return KPIs;
        }

        private void SeedData(ModelBuilder modelBuilder, DbSet<KPI> kPIs)
    {
        // Seed an admin user with default password "Admin@123"
       
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                EmployeeId = "EMP001",
                Email = "admin@performancemanagement.com",
                PasswordHash = "Admin@123", 
                FirstName = "System",
                LastName = "Administrator",
                Role = Models.Enums.UserRole.Admin,
                Department = "IT",
                JobTitle = "System Administrator",
                IsActive = true,
                HireDate = new DateTime(2020, 1, 1),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
           // Seed KPI Data
    modelBuilder.Entity<KPI>().HasData(
        new KPI { Id = 1, Name= "Revenue Growth %", MeasurementUnit = "%" },
        new KPI { Id = 2, Name = "Customer Acquisition", MeasurementUnit = "Count"},
        new KPI { Id = 3, Name = "Operational Efficiency", MeasurementUnit = "%" },
        new KPI { Id = 4, Name = "Employee Satisfaction", MeasurementUnit = "%" }
    );

            // Seed Goals Data
            _ = modelBuilder.Entity<Goal>().HasData(
                new Goal
                {
                    Id = 1,
                    Title = "Increase Annual Revenue",
                    Description = "Grow overall company revenue by expanding market share.",
                    Category = (Models.Enums.GoalCategory)1,
                    Status = (Models.Enums.GoalStatus)1,
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2025, 12, 31),
                    ApprovedBy = (int?)(Models.Enums.UserRole)1,
                },
                new Goal
                {
                    Id = 2,
                    Title = "Enhance Customer Base",
                    Description = "Improve customer onboarding experience and expand reach.",
                    Category = (Models.Enums.GoalCategory)1,
                    Status = (Models.Enums.GoalStatus)1,
                    StartDate = new DateTime(2025, 2, 1),
                    EndDate = new DateTime(2025, 8, 30),
                    ApprovedBy = (int?)(Models.Enums.UserRole)1,
                },
                new Goal
                {
                    Id = 3,
                    Title = "Improve Internal Processes",
                    Description = "Streamline workflows using automation.",
                    Category = (Models.Enums.GoalCategory)1,
                    Status = (Models.Enums.GoalStatus)1,
                    StartDate = new DateTime(2025, 1, 15),
                    EndDate = new DateTime(2025, 10, 15),
                    ApprovedBy = (int?)(Models.Enums.UserRole)1,
                }
            );

    }
    }
}

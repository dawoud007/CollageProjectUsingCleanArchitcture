using Collage.Domain.Entities;
using Collage.Domain.Entities.ApplicationUser;
using Collage.Domain.Entities.ApplicationUser.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Collage.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CollageUser>? CollageUsers { get; set; }

        public DbSet<Collages>? Products { get; set; }
        public DbSet<CollageDepartment>? CollageDepartments { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Professor>? Professors { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Worker>? Workers { get; set; }
        public DbSet<Student>? Students { get; set; }



        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Load your connection string from appsettings.json or another configuration source
            // Replace with your chosen provider and connection string

            // Other services and configurations...
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=DESKTOP-06NBEEH\\SQLEXPRESS;Database=Collagsw;Trusted_Connection=True;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString) // Use SQL Server
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {










            var hasher = new PasswordHasher<CollageUser>();
            var seedApplicationUser = new CollageUser
            {
                Name = "Leqaa",
                Email = "Leqaa.Technical@gmail.com",
                Gender = Gender.Female,
                EmailConfirmed = true,
                NormalizedEmail = "LEQAA.TECHNICAL@GMAIL.COM",
                UserName = "Leqaa",
                Role = Role.Admin,

                NormalizedUserName = "LEQAA",
                PasswordHash = hasher.HashPassword(null!, "P@ssw0rd123")
            };
            modelBuilder.Entity<CollageUser>().HasData(seedApplicationUser);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var CollageId1 = Guid.NewGuid();
            var CollageId2 = Guid.NewGuid();
            var CollageId13 = Guid.NewGuid();
            // Seed Faculty
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id = CollageId1, Name = "Faculty 1", CollageId = Guid.NewGuid() },
                new Faculty { Id = CollageId2, Name = "Faculty 2", CollageId = Guid.NewGuid() },
                new Faculty { Id = CollageId13, Name = "Faculty 3", CollageId = Guid.NewGuid() }
            );

            // Seed Professor
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = Guid.NewGuid(), Name = "Professor 1", FacultyId = CollageId1 },
                new Professor { Id = Guid.NewGuid(), Name = "Professor 2", FacultyId = CollageId2 },
                new Professor { Id = Guid.NewGuid(), Name = "Professor 3", FacultyId = CollageId13 }
            );
            /* 
                      // Seed Employee
                      modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id = Guid.NewGuid(), Name = "Employee 1" },
                    new Employee { Id = Guid.NewGuid(), Name = "Employee 2"},
                    new Employee { Id = Guid.NewGuid(), Name = "Employee 3" }
                );

                      // Seed Subject
                   modelBuilder.Entity<Subject>().HasData(
                          new Subject { Id = Guid.NewGuid(), Code = "Subject 1", ProfessorId = Guid.NewGuid() },
                          new Subject { Id = Guid.NewGuid(), Code = "Subject 2", ProfessorId = Guid.NewGuid() },
                          new Subject { Id = Guid.NewGuid(), Code = "Subject 3", ProfessorId = Guid.NewGuid() }
                      );

                      // Seed Worker
                      modelBuilder.Entity<Worker>().HasData(
                          new Worker { Id = Guid.NewGuid(), Name = "Worker 1", JobTitle = "Job 1" },
                          new Worker { Id = Guid.NewGuid(), Name = "Worker 2", JobTitle = "Job 2" },
                          new Worker { Id = Guid.NewGuid(), Name = "Worker 3", JobTitle = "Job 3" }
                      );

                      // Seed Student
                      modelBuilder.Entity<Student>().HasData(
                          new Student { Id = Guid.NewGuid(), Name = "Student 1" *//* Include Student attributes *//* },
                          new Student { Id = Guid.NewGuid(), Name = "Student 2"*//* Include Student attributes *//* },
                          new Student { Id = Guid.NewGuid(), Name = "Student 3"*//* Include Student attributes *//* }
                      );*/

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

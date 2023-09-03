
using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Persistence.CollageBusiness;
using Collage.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Collage.Persistence.DependencyInjection;
public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString) // Use SQL Server
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        });



        // In Startup.cs ConfigureServices method
        services.AddScoped<ICollageUserRepository, CollageUserRepository>();
        services.AddScoped<IWorkerBusiness, WorkerBusiness>();
        services.AddScoped<IWorkerRepository, WorkerRepository>();

        services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();


        services.AddScoped<IStudentBusiness, StudentBusiness>();
        services.AddScoped<IStudentRepository, StuentRepository>();

        services.AddScoped<ISubjectBusiness, SubjectBusiness>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();

        services.AddScoped<ICollageBusiness, CollageBusinesses>();
        services.AddScoped<ICollageRepository, CollageRepository>();

        services.AddScoped<ICollageDepartmentBusiness, CollageDepartmentBusiness>();
        services.AddScoped<ICollageDepartmentRepository, CollageDepartmentRepository>();

        services.AddScoped<IFactulyBusiness, FacultyBusiness>();
        services.AddScoped<IFacultyRepository, FactulyRepository>();

        services.AddScoped<IProfessorBusiness, ProfessorBusiness>();
        services.AddScoped<IProfessorRepository, ProfessorRepository>();
        return services;
    }
}
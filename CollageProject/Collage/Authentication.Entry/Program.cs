using Collage.Application.DependencyInjection;
using Collage.Application.Validations;
using Collage.Domain.Entities.ApplicationRole;
using Collage.Domain.Entities.ApplicationUser;
using Collage.Entry.Options;
using Collage.Infrastructure.DependencyInjection;
using Collage.Infrastructure.Models;
using Collage.Persistence;
using Collage.Persistence.DependencyInjection;
using Collage.Presentation.Controllers;
using ElectronicsShop_service.MapperProfiles;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddApplicationPart(typeof(DepartManagmentController).Assembly)
    .AddControllersAsServices();
builder.Services.AddAutoMapper(typeof(WorkerMappings));

builder.Services.AddValidatorsFromAssembly(typeof(FacultyValidations).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Jwt jwt = new();
builder.Configuration.GetSection("Jwt").Bind(jwt);
builder.Services.AddMvc();

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.ConfigureOptions<SwaggerGenOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        ValidateAudience = true,
        ValidateIssuer = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
        ValidateIssuerSigningKey = true
    };
});

string CorsPolicyName = "MyPolicy";
builder.Services.ConfigureOptions<CorsPolicyOptionsSetup>();
builder.Services.AddCors();

builder.Services.ConfigureOptions<IdentityOptionsSetup>();

builder.Services.AddIdentity<CollageUser, ApplicationRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddTokenProvider<DataProtectorTokenProvider<CollageUser>>(TokenOptions.DefaultProvider);

builder.Services
    .AddPersistence(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication();



var app = builder.Build();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>()!;

    context.Database.Migrate();

}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }




app.UseCors(CorsPolicyName);
app.MapControllers();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    // Map your library's controllers to the appropriate routes
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});




app.Run();

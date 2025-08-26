using System.Reflection;
using EmployeeService.Data;
using EmployeeService.Interfaces;
using EmployeeService.Profiles;
using EmployeeService.Repositories;
using InfraCore.Commons.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped(typeof(ISqlRepository<>), typeof(SqlRepository<>));
builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService.Services.EmployeeService));

builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile<DomainProfiles>();
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddCognitoAuthentication(builder.Configuration);
builder.Services.AddSwaggerDocumentation(builder.Configuration, "Employee API", "v1");

var app = builder.Build();

// Configure the HTTP request pipeline
app.UsePathBase("/api/employee-service");
app.UseSwagger(c =>
{
    c.PreSerializeFilters.Add((swagger, req) =>
    {
        swagger.Servers = new List<OpenApiServer>
        {
            new OpenApiServer { Url = $"{req.Scheme}://{req.Host.Value}/api/employee-service" }
        };
    });
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/employee-service/swagger/v1/swagger.json", "Employee API v1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

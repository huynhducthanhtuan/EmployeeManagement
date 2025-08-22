using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UsePathBase("/api/auth-service");
app.UseSwagger(c =>
{
    c.PreSerializeFilters.Add((swagger, req) =>
    {
        swagger.Servers = new List<OpenApiServer>
        {
            new OpenApiServer { Url = $"{req.Scheme}://{req.Host.Value}/api/auth-service" }
        };
    });
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/auth-service/swagger/v1/swagger.json", "AuthService API v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

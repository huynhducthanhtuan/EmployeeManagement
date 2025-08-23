using Amazon;
using Amazon.CognitoIdentityProvider;
using AuthService.DTO;
using AuthService.Interfaces;
using AuthService.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// AWS Cognito config
builder.Services.Configure<CognitoOptions>(builder.Configuration.GetSection("Cognito"));
var region = RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"] ?? "ap-southeast-1");
builder.Services.AddSingleton<IAmazonCognitoIdentityProvider>(_ => new AmazonCognitoIdentityProviderClient(region));

// Add services to the container.
builder.Services.AddScoped<ICognitoAuthService, CognitoAuthService>();

builder.Services.AddControllers();
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

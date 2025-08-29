using System.Reflection;
using Amazon;
using Amazon.CognitoIdentityProvider;
using AuthService.DTO;
using AuthService.Helpers;
using AuthService.Interfaces;
using AuthService.Services;
using InfraCore.Commons.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// AWS Secrets Manager config for production environment
//if (!builder.Environment.IsDevelopment())
//{
//    var secretJson = await AwsSecretHelper.GetSecretAsync("EmployeeManagementSecrets", "ap-southeast-1");

//    if (!string.IsNullOrEmpty(secretJson))
//    {
//        // Parse JSON secret to IConfiguration
//        var secretConfig = new ConfigurationBuilder()
//            .AddJsonStream(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(secretJson)))
//            .Build();

//        builder.Configuration.AddConfiguration(secretConfig);
//    }
//}

// AWS Cognito config
builder.Services.Configure<CognitoOptions>(builder.Configuration.GetSection("Cognito"));
builder.Services.AddSingleton<IAmazonCognitoIdentityProvider>(_ =>
    new AmazonCognitoIdentityProviderClient(RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"])));

// Add services to the container
builder.Services.AddScoped<ICognitoAuthService, CognitoAuthService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();

builder.Services.AddCognitoAuthentication(builder.Configuration);
builder.Services.AddSwaggerDocumentation(builder.Configuration, "Auth API", "v1");

var app = builder.Build();

// Configure SwaggerUI
app.UseSwagger(c =>
{
    c.PreSerializeFilters.Add((swagger, req) =>
    {
        swagger.Servers = new List<OpenApiServer>
        {
            new OpenApiServer { Url = $"{req.Scheme}://{req.Host.Value}" }
        };
    });
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API v1");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

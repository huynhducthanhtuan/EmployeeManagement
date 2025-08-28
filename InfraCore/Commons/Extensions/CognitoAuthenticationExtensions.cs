using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace InfraCore.Commons.Extensions
{
    public static class CognitoAuthenticationExtensions
    {
        public static IServiceCollection AddCognitoAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var cognitoRegion = configuration["AWS:Region"];
            var cognitoPoolId = configuration["Cognito:UserPoolId"];
            var cognitoClientId = configuration["Cognito:ClientId"];
            var cognitoIssuerUrl = $"https://cognito-idp.{cognitoRegion}.amazonaws.com/{cognitoPoolId}";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = cognitoIssuerUrl;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = cognitoIssuerUrl,
                    ValidateAudience = true,
                    ValidAudience = cognitoClientId,
                    ValidateLifetime = true
                };
                // Map Cognito groups into Role claim
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if (context.Principal != null && context.Principal.HasClaim(c => c.Type == "cognito:groups"))
                        {
                            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                            var groups = context.Principal.FindAll("cognito:groups").Select(c => c.Value).ToList();
                            foreach (var group in groups)
                            {
                                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, group));
                            }
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization();
            return services;
        }
    }
}

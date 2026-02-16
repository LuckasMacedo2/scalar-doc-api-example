using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApiScalarExample.Extensions
{
    public static class AutenticationServicesExtension
    {
        public static void AddAutenticationAndAutorization(this IServiceCollection services)
        {
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") 
                ?? throw new ArgumentNullException("The jwt key isn't informed");


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            services.AddAuthorization();
        }
    }
}

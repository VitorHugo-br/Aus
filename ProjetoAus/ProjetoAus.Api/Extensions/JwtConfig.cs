using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ProjetoAus.Api.Extensions;

public static class JwtConfig
{
    public static void AddJwtConfig(this WebApplicationBuilder builder)
    {
        var secret = builder.Configuration["Jwt:SecretKey"];
        if (string.IsNullOrEmpty(secret))
        {
            throw new InvalidOperationException("A configuração 'Jwt:SecretKey' não foi encontrada!");
        }
        var key = Encoding.ASCII.GetBytes(secret);
        
        builder.Services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(jwtBearerOptions =>
        {
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = "ProjetoAus",
                ValidateIssuer = true,
                ValidAudience = "ProjetoAus",
                ValidateAudience = true,
                ClockSkew =  TimeSpan.Zero
            };
        });
    } 
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoAus.Models;

namespace ProjetoAus.BLL.Services;

public class TokenService(IConfiguration configuration)
{
    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var secretKey = configuration["Jwt:SecretKey"];
        if (string.IsNullOrEmpty(secretKey)) return null;
        var key = Encoding.ASCII.GetBytes(secretKey);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = "ProjetoAus",   
            Audience = "ProjetoAus",  
            SigningCredentials = credentials
        };

        var token = handler.CreateToken(tokenDescriptor);
        var tokenString = handler.WriteToken(token);
        return tokenString;
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(new Claim(ClaimTypes.Email, user.UserName));

        return ci;
    }
}
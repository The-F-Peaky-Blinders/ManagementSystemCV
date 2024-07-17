using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ManagementSystemCV.App.Interfaces
{
    public interface IJwtAuthenticationService
    {
          string GenerateJwtToken(string email);
    }

    public class JwtAuthenticationService : IJwtAuthenticationService
{
    private readonly IConfiguration _configuration;

    public JwtAuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(string email)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ncjdncjvurbuedxwn233nnedxee+dfr-"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            claims: new[] { new Claim(ClaimTypes.Email, email) },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    }
}
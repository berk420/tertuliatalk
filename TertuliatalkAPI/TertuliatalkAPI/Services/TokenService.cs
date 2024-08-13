using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TertuliatalkAPI.Services;

public class TokenService : ITokenService
{
    readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
    {
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]));
        
        var dateTimeNow = DateTime.UtcNow;

        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: _configuration["AppSettings:ValidIssuer"],
            audience: _configuration["AppSettings:ValidAudience"],
            claims: new List<Claim> {
                new Claim("email", request.Email)
            },
            notBefore: dateTimeNow,
            expires: dateTimeNow.Add(TimeSpan.FromMinutes(550)),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );

        return Task.FromResult(new GenerateTokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwt),
            TokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(550))
        });
    }
}
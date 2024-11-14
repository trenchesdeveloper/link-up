using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Entities;
using api.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace api.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new ArgumentNullException("TokenKey is missing from appsettings");
        
        if (tokenKey.Length < 64) throw new ArgumentException("TokenKey must be long");
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username)
        };
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}
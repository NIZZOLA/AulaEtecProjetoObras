using Microsoft.IdentityModel.Tokens;
using Obra.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obra.API
{
    public static class TokenService
    {
        public static string GenerateToken(UsuarioModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Username),  // User.Identity.Name
                new Claim(ClaimTypes.Role, user.Perfil.ToString()),       // User.IsInRole
                new Claim("Personal", "RegraPersonalizada")
            }),
                Expires = DateTime.UtcNow.AddHours(Settings.ExpiresTokenInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

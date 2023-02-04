using Microsoft.IdentityModel.Tokens;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Authentication;
using Quizlet.Core.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateToken(TokenData data, AppSettings settings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Secret);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", data.UserId),
                    new Claim("username", data.Username),
                    new Claim("roles", data.Roles)
                }),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

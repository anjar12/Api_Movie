using Domain.Interfaces;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public AuthToken GenerateToken(string stringkey, string modul)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[stringkey + ":Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.Now.AddHours(1);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, modul.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(audience: _configuration[stringkey + ":Audience"],
                                             issuer: _configuration[stringkey + ":Issuer"],
                                             claims: claims,
                                             expires: expirationDate,
                                             signingCredentials: credentials);
            var authToken = new AuthToken();
            authToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authToken.ExpirationDate = expirationDate;
            return authToken;
        }
        public AuthToken PageGenerateToken(string stringkey, string modul)
        {
            var authToken = new AuthToken();
            authToken = GenerateToken(stringkey, modul);
            return authToken;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shopy.Application.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Api.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration _configuration;

        public TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(string user, string password)
        {
            // TODO: use username and password in claims

            //var keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            //var securityKey = new SymmetricSecurityKey(keyBytes);
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var token = new SecurityTokenDescriptor(
            //    issuer: _configuration["Jwt:Issuer"],
            //    audience: _configuration["Jwt:Issuer"],
            //    claims: null,
            //    expires: DateTime.Now.AddMinutes(120),
            //    signingCredentials: credentials);

            //var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            //return await Task.FromResult(accessToken);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

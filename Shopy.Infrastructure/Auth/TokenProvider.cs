using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shopy.Application.Interfaces;
using Shopy.Common.Interfaces;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Auth
{
    public class AuthProvider : IAuthProvider
    {
        private readonly JwtOptions jwtOptions;
        private readonly IDateTime dateTime;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRepository<UserCredentials> userCredentials;

        public AuthProvider(
            IOptions<JwtOptions> jwtOptions,
            IDateTime dateTime,
            IHttpContextAccessor httpContextAccessor,
            IRepository<UserCredentials> userCredentials)
        {
            this.jwtOptions = jwtOptions.Value;
            this.dateTime = dateTime;
            this.httpContextAccessor = httpContextAccessor;
            this.userCredentials = userCredentials;
        }

        public string User => httpContextAccessor
            .HttpContext?
            .User?
            .FindFirst(JwtRegisteredClaimNames.Sub)
            ?.Value;

        public async Task<bool> Authenticate(string user, string password)
        {
            var credentials = (await userCredentials.List()).ToList();

            return credentials.Any(item => item.Challenge(user, password));
        }

        public async Task<string> GenerateToken(string user)
        {
            var key = Encoding.UTF8.GetBytes(jwtOptions.Key);
            var symentricKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symentricKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

            var now = dateTime.Now;

            var securityToken = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Issuer,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(jwtOptions.TokenLifetimeInMinutes),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(securityToken);

            return await Task.FromResult(token);
        }
    }
}

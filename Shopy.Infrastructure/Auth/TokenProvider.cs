using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shopy.Application.Interfaces;
using Shopy.Common.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Auth
{
    public class JwtTokenAuthProvider : IAuthProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IDateTime _dateTime;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtTokenAuthProvider(
            IOptions<JwtOptions> jwtOptions,
            IDateTime dateTime,
            IHttpContextAccessor httpContextAccessor)
        {
            _jwtOptions = jwtOptions.Value;
            _dateTime = dateTime;
            _httpContextAccessor = httpContextAccessor;
        }

        public string User => _httpContextAccessor
            .HttpContext?
            .User?
            .FindFirst(JwtRegisteredClaimNames.Sub)
            ?.Value;

        public async Task<string> GenerateToken(string user)
        {
            var key = Encoding.UTF8.GetBytes(_jwtOptions.Key);
            var symentricKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symentricKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

            var now = _dateTime.Now;

            var securityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Issuer,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_jwtOptions.TokenLifetimeInMinutes),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(securityToken);

            return await Task.FromResult(token);
        }
    }
}

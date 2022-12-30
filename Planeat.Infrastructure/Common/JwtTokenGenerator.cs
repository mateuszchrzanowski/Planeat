using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Planeat.Infrastructure.Services;
using Planeat.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Common
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly AuthenticationSettings _authenticationSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
            AuthenticationSettings authenticationSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName, string role)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey)), 
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, $"{firstName} {lastName}"),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _authenticationSettings.JwtIssuer,
                audience: _authenticationSettings.JwtAudience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_authenticationSettings.JwtExpireMinutes),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}

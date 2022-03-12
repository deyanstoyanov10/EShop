namespace EShop.Services.Providers
{
    using Common;
    using Contracts;
    using Common.Entities;

    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using System.Linq;
    using System.Text;
    using System.Security.Claims;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;

    public class JwtTokenProvider : IJwtTokenProvider
    {
        private const int TOKEN_EXPIRES_DAYS = 7;

        private readonly AppSettings _applicationSettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenProvider(
            IDateTimeProvider dateTimeProvider,
            IOptions<AppSettings> applicationSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _applicationSettings = applicationSettings.Value;
        }

        public string GenerateToken(AppUser user, IEnumerable<string> roles = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_applicationSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            if (roles != null)
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = _dateTimeProvider.GetDateTimeNow().AddDays(TOKEN_EXPIRES_DAYS),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}

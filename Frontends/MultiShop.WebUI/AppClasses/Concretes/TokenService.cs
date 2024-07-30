using Microsoft.IdentityModel.Tokens;
using MultiShop.WebUI.AppClasses.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.WebUI.AppClasses.Concretes
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<ClaimsPrincipal> TokenReadAsync(string token)
        {
            JwtSecurityTokenHandler jwtSecurityToken = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:key"]);
            TokenValidationResult result = await jwtSecurityToken.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidAudience = _configuration["JWT:audience"],
                ValidIssuer = _configuration["JWT:issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            });
            if (result.IsValid)
            {
                ClaimsIdentity claimsIdentity = result.ClaimsIdentity;
               return new ClaimsPrincipal(claimsIdentity);
            }
            return null;

        }
    }
}

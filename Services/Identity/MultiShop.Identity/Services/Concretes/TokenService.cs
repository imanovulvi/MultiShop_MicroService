using Microsoft.IdentityModel.Tokens;
using MultiShop.Identity.Models.AppClass;
using MultiShop.Identity.Services.Abstactions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.Identity.Services.Concretes
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
    

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
      
        }
        public Token CreateAccessToken(List<Claim> claims)
        {

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["JWT:key"]));

            JwtSecurityToken jwtSecurity = new JwtSecurityToken(
                 issuer: configuration["JWT:issuer"],
                audience: configuration["JWT:audience"],
                expires: DateTime.UtcNow.AddMinutes(int.Parse(configuration["JWT:expires"])),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                claims: claims

                );

            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();

            return  new () {
            AccessToken= securityTokenHandler.WriteToken(jwtSecurity),
            RefreshToken=""

            };
        }
    }
}

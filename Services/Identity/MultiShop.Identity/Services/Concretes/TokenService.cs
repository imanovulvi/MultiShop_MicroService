using Microsoft.IdentityModel.Tokens;
using MultiShop.Identity.Models.AppClass;
using MultiShop.Identity.Services.Abstactions;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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



        public string CreateAccessToken(List<Claim> claims, DateTime expire)
        {

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["JWT:key"]));

            JwtSecurityToken jwtSecurity = new JwtSecurityToken(
                 issuer: configuration["JWT:issuer"],
                audience: configuration["JWT:audience"],
                expires: expire,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                claims: claims

                );
           
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();

            return securityTokenHandler.WriteToken(jwtSecurity);
           
        }

        public string CreateRefreshToken()
        {
            byte[] bytes = new byte[20];
           RandomNumberGenerator random= RandomNumberGenerator.Create();
            random.GetBytes(bytes);
           return Convert.ToBase64String(bytes);
        }

        public Token GetTokens(List<Claim> claims,DateTime expire)
        {
            return new()
            {
                AccessToken = CreateAccessToken(claims, expire),
                RefreshToken = CreateRefreshToken(),
                RefreshTokenExpire = expire.AddDays(1)
            };
            
        }
    }
}

using MultiShop.Identity.Models.AppClass;
using System.Security.Claims;

namespace MultiShop.Identity.Services.Abstactions
{
    public interface ITokenService
    {
        public Token CreateAccessToken(List<Claim> claims);
    }
}

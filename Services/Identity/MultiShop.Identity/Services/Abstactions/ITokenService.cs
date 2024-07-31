using MultiShop.Identity.Models.AppClass;
using System.Security.Claims;

namespace MultiShop.Identity.Services.Abstactions
{
    public interface ITokenService
    {
        string CreateAccessToken(List<Claim> claims, DateTime expire);

        string CreateRefreshToken();
        Token GetTokens(List<Claim> claims, DateTime expire);

    }
}

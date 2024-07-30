using System.Security.Claims;

namespace MultiShop.WebUI.AppClasses.Abstractions
{
    public interface ITokenService
    {
        Task<ClaimsPrincipal> TokenReadAsync(string token);
    }
}

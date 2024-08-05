using MultiShop.DTOs.DTOs.Identity;
using MultiShop.WebUI.AppClasses.Concretes;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Identity
{
    public interface IIdentityService:IHttpClientService
    {
        Task<UserInfoDTO> GetUserInfoAsync(string url, string userId, string header = null);
    }
}

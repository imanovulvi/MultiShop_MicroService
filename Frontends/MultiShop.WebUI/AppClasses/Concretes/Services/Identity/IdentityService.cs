using MultiShop.DTOs.DTOs.Identity;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Identity;
using Newtonsoft.Json;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Identity
{
    public class IdentityService:HttpClientService,IIdentityService
    {
        public async Task<UserInfoDTO> GetUserInfoAsync(string url,string userId,string header=null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetUserInfo?id=" + userId);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserInfoDTO>(json);
            }
            return null;
        }
    }
}

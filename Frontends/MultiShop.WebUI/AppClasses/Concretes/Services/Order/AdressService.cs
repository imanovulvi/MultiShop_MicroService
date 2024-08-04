using MultiShop.DTOs.DTOs.Order.Adress;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Order;
using Newtonsoft.Json;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Order
{
    public class AdressService:HttpClientService,IAdressService
    {
        public async Task<ResultAdressDTO> GetByUserIdAsync(string url, string userId, string header = null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetByUserId?userId=" + userId);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ResultAdressDTO>(json);
            }
            return null;
        }
    }
}

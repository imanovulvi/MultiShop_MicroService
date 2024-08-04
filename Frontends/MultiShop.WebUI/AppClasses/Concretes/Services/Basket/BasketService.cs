using MultiShop.DTOs.DTOs.Basket;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Basket;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Basket
{
    public class BasketService:HttpClientService,IBasketService
    {

        public async Task<BasketTotalDTO> GetBasketTotalAsync(string url, string header)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<BasketTotalDTO>(json);
            }
            return null;
        }
    }
}

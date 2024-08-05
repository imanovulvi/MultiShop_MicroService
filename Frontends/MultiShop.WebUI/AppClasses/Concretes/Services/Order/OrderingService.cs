using MultiShop.DTOs.DTOs.Order.Ordering;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Order;
using Newtonsoft.Json;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Order
{
    public class OrderingService:HttpClientService,IOrderingService
    {
        public async Task<List<ResultOrderingDTO>> GetByUserIdAsync(string url,string userId, string header=null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetByUserId?userId="+userId);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ResultOrderingDTO>>(json);
            }
            return null;
        }


    }
}

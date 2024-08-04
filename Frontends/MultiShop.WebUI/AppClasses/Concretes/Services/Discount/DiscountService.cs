using MultiShop.DTOs.DTOs.Discount;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Discount;
using Newtonsoft.Json;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Discount
{
    public class DiscountService : HttpClientService, IDiscountService
    {
        public async Task<ResultDiscountDTO> GetByCodeActiveAsync(string url, string code,string header=null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetByCodeIsActive?code=" + code);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ResultDiscountDTO>(json);
            }
            return null;
        }
    }
}

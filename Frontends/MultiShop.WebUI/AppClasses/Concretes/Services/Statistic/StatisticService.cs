using MultiShop.WebUI.AppClasses.Abstractions.Services.Statistic;
using Newtonsoft.Json;
using System.Security.Policy;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
        public readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public StatisticService(IConfiguration configuration)
        {

            this.httpClient = new HttpClient();
            this.configuration = configuration;
        }
        public void AddHeader(string header=null)
        {
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + header);
        }

        public async Task<long> BrandCountAsync(string header=null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(configuration["ServiceUrl:Catalog:Statistic"]+ "/BrandCount");

            if (response.IsSuccessStatusCode)
                return Convert.ToInt64(await response.Content.ReadAsStringAsync()); 
            
            return 0;
        }

        public async Task<long> CategoryCountAsync(string header = null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(configuration["ServiceUrl:Catalog:Statistic"] + "/CategoryCount");

            if (response.IsSuccessStatusCode)
                return Convert.ToInt64(await response.Content.ReadAsStringAsync());
            
            return 0;
        }

      
        public async Task<long> ProductCountAsync(string header=null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(configuration["ServiceUrl:Catalog:Statistic"] + "/ProductCount");

            if (response.IsSuccessStatusCode)
                return Convert.ToInt64(await response.Content.ReadAsStringAsync());

            return 0;
        }

        public async Task<string> MaxPriceProductNameAsync(string header=null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(configuration["ServiceUrl:Catalog:Statistic"] + "/MaxPriceProductName");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return "";
        }

        public async Task<string> MinPriceProductNameAsync(string header=null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(configuration["ServiceUrl:Catalog:Statistic"] + "/MinPriceProductName");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return "";
        }

    }
}

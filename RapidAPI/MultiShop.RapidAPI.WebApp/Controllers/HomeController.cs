using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidAPI.WebApp.ModelViews;

using Newtonsoft.Json;
using System.Diagnostics;
using static MultiShop.RapidAPI.WebApp.ModelViews.WeatherView;

namespace MultiShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient client;

        public HomeController(IHttpClientFactory httpClient)
        {

            client = httpClient.CreateClient();
        }


        public async Task<RealTimeProductView.Rootobject> RealTimeProduct()
        {
           
         
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search?q=Nike%20shoes&country=us&language=en&page=1&limit=30&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
                Headers =
    {
        { "x-rapidapi-key", "de412496a3msh9dc5d184394c160p1293f4jsn11c12a544f77" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
               return  JsonConvert.DeserializeObject<RealTimeProductView.Rootobject>(body);
             
            }
        }


        public async Task<WeatherView.Rootobject> Weather()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/landon/EN"),
                Headers =
    {
        { "x-rapidapi-key", "de412496a3msh9dc5d184394c160p1293f4jsn11c12a544f77" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherView.Rootobject>(body);
               
            }
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.temp = (await Weather()).main.temp;

       
            ViewBag.min_temp = (await Weather()).main.temp_min;
            ViewBag.max_temp = (await Weather()).main.temp_max;

            ViewBag.productTitle=(await RealTimeProduct()).data[0].product_title;
            return View();
        }


    }
}

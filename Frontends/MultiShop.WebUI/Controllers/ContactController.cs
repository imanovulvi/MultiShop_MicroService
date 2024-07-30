using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Contact;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        string url = "";

        HttpClient httpClient;

        public ContactController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Contact"];

            httpClient = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Send(CreateContactDTO create)
        {
            create.SendDate = DateTime.Now;
            create.IsRead = false;
            StringContent stringConten = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url + "/Create", stringConten);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Contact/Index");
            }
            return View();
        }
    }
}

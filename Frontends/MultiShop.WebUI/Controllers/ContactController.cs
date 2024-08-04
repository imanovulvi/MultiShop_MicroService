using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Contact;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        string url = "";



        public ContactController(IContactService contactService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Contact"];


            this.contactService = contactService;
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

            if (await contactService.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Contact/Index");
            }
            return View();
        }
    }
}

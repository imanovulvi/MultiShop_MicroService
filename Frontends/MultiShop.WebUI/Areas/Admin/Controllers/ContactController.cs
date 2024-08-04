using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Contact;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly string url;
      
        private readonly IContactService contactService;

        public ContactController(IConfiguration configuration, IContactService contactService)
        {

            url = configuration["ServiceUrl:Catalog:Contact"];
   
            this.contactService = contactService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Contact";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Contact";
            ViewBag.v3 = "Contact list";
            return View(await contactService.GetAllAsync<ResultContactDTO>(url));

          
        }
        
        public async Task<IActionResult> Delete(string id)
        {

            if (await contactService.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Contact/Index");
            }
            return View();

        }
    }
}

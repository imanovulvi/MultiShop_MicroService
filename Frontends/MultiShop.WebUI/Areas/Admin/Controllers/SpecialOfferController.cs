using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.SpecialOffer;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly string url;
     
        private readonly ISpecialOfferService offerService;

        public SpecialOfferController(IConfiguration configuration, ISpecialOfferService offerService)
        {

            url = configuration["ServiceUrl:Catalog:SpecialOffer"];
          
            this.offerService = offerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "SpecialOffer";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "SpecialOffer";
            ViewBag.v3 = "SpecialOffer list";

            return View(await offerService.GetAllAsync<ResultSpecialOfferDTO>(url));

           
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecialOfferDTO create)
        {

            if (await offerService.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/SpecialOffer/Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {

            if (await offerService.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/SpecialOffer/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return View(await offerService.GetByIdAsync<UpdateSpecialOfferDTO>(url, id));

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateSpecialOfferDTO categoryDTO)
        {

            if (await offerService.PutAsync(url, categoryDTO, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/SpecialOffer/Index");
            }


            return View();

        }

    }
}

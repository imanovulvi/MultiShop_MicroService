using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.DiscountOffer;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DiscountOfferController : Controller
    {
        private readonly string url;

        private readonly IDiscountOfferService discountOffer;

        public DiscountOfferController(IConfiguration configuration, IDiscountOfferService discountOffer)
        {

            url = configuration["ServiceUrl:Catalog:DiscountOffer"];

            this.discountOffer = discountOffer;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "DiscountOffer";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "DiscountOffer";
            ViewBag.v3 = "DiscountOffer list";

            return View(await discountOffer.GetAllAsync<ResultDiscountOfferDTO>(url));

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountOfferDTO create)
        {

            if (await discountOffer.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/DiscountOffer/Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {

            if (await discountOffer.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/DiscountOffer/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return View(await discountOffer.GetByIdAsync<UpdateDiscountOfferDTO>(url,id));


        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiscountOfferDTO discountOfferDTO)
        {
            if (await discountOffer.PutAsync(url, discountOfferDTO, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/DiscountOffer/Index");
            }

            return View();

        }

    }
}


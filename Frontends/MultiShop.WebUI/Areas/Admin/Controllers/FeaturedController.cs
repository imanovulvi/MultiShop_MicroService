using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Featured;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FeaturedController : Controller
    {
        private readonly string url;

        private readonly IConfiguration configuration;
        private readonly IFeaturedService sliderService;

        public FeaturedController(IConfiguration configuration, IFeaturedService sliderService)
        {

            url = configuration["ServiceUrl:Catalog:Featured"];
          
            this.configuration = configuration;
           this.sliderService = sliderService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Featured";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Featured";
            ViewBag.v3 = "Featured list";

            return View(await sliderService.GetAllAsync<ResultFeaturedDTO>(url));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeaturedDTO create)
        {

            if (await sliderService.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Featured/Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {

            if (await sliderService.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Featured/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return View(await sliderService.GetByIdAsync<UpdateFeaturedDTO>(url, id));

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeaturedDTO categoryDTO)
        {

            if (await sliderService.PutAsync(url, categoryDTO, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Featured/Index");
            }


            return View();

        }
    }
}

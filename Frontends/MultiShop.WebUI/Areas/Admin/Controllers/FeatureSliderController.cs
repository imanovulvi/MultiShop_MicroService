using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.FeatureSlider;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        string url = "";

        private readonly IFeatureSliderService sliderService;

        public FeatureSliderController(IConfiguration configuration,IFeatureSliderService sliderService)
        {
            url = configuration["ServiceUrl:Catalog:FeatureSlider"];
           
            this.sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {

            ViewBag.v0 = "FeatureSlider";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "FeatureSlider";
            ViewBag.v3 = "FeatureSlider list";
            return View(await  sliderService.GetAllAsync<ResultFeatureSliderDTO>(url));

          
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDTO create)
        {

            if (await sliderService.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/FeatureSlider/Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {

            if (await sliderService.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/FeatureSlider/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return View(await sliderService.GetByIdAsync<UpdateFeatureSliderDTO>(url, id));


        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureSliderDTO categoryDTO)
        {

            if (await sliderService.PutAsync(url, categoryDTO, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/FeatureSlider/Index");
            }

            return View();

        }



    }
}

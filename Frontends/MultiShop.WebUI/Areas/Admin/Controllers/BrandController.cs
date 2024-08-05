using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Brand;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly string url;
        private readonly IBrandService brandService;

        public BrandController(IConfiguration configuration, IBrandService brandService)
        {

            url = configuration["ServiceUrl:Catalog:Brand"];
            this.brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Brand";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Brand";
            ViewBag.v3 = "Brand list";

            return View(await brandService.GetAllAsync<ResultBrandDTO>(url));

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDTO create)
        {
            if (await brandService.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Brand/Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (await brandService.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Brand/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return View(await  brandService.GetByIdAsync<UpdateBrandDTO>(url, id));

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDTO brandDTO)
        {

            if (await brandService.PutAsync(url, brandDTO, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Brand/Index");
            }


            return View();

        }
    }
}

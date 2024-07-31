using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.About;
using MultiShop.WebUI.AppClasses.Abstractions;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;


namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly string url;
        private readonly IAboutService aboutService;

        public AboutController(IConfiguration configuration, IAboutService aboutService)
        {

            url = configuration["ServiceUrl:Catalog:About"];
        
            this.aboutService = aboutService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "About";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "About";
            ViewBag.v3 = "About list";

            return View(await aboutService.GetAllAsync<ResultAboutDTO>(url));

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDTO create)
        {
           
            if (await aboutService.PostAsync<CreateAboutDTO>(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/About/Index");
            }
            return View();


        }

        public async Task<IActionResult> Delete(string id)
        {
            if (await aboutService.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/About/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {

           var obj=await aboutService.GetByIdAsync<UpdateAboutDTO>(url, id);


            if (obj !=null)
            {
                return View(obj);
            }


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDTO aboutDTO)
        {

            if (await aboutService.PutAsync<UpdateAboutDTO>(url, aboutDTO,HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/About/Index");
            }

            return View();

        }
    }
}

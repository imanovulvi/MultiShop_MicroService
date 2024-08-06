using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Cargo;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Cargo;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoCompanyController : Controller
    {
        private readonly ICompanyService companyService;
        string urlCargoCompany = "";
        public CargoCompanyController(ICompanyService companyService,IConfiguration configuration)
        {
            this.companyService = companyService;
            urlCargoCompany = configuration["ServiceUrl:Cargo:Company"];
        }
        public async Task<IActionResult> Index()
        {

            return View(await companyService.GetAllAsync<ResultCompanyDTO>(urlCargoCompany));
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return View(await companyService.GetByIdAsync<ResultCompanyDTO>(urlCargoCompany,id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCompanyDTO request)
        {
           await  companyService.PutAsync(urlCargoCompany,request);
            return Redirect("/admin/CargoCompany/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await companyService.DeleteAsync(urlCargoCompany,id);
            return Redirect("/admin/CargoCompany/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyDTO request)
        {
            await companyService.PostAsync(urlCargoCompany, request);
            return Redirect("/admin/CargoCompany/Index");
        }
    }
}

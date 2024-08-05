using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MultiShop.DTOs.DTOs.Catalog.Category;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly string url;

        private readonly ICategoryService categoryService;

        public CategoryController(IConfiguration configuration,IHttpClientFactory httpClient, ICategoryService categoryService)
        {
          
            url = configuration["ServiceUrl:Catalog:Category"];
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
        
            ViewBag.v0 = "Category";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Category";
            ViewBag.v3 = "Category list";
            

            return View(await categoryService.GetAllAsync<ResultCategoryDTO>(url));

          
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO create)
        {


            if (await categoryService.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Category/Index");
            }
            return View();
        }

        public async  Task<IActionResult> Delete(string id)
        {

            if (await categoryService.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Category/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
          var list= await categoryService.GetByIdAsync<UpdateCategoryDTO>(url,id);

            if (list !=null)
            {
                return View(list);
            }


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDTO categoryDTO)
        {


            if (await categoryService.PutAsync(url, categoryDTO, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Category/Index");
            }


            return View();

        }

    }
}

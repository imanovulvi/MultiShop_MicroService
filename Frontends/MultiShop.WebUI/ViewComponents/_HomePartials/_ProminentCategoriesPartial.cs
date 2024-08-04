using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Category;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _ProminentCategoriesPartial : ViewComponent
    {
        private readonly ICategoryService categoryService;
        string url = "";
     
   

        public _ProminentCategoriesPartial(ICategoryService categoryService, IConfiguration configuration)
        {
    
            url = configuration["ServiceUrl:Catalog:Category"];
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await categoryService.GetAllAsync<ResultCategoryDTO>(url));

        }
    }
}

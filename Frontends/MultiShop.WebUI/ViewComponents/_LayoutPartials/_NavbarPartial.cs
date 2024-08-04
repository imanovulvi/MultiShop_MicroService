using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Category;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI._LayoutPartials.ViewComponents
{
    public class _NavbarPartial:ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly IFeatureSliderService featureSlider;
   
        string urlCategory = "";
       

        public _NavbarPartial(ICategoryService categoryService, IConfiguration configuration)
        {
           // url = configuration["ServiceUrl:Catalog:FeatureSlider"];
            urlCategory = configuration["ServiceUrl:Catalog:Category"];
            
            this.categoryService = categoryService;
           // this.featureSlider = featureSlider;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await categoryService.GetAllAsync<ResultCategoryDTO>(urlCategory));

         

        }
    }
}

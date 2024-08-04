using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.FeatureSlider;
using MultiShop.DTOs.DTOs.Catalog.SpecialOffer;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _CarouselPartial : ViewComponent
    {
        private readonly ISpecialOfferService specialOfferService;
        private readonly IFeatureSliderService featureSliderService;
        string urlFeatureSlider = "";
        string urlSpecialOffer = "";
        HttpClient httpClient;

        public _CarouselPartial(ISpecialOfferService specialOfferService,IFeatureSliderService featureSliderService, IConfiguration configuration)
        {
            urlFeatureSlider = configuration["ServiceUrl:Catalog:FeatureSlider"];
            urlSpecialOffer = configuration["ServiceUrl:Catalog:SpecialOffer"];
            this.specialOfferService = specialOfferService;
            this.featureSliderService = featureSliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var specialList= await specialOfferService.GetAllAsync<ResultSpecialOfferDTO>(urlSpecialOffer);

            if (specialList !=null)
                ViewBag.specialOffer = specialList;

          var featureList = await featureSliderService.GetAllAsync<ResultFeatureSliderDTO>(urlFeatureSlider);

           
            if (featureList !=null)
                return View(featureList);

            
            return View();

        }
    }
}

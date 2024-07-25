using AutoMapper;
using MultiShop.Catalog.DTOs.About;
using MultiShop.Catalog.DTOs.Brand;
using MultiShop.Catalog.DTOs.Category;
using MultiShop.Catalog.DTOs.DiscountOffer;
using MultiShop.Catalog.DTOs.Featured;
using MultiShop.Catalog.DTOs.FeatureSlider;
using MultiShop.Catalog.DTOs.Image;
using MultiShop.Catalog.DTOs.Product;
using MultiShop.Catalog.DTOs.ProductDetails;
using MultiShop.Catalog.DTOs.SpecialOffer;
using MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap(typeof(Product), typeof(CreateProductDTO)).ReverseMap();
            CreateMap(typeof(Product), typeof(GetByIdProductDTO)).ReverseMap();
            CreateMap(typeof(Product), typeof(ResultProductDTO)).ReverseMap();
            CreateMap(typeof(Product), typeof(UpdateProductDTO)).ReverseMap();


            CreateMap(typeof(Category), typeof(CreateCategoryDTO)).ReverseMap();
            CreateMap(typeof(Category), typeof(GetByIdCategoryDTO)).ReverseMap();
            CreateMap(typeof(Category), typeof(ResultCategoryDTO)).ReverseMap();
            CreateMap(typeof(Category), typeof(UpdateCategoryDTO)).ReverseMap();


            CreateMap(typeof(Image), typeof(CreateImageDTO)).ReverseMap();
            CreateMap(typeof(Image), typeof(GetByIdImageDTO)).ReverseMap();
            CreateMap(typeof(Image), typeof(ResultImageDTO)).ReverseMap();
            CreateMap(typeof(Image), typeof(UpdateImageDTO)).ReverseMap();


            CreateMap(typeof(ProductDetails), typeof(CreateProductDetailsDTO)).ReverseMap();
            CreateMap(typeof(ProductDetails), typeof(GetByIdProductDetailsDTO)).ReverseMap();
            CreateMap(typeof(ProductDetails), typeof(ResultProductDetailsDTO)).ReverseMap();
            CreateMap(typeof(ProductDetails), typeof(UpdateProductDetailsDTO)).ReverseMap();


            CreateMap(typeof(FeatureSlider), typeof(CreateFeatureSliderDTO)).ReverseMap();
            CreateMap(typeof(FeatureSlider), typeof(GetByIdFeatureSliderDTO)).ReverseMap();
            CreateMap(typeof(FeatureSlider), typeof(ResultFeatureSliderDTO)).ReverseMap();
            CreateMap(typeof(FeatureSlider), typeof(UpdateFeatureSliderDTO)).ReverseMap();

            CreateMap(typeof(SpecialOffer), typeof(CreateSpecialOfferDTO)).ReverseMap();
            CreateMap(typeof(SpecialOffer), typeof(GetByIdSpecialOfferDTO)).ReverseMap();
            CreateMap(typeof(SpecialOffer), typeof(ResultSpecialOfferDTO)).ReverseMap();
            CreateMap(typeof(SpecialOffer), typeof(UpdateSpecialOfferDTO)).ReverseMap();

            CreateMap(typeof(Featured), typeof(CreateFeaturedDTO)).ReverseMap();
            CreateMap(typeof(Featured), typeof(GetByIdFeaturedDTO)).ReverseMap();
            CreateMap(typeof(Featured), typeof(ResultFeaturedDTO)).ReverseMap();
            CreateMap(typeof(Featured), typeof(UpdateFeaturedDTO)).ReverseMap();


            CreateMap(typeof(DiscountOffer), typeof(CreateDiscountOfferDTO)).ReverseMap();
            CreateMap(typeof(DiscountOffer), typeof(GetByIdDiscountOfferDTO)).ReverseMap();
            CreateMap(typeof(DiscountOffer), typeof(ResultDiscountOfferDTO)).ReverseMap();
            CreateMap(typeof(DiscountOffer), typeof(UpdateDiscountOfferDTO)).ReverseMap();


            CreateMap(typeof(Brand), typeof(CreateBrandDTO)).ReverseMap();
            CreateMap(typeof(Brand), typeof(GetByIdBrandDTO)).ReverseMap();
            CreateMap(typeof(Brand), typeof(ResultBrandDTO)).ReverseMap();
            CreateMap(typeof(Brand), typeof(UpdateBrandDTO)).ReverseMap();


            CreateMap(typeof(About), typeof(CreateAboutDTO)).ReverseMap();
            CreateMap(typeof(About), typeof(GetByIdAboutDTO)).ReverseMap();
            CreateMap(typeof(About), typeof(ResultAboutDTO)).ReverseMap();
            CreateMap(typeof(About), typeof(UpdateAboutDTO)).ReverseMap();

        }
    }
}

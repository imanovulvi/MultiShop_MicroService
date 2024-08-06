using Microsoft.AspNetCore.Authentication.Cookies;
using MultiShop.WebUI.AppClasses.Abstractions;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Basket;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Cargo;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Comment;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Discount;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Identity;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Message;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Order;
using MultiShop.WebUI.AppClasses.Concretes;
using MultiShop.WebUI.AppClasses.Concretes.Services.Basket;
using MultiShop.WebUI.AppClasses.Concretes.Services.Cargo;
using MultiShop.WebUI.AppClasses.Concretes.Services.Catalog;
using MultiShop.WebUI.AppClasses.Concretes.Services.Comment;
using MultiShop.WebUI.AppClasses.Concretes.Services.Discount;
using MultiShop.WebUI.AppClasses.Concretes.Services.Identity;
using MultiShop.WebUI.AppClasses.Concretes.Services.Message;
using MultiShop.WebUI.AppClasses.Concretes.Services.Order;

namespace MultiShop.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped(typeof(ITokenService), typeof(TokenService)); 
            builder.Services.AddScoped(typeof(IAboutService), typeof(AboutService));  
            builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
            builder.Services.AddScoped(typeof(IProductDetailService), typeof(ProductDetailService));
            builder.Services.AddScoped(typeof(IImageService), typeof(ImageService));
            builder.Services.AddScoped(typeof(IBrandService), typeof(BrandService));
            builder.Services.AddScoped(typeof(IFeatureSliderService), typeof(FeatureSliderService));
            builder.Services.AddScoped(typeof(IFeaturedService), typeof(FeaturedService));
            builder.Services.AddScoped(typeof(IDiscountOfferService), typeof(DiscountOfferService));
            builder.Services.AddScoped(typeof(ISpecialOfferService), typeof(SpecialOfferService));
            builder.Services.AddScoped(typeof(ICommentService), typeof(CommentService));
            builder.Services.AddScoped(typeof(IContactService), typeof(ContactService));
            builder.Services.AddScoped(typeof(IBasketService), typeof(BasketService));
            builder.Services.AddScoped(typeof(IDiscountService), typeof(DiscountService));
            builder.Services.AddScoped(typeof(IAdressService), typeof(AdressService));
            builder.Services.AddScoped(typeof(IIdentityService), typeof(IdentityService));

            builder.Services.AddScoped(typeof(IOrderingService), typeof(OrderingService));     
            builder.Services.AddScoped(typeof(IMessageService), typeof(MessageService));
            builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));




            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {
                opt.Cookie.Name = "Auth";
                opt.LoginPath = "/Auth/Index";
               

            });

           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();



            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"
                );
            });

            app.Run();
        }
    }
}

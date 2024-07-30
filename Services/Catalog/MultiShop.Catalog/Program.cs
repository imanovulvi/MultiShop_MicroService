using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultiShop.Catalog.Services.About;
using MultiShop.Catalog.Services.Brand;
using MultiShop.Catalog.Services.Category;
using MultiShop.Catalog.Services.Contact;
using MultiShop.Catalog.Services.DiscountOffer;
using MultiShop.Catalog.Services.Featured;
using MultiShop.Catalog.Services.FeatureSlider;
using MultiShop.Catalog.Services.Image;
using MultiShop.Catalog.Services.Product;
using MultiShop.Catalog.Services.ProductDetails;
using MultiShop.Catalog.Services.SpecialOffer;
using MultiShop.Catalog.Settings;
using System.Reflection;


namespace MultiShop.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
            builder.Services.AddScoped(typeof(IImageService), typeof(ImageService));
            builder.Services.AddScoped(typeof(IProductDetailsService), typeof(ProductDetailsService));
            builder.Services.AddScoped(typeof(IFeatureSliderService), typeof(FeatureSliderService));

            builder.Services.AddScoped(typeof(IFeaturedService), typeof(FeaturedService));
            builder.Services.AddScoped(typeof(ISpecialOfferService), typeof(SpecialOfferService));
            builder.Services.AddScoped(typeof(IDiscountOfferService), typeof(DiscountOfferService));
            builder.Services.AddScoped(typeof(IBrandService), typeof(BrandService));
            builder.Services.AddScoped(typeof(IAboutService), typeof(AboutService));
            builder.Services.AddScoped(typeof(IContactService), typeof(ContactService));
       

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(configure => configure.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = builder.Configuration["JWT:audience"],
                ValidIssuer = builder.Configuration["JWT:issuer"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"])),
                LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) => expires != null ? expires > DateTime.UtcNow : false
            }
);

            builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection("MongoDBSettings"));

            builder.Services.AddScoped<IDataBaseSettings>(sp=>sp.GetRequiredService<IOptions<DataBaseSettings>>().Value);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

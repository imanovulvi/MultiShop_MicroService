using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using MultiShop.Identity.Models.Context;
using MultiShop.Identity.Models.Entitys;
using MultiShop.Identity.Services.Abstactions;
using MultiShop.Identity.Services.Concretes;

namespace MultiShop.Identity.Extensions
{
    public static class Registartions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<AppIdentityDBContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultSqlCon")));
            _ = services.AddIdentityCore<AppUser>(x =>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
                
            }
             ).AddRoles<AppRole>().AddEntityFrameworkStores<AppIdentityDBContext>();


            services.AddScoped(typeof(ITokenService), typeof(TokenService));

            return services;
        }
    }
}

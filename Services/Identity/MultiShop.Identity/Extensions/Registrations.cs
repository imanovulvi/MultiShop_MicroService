using Microsoft.EntityFrameworkCore;
using MultiShop.Identity.Models.Context;
using MultiShop.Identity.Models.Entitys;
using System.Data;
using System;
using Microsoft.AspNetCore.Identity;

namespace MultiShop.Identity.Extensions
{
    public static class Registrations
    {
        public static IServiceCollection AddServices(this IServiceCollection services ,IConfiguration configuration) {

            services.AddDbContext<AppIdentityDBContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultSqlCon")));

            services.AddIdentityCore<AppUser>(x =>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
            }
            ).AddEntityFrameworkStores<AppIdentityDBContext>();


            return services;
        }
    }
}

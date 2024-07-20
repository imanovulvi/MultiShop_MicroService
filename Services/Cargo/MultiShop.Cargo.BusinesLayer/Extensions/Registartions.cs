using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinesLayer.Abstractions;
using MultiShop.Cargo.BusinesLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinesLayer.Extensions
{
    public static class Registartions
    {
        public static IServiceCollection AddBunsiesServices(this IServiceCollection services) 
        {
            services.AddScoped(typeof(ICargoDetailService), typeof(CargoDetailManager));
            services.AddScoped(typeof(ICargoOperationService), typeof(CargoOperationManager));
            services.AddScoped(typeof(ICompanyService), typeof(CompanyManager));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerManager));
           
            return services;
        }
    }
}

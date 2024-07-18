using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Repository;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Extensions
{
    public static class Registrations
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<OrderDBContext>(x => x.UseSqlServer(configuration.GetConnectionString("OrderSqlConnection")));

            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            return services;
        }
    }
}

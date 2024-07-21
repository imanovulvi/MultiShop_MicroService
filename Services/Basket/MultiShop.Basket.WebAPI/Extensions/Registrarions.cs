using Microsoft.Extensions.DependencyInjection;
using MultiShop.Basket.WebAPI.AppClasses.Abstarctions;
using MultiShop.Basket.WebAPI.AppClasses.Concrets;
using StackExchange.Redis;

namespace MultiShop.Basket.WebAPI.Extensions
{
    public static class Registrarions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration["RedisSettings:connectionString"]));
            services.AddScoped(typeof(IRedisService),typeof(RedisService));

            return services;

        }

    }
}

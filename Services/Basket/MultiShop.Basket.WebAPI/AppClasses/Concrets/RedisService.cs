using Microsoft.AspNetCore.Authorization;
using MultiShop.Basket.WebAPI.AppClasses.Abstarctions;
using MultiShop.Basket.WebAPI.DTOs;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace MultiShop.Basket.WebAPI.AppClasses.Concrets
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        IDatabase db;
        public RedisService(IConnectionMultiplexer connectionMultiplexer,IConfiguration configuration)
        {
            this.connectionMultiplexer = connectionMultiplexer;

            db = connectionMultiplexer.GetDatabase(Convert.ToInt32(configuration["RedisSettings:DB"]));

        }

        public async Task<bool> DeleteAsync(string key)
        {
           
            return await db.KeyDeleteAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
         
            return JsonConvert.DeserializeObject<T>(await db.StringGetAsync(key));
        }

        public async Task<bool> SetAsync<T>(string key, T value)
        {

            return await db.StringSetAsync(key, JsonConvert.SerializeObject(value));
        }
    }
}

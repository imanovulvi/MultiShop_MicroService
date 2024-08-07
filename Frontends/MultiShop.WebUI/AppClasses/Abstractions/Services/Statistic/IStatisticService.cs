using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Statistic
{
    public interface IStatisticService
    {
        Task<long> CategoryCountAsync(string header=null);
        Task<long> BrandCountAsync(string header=null);
        Task<long> ProductCountAsync(string header=null);
        Task<string> MaxPriceProductNameAsync(string header=null);
        Task<string> MinPriceProductNameAsync(string header=null);

    }
}

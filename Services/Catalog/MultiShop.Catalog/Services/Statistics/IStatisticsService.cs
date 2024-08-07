namespace MultiShop.Catalog.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<long> CategoryCountAsync();
        Task<long> BrandCountAsync();
        Task<long> ProductCountAsync();
        Task<string> MaxPriceProductNameAsync();
        Task<string> MinPriceProductNameAsync();
    }
}

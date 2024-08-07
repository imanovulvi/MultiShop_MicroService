using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Statistics
{
    public class StatisticsService:IStatisticsService
    {

        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Brand> brands;
        private readonly IMongoCollection<ET.Product> products;
        private readonly IMongoCollection<ET.Category> categories;

        public StatisticsService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);

            this.categories = database.GetCollection<ET.Category>(settings.CategoryCollectionsName);
            this.products = database.GetCollection<ET.Product>(settings.ProductCollectionsName);
            this.brands = database.GetCollection<ET.Brand>(settings.BrandCollectionsName);
            this.mapper = mapper;
        }


        public async Task<long> CategoryCountAsync()
        {

            return await categories.CountDocumentsAsync(FilterDefinition<ET.Category>.Empty);
        }
        public async Task<long> BrandCountAsync()
        {
            return await brands.CountDocumentsAsync(FilterDefinition<ET.Brand>.Empty);
        }
        public async Task<long> ProductCountAsync()
        {

            return await products.CountDocumentsAsync(FilterDefinition<ET.Product>.Empty);
        }

        public async Task<string> MaxPriceProductNameAsync()
        {
         
            var sort=Builders<ET.Product>.Sort.Descending(x=>x.Price);
         //todo Mongodb de siralamaya baxmaq productu price sine gore  duzgun siralamir
           var maxProduct= await products.Find(x=>true).Sort(sort).FirstOrDefaultAsync();
            return maxProduct.Name;

        }

        public async Task<string> MinPriceProductNameAsync()
        {
            var sort = Builders<ET.Product>.Sort.Ascending(x => x.Price);
            //todo Mongodb de siralamaya baxmaq productu price sine gore  duzgun siralamir
            var minProduct = await products.Find(x => true).Sort(sort).FirstOrDefaultAsync();
            return minProduct.Name;
        }
    }
}

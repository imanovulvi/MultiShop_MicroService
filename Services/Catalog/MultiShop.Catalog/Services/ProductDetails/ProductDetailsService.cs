using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDetails;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.ProductDetails
{
    public class ProductDetailsService:IProductDetailsService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.ProductDetails> categories;

        public ProductDetailsService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.categories = database.GetCollection<ET.ProductDetails>(settings.ProductDetailsCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDetailsDTO ProductDetailsDTO)
        {
            await categories.InsertOneAsync(mapper.Map<ET.ProductDetails>(ProductDetailsDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await categories.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDetailsDTO>> GetAllAsync()
        {
            var ProductDetails = await categories.FindAsync(x => true);

            return mapper.Map<List<ResultProductDetailsDTO>>(await ProductDetails.ToListAsync());
        }

        public async Task<GetByIdProductDetailsDTO> GetByIdAsync(string id)
        {
            var ProductDetails = await categories.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdProductDetailsDTO>(await ProductDetails.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateProductDetailsDTO ProductDetailsDTO)
        {

            await categories.FindOneAndReplaceAsync(x => x.Id == ProductDetailsDTO.Id, mapper.Map<ET.ProductDetails>(ProductDetailsDTO));
        }
    }
}

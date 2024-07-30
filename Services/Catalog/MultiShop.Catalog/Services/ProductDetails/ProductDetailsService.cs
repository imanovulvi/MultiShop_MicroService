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
        private readonly IMongoCollection<ET.ProductDetails> productDetail;

        public ProductDetailsService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.productDetail = database.GetCollection<ET.ProductDetails>(settings.ProductDetailsCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDetailsDTO ProductDetailsDTO)
        {
            await productDetail.InsertOneAsync(mapper.Map<ET.ProductDetails>(ProductDetailsDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await productDetail.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDetailsDTO>> GetAllAsync()
        {
            var ProductDetails = await productDetail.FindAsync(x => true);

            return mapper.Map<List<ResultProductDetailsDTO>>(await ProductDetails.ToListAsync());
        }

        public async Task<GetByIdProductDetailsDTO> GetByIdAsync(string id)
        {
            var ProductDetails = await productDetail.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdProductDetailsDTO>(await ProductDetails.FirstOrDefaultAsync());
        }

        public async Task<GetByIdProductDetailsDTO> GetDetailProductByIdAsync(string productId)
        {
            var ProductDetails = await productDetail.FindAsync(x => x.ProductId == productId);
            return mapper.Map<GetByIdProductDetailsDTO>(await ProductDetails.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateProductDetailsDTO ProductDetailsDTO)
        {

            await productDetail.FindOneAndReplaceAsync(x => x.Id == ProductDetailsDTO.Id, mapper.Map<ET.ProductDetails>(ProductDetailsDTO));
        }
    }
}

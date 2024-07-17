using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.Product;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Product
{
    public class ProductService:IProductService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Product> categories;

        public ProductService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.categories = database.GetCollection<ET.Product>(settings.ProductCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDTO ProductDTO)
        {
            await categories.InsertOneAsync(mapper.Map<ET.Product>(ProductDTO));
        }

        public async Task Delete(string id)
        {
            await categories.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDTO>> GetAllAsync()
        {
            var Product = await categories.FindAsync(x => true);

            return mapper.Map<List<ResultProductDTO>>(await Product.ToListAsync());
        }

        public async Task<GetByIdProductDTO> GetByIdAsync(string id)
        {
            var Product = await categories.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdProductDTO>(await Product.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateProductDTO ProductDTO)
        {

            await categories.FindOneAndReplaceAsync(x => x.Id == ProductDTO.Id, mapper.Map<ET.Product>(ProductDTO));
        }
    }
}

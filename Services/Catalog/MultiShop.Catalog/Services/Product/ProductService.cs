using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.Category;
using MultiShop.Catalog.DTOs.Product;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Product
{
    public class ProductService:IProductService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Product> products;
        private readonly IMongoCollection<ET.Category> categories;

        public ProductService(IMapper mapper, IDataBaseSettings settings)
        {
            
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.products = database.GetCollection<ET.Product>(settings.ProductCollectionsName);

           this.categories= database.GetCollection<ET.Category>(settings.CategoryCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDTO ProductDTO)
        {
            await products.InsertOneAsync(mapper.Map<ET.Product>(ProductDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await products.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDTO>> GetAllAsync()
        {
            var _products = await products.FindAsync(x => true);
            var productList = mapper.Map<List<ResultProductDTO>>(_products.ToList());

            var _categoryes = await categories.FindAsync(x => true);

             var categoryList=mapper.Map<List<ResultCategoryDTO>>(_categoryes.ToList());
            foreach (var item in productList)
            {
                item.Category = categoryList.FirstOrDefault(x => x.Id == item.CategoryId).Name;
            }

            return productList;


        }

        public async Task<GetByIdProductDTO> GetByIdAsync(string id)
        {
            var _products = await products.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdProductDTO>(await _products.FirstOrDefaultAsync());
        }

        public async Task<List<ResultProductDTO>> ProductCategoryByIdAsync(string categoryId)
        {
            var _products = await products.FindAsync(x => x.CategoryId==categoryId);
            var productList = mapper.Map<List<ResultProductDTO>>(_products.ToList());
            var _categoryes = await categories.FindAsync(x => true);

            var categoryList = mapper.Map<List<ResultCategoryDTO>>(_categoryes.ToList());
            foreach (var item in productList)
            {
                item.Category = categoryList.FirstOrDefault(x => x.Id == item.CategoryId).Name;
            }


            return productList;
        }

     

        public async Task UpdateAsync(UpdateProductDTO ProductDTO)
        {

            await products.FindOneAndReplaceAsync(x => x.Id == ProductDTO.Id, mapper.Map<ET.Product>(ProductDTO));
        }
    }
}

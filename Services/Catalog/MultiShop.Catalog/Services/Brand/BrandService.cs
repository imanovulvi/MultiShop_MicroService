using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.Brand;
using MultiShop.Catalog.Entitys;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Brand
{
    public class BrandService:IBrandService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Brand> brands;

        public BrandService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.brands = database.GetCollection<ET.Brand>(settings.BrandCollectionsName);
            this.mapper = mapper;
        }
       
        public async Task CreateAsync(CreateBrandDTO brandDTO)
        {
            await brands.InsertOneAsync(mapper.Map<ET.Brand>(brandDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await brands.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultBrandDTO>> GetAllAsync()
        {
            var brand = await brands.FindAsync(x => true);

            return mapper.Map<List<ResultBrandDTO>>(await brand.ToListAsync());
        }

        public async Task<GetByIdBrandDTO> GetByIdAsync(string id)
        {
            var brand = await brands.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdBrandDTO>(await brand.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateBrandDTO brandDTO)
        {

            await brands.FindOneAndReplaceAsync(x => x.Id == brandDTO.Id, mapper.Map<ET.Brand>(brandDTO));
        }
    }
}

using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.Featured;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Featured
{
    public class FeaturedService:IFeaturedService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Featured> categories;

        public FeaturedService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.categories = database.GetCollection<ET.Featured>(settings.FeaturedCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateFeaturedDTO FeaturedDTO)
        {
            await categories.InsertOneAsync(mapper.Map<ET.Featured>(FeaturedDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await categories.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultFeaturedDTO>> GetAllAsync()
        {
            var Featured = await categories.FindAsync(x => true);

            return mapper.Map<List<ResultFeaturedDTO>>(await Featured.ToListAsync());
        }

        public async Task<GetByIdFeaturedDTO> GetByIdAsync(string id)
        {
            var Featured = await categories.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdFeaturedDTO>(await Featured.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateFeaturedDTO FeaturedDTO)
        {

            await categories.FindOneAndReplaceAsync(x => x.Id == FeaturedDTO.Id, mapper.Map<ET.Featured>(FeaturedDTO));
        }
    }
}

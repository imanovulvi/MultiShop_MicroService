using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.About;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;


namespace MultiShop.Catalog.Services.About
{
    public class AboutService:IAboutService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.About> Abouts;

        public AboutService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.Abouts = database.GetCollection<ET.About>(settings.AboutCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateAboutDTO AboutDTO)
        {
            await Abouts.InsertOneAsync(mapper.Map<ET.About>(AboutDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await Abouts.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultAboutDTO>> GetAllAsync()
        {
            var About = await Abouts.FindAsync(x => true);

            return mapper.Map<List<ResultAboutDTO>>(await About.ToListAsync());
        }

        public async Task<GetByIdAboutDTO> GetByIdAsync(string id)
        {
            var About = await Abouts.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdAboutDTO>(await About.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateAboutDTO AboutDTO)
        {

            await Abouts.FindOneAndReplaceAsync(x => x.Id == AboutDTO.Id, mapper.Map<ET.About>(AboutDTO));
        }
    }
}

using MongoDB.Driver;
using MultiShop.Catalog.DTOs.FeatureSlider;
using ET=MultiShop.Catalog.Entitys;
using MultiShop.Catalog.Settings;
using AutoMapper;
using MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.FeatureSlider
{
    public class FeatureSliderService : IFeatureSliderService
    {

        private readonly IMongoCollection<ET.FeatureSlider> mongoCollection;
        private readonly IMapper mapper;

        public FeatureSliderService(IDataBaseSettings dataBaseSettings,IMapper mapper)
        {

            var client = new MongoClient(dataBaseSettings.ConnectionString);
            IMongoDatabase db=client.GetDatabase(dataBaseSettings.DataBaseName);
            mongoCollection =  db.GetCollection<ET.FeatureSlider>(dataBaseSettings.FeatureSlidersCollectionsName);
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateFeatureSliderDTO FeatureSliderDTO)
        {

           await  mongoCollection.InsertOneAsync(mapper.Map<ET.FeatureSlider>(FeatureSliderDTO));
        }

        public async Task DeleteAsync(string id)
        {

           await  mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultFeatureSliderDTO>> GetAllAsync()
        {
            var featureSliders=await mongoCollection.FindAsync(x => true);
          return mapper.Map<List<ResultFeatureSliderDTO>>(await featureSliders.ToListAsync());
        }

        public async Task<GetByIdFeatureSliderDTO> GetByIdAsync(string id)
        {
            var featureSlider = await mongoCollection.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdFeatureSliderDTO>(await featureSlider.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateFeatureSliderDTO FeatureSliderDTO)
        {

            await mongoCollection.FindOneAndReplaceAsync(x => x.Id == FeatureSliderDTO.Id, mapper.Map<ET.FeatureSlider>(FeatureSliderDTO));
        }
    }
}

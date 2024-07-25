using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.DiscountOffer;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.DiscountOffer
{
    public class DiscountOfferService:IDiscountOfferService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.DiscountOffer> categories;

        public DiscountOfferService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.categories = database.GetCollection<ET.DiscountOffer>(settings.DiscountOfferCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateDiscountOfferDTO DiscountOfferDTO)
        {
            await categories.InsertOneAsync(mapper.Map<ET.DiscountOffer>(DiscountOfferDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await categories.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultDiscountOfferDTO>> GetAllAsync()
        {
            var DiscountOffer = await categories.FindAsync(x => true);

            return mapper.Map<List<ResultDiscountOfferDTO>>(await DiscountOffer.ToListAsync());
        }

        public async Task<GetByIdDiscountOfferDTO> GetByIdAsync(string id)
        {
            var DiscountOffer = await categories.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdDiscountOfferDTO>(await DiscountOffer.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateDiscountOfferDTO DiscountOfferDTO)
        {

            await categories.FindOneAndReplaceAsync(x => x.Id == DiscountOfferDTO.Id, mapper.Map<ET.DiscountOffer>(DiscountOfferDTO));
        }
    }
}

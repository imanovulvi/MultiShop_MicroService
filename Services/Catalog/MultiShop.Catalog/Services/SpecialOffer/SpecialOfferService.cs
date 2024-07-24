using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.SpecialOffer;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.SpecialOffer
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.SpecialOffer> specialOffer;

        public SpecialOfferService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.specialOffer = database.GetCollection<ET.SpecialOffer>(settings.SpecialOfferCollectionsName);
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateSpecialOfferDTO specialOfferDTO)
        {

            await specialOffer.InsertOneAsync(mapper.Map<ET.SpecialOffer>(specialOfferDTO));
        }


        public async Task DeleteAsync(string id)
        {
            await specialOffer.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultSpecialOfferDTO>> GetAllAsync()
        {
            var SpecialOffer = await specialOffer.FindAsync(x => true);

            return mapper.Map<List<ResultSpecialOfferDTO>>(await SpecialOffer.ToListAsync());
        }

        public async Task<GetByIdSpecialOfferDTO> GetByIdAsync(string id)
        {
            var SpecialOffer = await specialOffer.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdSpecialOfferDTO>(await SpecialOffer.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateSpecialOfferDTO SpecialOfferDTO)
        {

            await specialOffer.FindOneAndReplaceAsync(x => x.Id == SpecialOfferDTO.Id, mapper.Map<ET.SpecialOffer>(SpecialOfferDTO));
        }
    }
}

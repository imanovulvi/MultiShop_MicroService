using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.Contact;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Contact
{
    public class ContactService:IContactService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Contact> contact;

        public ContactService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.contact = database.GetCollection<ET.Contact>(settings.ContactCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateContactDTO contactDTO)
        {
            await contact.InsertOneAsync(mapper.Map<ET.Contact>(contactDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await contact.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultContactDTO>> GetAllAsync()
        {
            var _contact = await contact.FindAsync(x => true);

            return mapper.Map<List<ResultContactDTO>>(await _contact.ToListAsync());
        }

        public async Task<GetByIdContactDTO> GetByIdAsync(string id)
        {
            var Contact = await contact.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdContactDTO>(await Contact.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateContactDTO contactDTO)
        {

            await contact.FindOneAndReplaceAsync(x => x.Id == contactDTO.Id, mapper.Map<ET.Contact>(contactDTO));
        }
    }
}

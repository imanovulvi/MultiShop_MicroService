using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.Image;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Image
{
    public class ImageService:IImageService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Image> categories;

        public ImageService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.categories = database.GetCollection<ET.Image>(settings.ImageCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateImageDTO ImageDTO)
        {
            await categories.InsertOneAsync(mapper.Map<ET.Image>(ImageDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await categories.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultImageDTO>> GetAllAsync()
        {
            var Image = await categories.FindAsync(x => true);

            return mapper.Map<List<ResultImageDTO>>(await Image.ToListAsync());
        }

        public async Task<GetByIdImageDTO> GetByIdAsync(string id)
        {
            var Image = await categories.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdImageDTO>(await Image.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateImageDTO ImageDTO)
        {

            await categories.FindOneAndReplaceAsync(x => x.Id == ImageDTO.Id, mapper.Map<ET.Image>(ImageDTO));
        }
    }
}

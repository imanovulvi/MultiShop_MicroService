using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.AppClasses;
using MultiShop.Catalog.DTOs.Image;
using MultiShop.Catalog.Entitys;
using MultiShop.Catalog.Settings;
using ET = MultiShop.Catalog.Entitys;

namespace MultiShop.Catalog.Services.Image
{
    public class ImageService:IImageService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Image> images;

        public ImageService(IMapper mapper, IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.images = database.GetCollection<ET.Image>(settings.ImageCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(string productId, IFormFileCollection formCollection)
        {
           List<string> l=await FileService.UploadAsync(formCollection, "images\\product");

            foreach (var item in l)
            {
                CreateImageDTO createImageDTO = new CreateImageDTO() { 
                ImageUrl=item,
                Base64=FileService.ConvertBase64(item,""),
                ProductId=productId
                };
                await images.InsertOneAsync(mapper.Map<ET.Image>(createImageDTO));
            }

       
        }

        public async Task DeleteAsync(string id)
        {
            await images.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultImageDTO>> GetAllAsync()
        {
            var image = await images.FindAsync(x => true);

            return mapper.Map<List<ResultImageDTO>>(await image.ToListAsync());
        }

        public async Task<GetByIdImageDTO> GetByIdAsync(string id)
        {
            var image = await images.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdImageDTO>(await image.FirstOrDefaultAsync());
        }

        public async Task<List<ResultImageDTO>> GetImagesProductById(string productId)
        {
            var image = await images.FindAsync(x => x.ProductId == productId);
            return mapper.Map<List<ResultImageDTO>>(await image.ToListAsync());
        }

        public async Task UpdateAsync(UpdateImageDTO imageDTO)
        {

            await images.FindOneAndReplaceAsync(x => x.Id == imageDTO.Id, mapper.Map<ET.Image>(imageDTO));
        }
    }
}

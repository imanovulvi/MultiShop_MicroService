using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.Category;
using ET=MultiShop.Catalog.Entitys;
using MultiShop.Catalog.Settings;


namespace MultiShop.Catalog.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ET.Category> categories;

        public CategoryService(IMapper mapper,IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            this.categories=database.GetCollection<ET.Category>(settings.CategoryCollectionsName);
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateCategoryDTO categoryDTO)
        {
           await categories.InsertOneAsync(mapper.Map<ET.Category>(categoryDTO));
        }

        public async Task DeleteAsync(string id)
        {
          await  categories.DeleteOneAsync(x=>x.Id==id);
        }

        public async Task<List<ResultCategoryDTO>> GetAllAsync()
        {
            var category = await categories.FindAsync(x => true);
 
           return   mapper.Map<List<ResultCategoryDTO>>(await category.ToListAsync());
        }

        public async Task<GetByIdCategoryDTO> GetByIdAsync(string id)
        {
            var category = await categories.FindAsync(x => x.Id == id);
            return mapper.Map<GetByIdCategoryDTO>(await category.FirstOrDefaultAsync());
        }

        public async Task UpdateAsync(UpdateCategoryDTO categoryDTO)
        {

          await  categories.FindOneAndReplaceAsync(x => x.Id == categoryDTO.Id, mapper.Map<ET.Category>(categoryDTO));
        }
    }
}

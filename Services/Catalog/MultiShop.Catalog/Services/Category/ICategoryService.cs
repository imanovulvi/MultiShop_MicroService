using MultiShop.Catalog.DTOs.Category;

namespace MultiShop.Catalog.Services.Category
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDTO>> GetAllAsync();
        Task CreateAsync(CreateCategoryDTO categoryDTO);
        Task UpdateAsync(UpdateCategoryDTO categoryDTO);
        Task Delete(string id);
        Task<GetByIdCategoryDTO> GetByIdAsync(string id);
    }
}

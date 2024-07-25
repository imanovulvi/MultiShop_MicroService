using MultiShop.Catalog.DTOs.Featured;

namespace MultiShop.Catalog.Services.Featured
{
    public interface IFeaturedService
    {
        Task<List<ResultFeaturedDTO>> GetAllAsync();
        Task CreateAsync(CreateFeaturedDTO categoryDTO);
        Task UpdateAsync(UpdateFeaturedDTO categoryDTO);
        Task DeleteAsync(string id);
        Task<GetByIdFeaturedDTO> GetByIdAsync(string id);
    }
}

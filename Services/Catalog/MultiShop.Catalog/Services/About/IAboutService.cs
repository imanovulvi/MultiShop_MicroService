using MultiShop.Catalog.DTOs.About;

namespace MultiShop.Catalog.Services.About
{
    public interface IAboutService
    {
        Task<List<ResultAboutDTO>> GetAllAsync();
        Task CreateAsync(CreateAboutDTO AboutDTO);
        Task UpdateAsync(UpdateAboutDTO AboutDTO);
        Task DeleteAsync(string id);
        Task<GetByIdAboutDTO> GetByIdAsync(string id);
    }
}

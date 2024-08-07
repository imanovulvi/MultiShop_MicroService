using MultiShop.Catalog.DTOs.Brand;

namespace MultiShop.Catalog.Services.Brand
{
    public interface IBrandService
    {
        Task<List<ResultBrandDTO>> GetAllAsync();
        Task CreateAsync(CreateBrandDTO BrandDTO);
        Task UpdateAsync(UpdateBrandDTO BrandDTO);
        Task DeleteAsync(string id);
        Task<GetByIdBrandDTO> GetByIdAsync(string id);

  
    }
}

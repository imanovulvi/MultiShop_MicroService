using MultiShop.Catalog.DTOs.Product;

namespace MultiShop.Catalog.Services.Product
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllAsync();
        Task CreateAsync(CreateProductDTO ProductDTO);
        Task UpdateAsync(UpdateProductDTO ProductDTO);
        Task DeleteAsync(string id);
        Task<GetByIdProductDTO> GetByIdAsync(string id);
    }
}

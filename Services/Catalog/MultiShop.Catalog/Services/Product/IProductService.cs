using MultiShop.Catalog.DTOs.Product;

namespace MultiShop.Catalog.Services.Product
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllAsync();
        Task CreateAsync(CreateProductDTO ProductDTO);
        Task UpdateAsync(UpdateProductDTO ProductDTO);
        Task Delete(string id);
        Task<GetByIdProductDTO> GetByIdAsync(string id);
    }
}

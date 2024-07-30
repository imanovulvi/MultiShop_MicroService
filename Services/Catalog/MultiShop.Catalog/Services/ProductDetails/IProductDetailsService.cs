using MultiShop.Catalog.DTOs.ProductDetails;

namespace MultiShop.Catalog.Services.ProductDetails
{
    public interface IProductDetailsService
    {
        Task<List<ResultProductDetailsDTO>> GetAllAsync();
        Task CreateAsync(CreateProductDetailsDTO ProductDetailsDTO);
        Task UpdateAsync(UpdateProductDetailsDTO ProductDetailsDTO);
        Task DeleteAsync(string id);
        Task<GetByIdProductDetailsDTO> GetByIdAsync(string id);
        Task<GetByIdProductDetailsDTO> GetDetailProductByIdAsync(string id);
    }
}

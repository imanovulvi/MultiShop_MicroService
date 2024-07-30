using MultiShop.Catalog.DTOs.Image;

namespace MultiShop.Catalog.Services.Image
{
    public interface IImageService
    {
        Task<List<ResultImageDTO>> GetAllAsync();
        Task CreateAsync(string productId, IFormFileCollection formCollection);
        Task UpdateAsync(UpdateImageDTO ImageDTO);
        Task DeleteAsync(string id);
        Task<GetByIdImageDTO> GetByIdAsync(string id);

        Task<List<ResultImageDTO>> GetImagesProductById(string id);
    }
}

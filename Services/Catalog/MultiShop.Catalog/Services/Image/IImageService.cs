using MultiShop.Catalog.DTOs.Image;

namespace MultiShop.Catalog.Services.Image
{
    public interface IImageService
    {
        Task<List<ResultImageDTO>> GetAllAsync();
        Task CreateAsync(CreateImageDTO ImageDTO);
        Task UpdateAsync(UpdateImageDTO ImageDTO);
        Task Delete(string id);
        Task<GetByIdImageDTO> GetByIdAsync(string id);
    }
}

using MultiShop.Catalog.DTOs.FeatureSlider;

namespace MultiShop.Catalog.Services.FeatureSlider
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDTO>> GetAllAsync();
        Task CreateAsync(CreateFeatureSliderDTO FeatureSliderDTO);
        Task UpdateAsync(UpdateFeatureSliderDTO FeatureSliderDTO);
        Task DeleteAsync(string id);
        Task<GetByIdFeatureSliderDTO> GetByIdAsync(string id);
    }
}

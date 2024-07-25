using MultiShop.Catalog.DTOs.DiscountOffer;

namespace MultiShop.Catalog.Services.DiscountOffer
{
    public interface IDiscountOfferService
    {
        Task<List<ResultDiscountOfferDTO>> GetAllAsync();
        Task CreateAsync(CreateDiscountOfferDTO categoryDTO);
        Task UpdateAsync(UpdateDiscountOfferDTO categoryDTO);
        Task DeleteAsync(string id);
        Task<GetByIdDiscountOfferDTO> GetByIdAsync(string id);
    }
}

using MultiShop.Catalog.DTOs.SpecialOffer;

namespace MultiShop.Catalog.Services.SpecialOffer
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDTO>> GetAllAsync();
        Task CreateAsync(CreateSpecialOfferDTO SpecialOfferDTO);
        Task UpdateAsync(UpdateSpecialOfferDTO SpecialOfferDTO);
        Task DeleteAsync(string id);
        Task<GetByIdSpecialOfferDTO> GetByIdAsync(string id);
    }
}

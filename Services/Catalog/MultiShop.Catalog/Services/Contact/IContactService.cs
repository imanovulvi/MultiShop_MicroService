using MultiShop.Catalog.DTOs.Contact;

namespace MultiShop.Catalog.Services.Contact
{
    public interface IContactService
    {
        Task<List<ResultContactDTO>> GetAllAsync();
        Task CreateAsync(CreateContactDTO contactDTO);
        Task UpdateAsync(UpdateContactDTO contactDTO);
        Task DeleteAsync(string id);
        Task<GetByIdContactDTO> GetByIdAsync(string id);
    }
}

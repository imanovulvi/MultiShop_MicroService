using MultiShop.DTOs.DTOs.Message;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Message
{
    public interface IMessageService:IHttpClientService
    {
        Task<List<ResultMessageDTO>> GetInboxMessageAsync(string id, string url, string header);
        Task<List<ResultMessageDTO>> GetSenderMessageAsync(string id, string url, string header);
    }
}

using ET=MultiShop.Message.DataAccess.Entityes;
using MultiShop.Message.Repositorys;

namespace MultiShop.Message.Services.Abstractions
{
    public interface IMessageServices:IRepository<ET.Message>
    {
        Task<List<ET.Message>> GetInboxMessageAsync(string id);
        Task<List<ET.Message>> GetSenderMessageAsync(string id);
    }
}

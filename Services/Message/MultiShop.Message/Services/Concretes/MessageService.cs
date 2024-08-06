using ET=MultiShop.Message.DataAccess.Entityes;
using MultiShop.Message.Repositorys;
using MultiShop.Message.Services.Abstractions;
using MultiShop.Message.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MultiShop.Message.Services.Concretes
{
    public class MessageService : Repository<ET.Message>, IMessageServices
    {

        public MessageService(MessagesContext context) : base(context)
        {
            
        }

        public async Task<List<ET.Message>> GetInboxMessageAsync(string id)
        {
           return await Table.Where(x=>x.ReceiverId==id).ToListAsync();
        }

        public async Task<List<ET.Message>> GetSenderMessageAsync(string id)
        {
            return await Table.Where(x => x.SenderId == id).ToListAsync();
        }
    }
}

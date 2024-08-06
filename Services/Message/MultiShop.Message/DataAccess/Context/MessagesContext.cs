using Microsoft.EntityFrameworkCore;
using ET=MultiShop.Message.DataAccess.Entityes;

namespace MultiShop.Message.DataAccess.Context
{
    public class MessagesContext:DbContext
    {
        public MessagesContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<ET.Message> Messages { get; set; }
    }
}

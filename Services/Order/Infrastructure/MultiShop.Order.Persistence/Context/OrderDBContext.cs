using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiShop.Order.Domain.Entitys;


namespace MultiShop.Order.Persistence.Context
{
    public class OrderDBContext:DbContext
    {
        public OrderDBContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Adress> Adreses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
       
    }
}

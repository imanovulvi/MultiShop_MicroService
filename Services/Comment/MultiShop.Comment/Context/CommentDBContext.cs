using Microsoft.EntityFrameworkCore;
using ET=MultiShop.Comment.Entitys;

namespace MultiShop.Comment.Context
{
    public class CommentDBContext:DbContext
    {
        public CommentDBContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<ET.Comment> Comments { get; set; }
    }
}

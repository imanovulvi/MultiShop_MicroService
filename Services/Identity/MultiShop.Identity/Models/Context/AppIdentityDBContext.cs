using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiShop.Identity.Models.Entitys;
using System.Reflection;

namespace MultiShop.Identity.Models.Context
{
    public class AppIdentityDBContext:IdentityDbContext<AppUser,AppRole,Guid>
    {
      
        public AppIdentityDBContext(DbContextOptions options):base(options)
        {
            
        }
        
    }
}


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiShop.Identity.Models.Entitys;
using System.Data;

namespace MultiShop.Identity.Models.Context
{
    public class AppIdentityDBContext: IdentityDbContext<AppUser, AppRole, Guid>
    {
        private readonly IConfiguration configuration;

        public AppIdentityDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultSqlCon"));

        }
     
    }
}

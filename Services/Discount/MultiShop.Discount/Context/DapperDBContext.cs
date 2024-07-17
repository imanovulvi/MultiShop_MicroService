using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using ET=MultiShop.Discount.Entitys;

namespace MultiShop.Discount.Context
{
    public class DapperDBContext:DbContext
    {
        private readonly IConfiguration configuration;

        public DapperDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<ET.Discount> Discounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlConStr"));

        }

        public IDbConnection CreateConnection() => new SqlConnection(configuration.GetConnectionString("SqlConStr"));
    }
}

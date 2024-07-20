using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntitysLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concretes.Context
{
    public class CargoDBContext:DbContext
    {
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers{ get; set; }

        public CargoDBContext(DbContextOptions options):base(options)
        {
            
        }


    }
}

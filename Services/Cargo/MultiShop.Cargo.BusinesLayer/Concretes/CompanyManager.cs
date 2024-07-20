using MultiShop.Cargo.BusinesLayer.Abstractions;
using MultiShop.Cargo.DataAccessLayer.Concretes.Context;
using MultiShop.Cargo.DataAccessLayer.Concretes.Repository;
using MultiShop.Cargo.EntitysLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinesLayer.Concretes
{
    public class CompanyManager : Repository<Company>, ICompanyService
    {
        public CompanyManager(CargoDBContext context) : base(context)
        {
        }
    }
}

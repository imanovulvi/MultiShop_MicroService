using MultiShop.Cargo.DataAccessLayer.Abstractions.Repository;
using MultiShop.Cargo.EntitysLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinesLayer.Abstractions
{
    public interface ICustomerService:IRepository<Customer>
    {
    }
}

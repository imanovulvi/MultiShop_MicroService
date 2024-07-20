using MultiShop.Cargo.DataAccessLayer.Abstractions.Repository;
using MultiShop.Cargo.DataAccessLayer.Concretes.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concretes.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CargoDBContext context;

        public Repository(CargoDBContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity=context.Set<T>().Find(id);
            context.Set<T>().Remove(entity);
            context.SaveChanges() ;
        }

        public List<T> GetAll()
        {
           return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
          return  context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
        context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}

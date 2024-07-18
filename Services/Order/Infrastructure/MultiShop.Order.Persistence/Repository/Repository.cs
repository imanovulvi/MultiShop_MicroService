using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Repository;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly OrderDBContext context;

        public Repository(OrderDBContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(T entity)
        {
          await  context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
           
         return  await context.SaveChangesAsync();

        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> expression)
        {
          return context.Set<T>().Where(expression);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
          return  await context.Set<T>().ToListAsync();
        }

        public Task<int> UpdateAsync(T entity)
        {
             context.Set<T>().Update(entity);
            return context.SaveChangesAsync();
        }
    }
}

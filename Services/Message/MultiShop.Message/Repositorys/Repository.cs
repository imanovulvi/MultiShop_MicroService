
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultiShop.Message.DataAccess.Context;
using ET=MultiShop.Message.DataAccess.Entityes;

namespace MultiShop.Message.Repositorys
{
    public class Repository<T> : IRepository<T>where T : class
    {
        private readonly MessagesContext context;

        public Repository(MessagesContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> CreateAsync(T AboutDTO)
        {
            EntityEntry entry = await Table.AddAsync(AboutDTO);
            return entry.State==EntityState.Added;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            EntityEntry entry = Table.Remove(await context.Set<T>().FindAsync(id));
            return entry.State == EntityState.Deleted;
        }

        public async Task<List<T>> GetAllAsync()
        {
         return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
       return  await Table.FindAsync(id);
        }

       

        public async Task<bool> UpdateAsync(T AboutDTO)
        {
            EntityEntry entry = Table.Update(AboutDTO);
            return entry.State == EntityState.Modified;
        }
    }
}

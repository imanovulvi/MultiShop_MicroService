using Microsoft.EntityFrameworkCore;

namespace MultiShop.Message.Repositorys
{
    public interface IRepository<T> where T : class
    {
        public DbSet<T> Table { get;  }
        Task<List<T>> GetAllAsync();
        Task<bool> CreateAsync(T AboutDTO);
        Task<bool> UpdateAsync(T AboutDTO);
        Task<bool> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);

       
    }
}

using MultiShop.Message.DataAccess.Context;
using MultiShop.Message.Repositorys;

namespace MultiShop.Message._UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MessagesContext context;

        public UnitOfWork(MessagesContext context)
        {
            this.context = context;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(context);
        }

        public int Save()
        {
          return  context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}

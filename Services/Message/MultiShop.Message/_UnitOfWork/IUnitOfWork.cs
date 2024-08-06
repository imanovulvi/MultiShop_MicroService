using MultiShop.Message.Repositorys;

namespace MultiShop.Message._UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>()where T:class;
        int Save();
        Task<int> SaveAsync();
    }
}

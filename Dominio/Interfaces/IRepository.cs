using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<Cliente> GetDOC(int DOC);
        void Save(TEntity entity);
        bool UPDATE(TEntity entity);
    }
}

using System.Linq.Expressions;

namespace ES.Domain.DomainService
{
    public interface IRepository<TKey, T>
    {
        void Add(T entity);
        T GetBy(TKey id);
        ICollection<T> GetAll();
        bool Exist(Expression<Func<T, bool>> expr);
        void Delete(T entity);
    }
}

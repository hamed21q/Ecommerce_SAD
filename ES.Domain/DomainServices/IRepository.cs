using System.Linq.Expressions;

namespace ES.Domain.DomainService
{
    public interface IRepository<TKey, T>
    {
        Task Add(T entity);
        Task<T> GetBy(TKey id);
        Task<ICollection<T>> GetAll();
        Task<bool> Exist(Expression<Func<T, bool>> expr);
        void Delete(T entity);
    }
}

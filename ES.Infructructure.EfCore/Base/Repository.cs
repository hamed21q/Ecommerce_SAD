using ES.Domain;
using ES.Domain.DomainService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ES.Infructructure.EfCore.Base
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : BaseDomain
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expr)
        {
            bool result = _context.Set<T>().Any(expr);
            return result;
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }
        
    }
}
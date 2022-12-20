using ES.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ES.Infructructure.EfCore
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : BaseDomain
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add<T>(entity);
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
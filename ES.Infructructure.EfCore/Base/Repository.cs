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

        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> expr)
        {
            return await _context.Set<T>().AnyAsync(expr);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetBy(TKey id)
        {
            return await _context.FindAsync<T>(id);
        }
        
    }
}
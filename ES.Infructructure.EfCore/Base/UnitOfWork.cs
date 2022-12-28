using ES.Domain.DomainService;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(EcommerceContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}

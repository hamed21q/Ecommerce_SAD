using ES.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void BeginTran()
        {
            dbContext.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            dbContext.Database.CommitTransaction(); 
        }

        public void RollBack()
        {
            dbContext.Database.RollbackTransaction();
        }
    }
}

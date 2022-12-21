using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.DomainService
{
    public interface IUnitOfWork
    {
        void Save();
    }
}

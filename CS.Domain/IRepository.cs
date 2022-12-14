using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public interface IRepository <TKey, T> 
    {
        void Add(T entity);
        T GetBy(TKey id);
        ICollection<T> GetAll();
        bool Exist(Expression<Func<T, bool>> expr);

    }
}

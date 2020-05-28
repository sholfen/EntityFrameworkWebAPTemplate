using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.DBTools.Repository
{
    public interface IBaseRepository<T>
    {
        void Insert(T parameter);
        void Update(T parameter);
        IQueryable<T> Query(string col = "*");
        IQueryable<T> Query();
        IQueryable<T> QueryBy(Expression<Func<T, bool>> condition);
    }
}

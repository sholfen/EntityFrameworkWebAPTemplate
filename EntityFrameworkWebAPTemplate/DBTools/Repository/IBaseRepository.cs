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
        IQueryable<T> QueryBy(Expression<Func<T, bool>> condition);
        IQueryable<T> Query(List<Expression<Func<T, bool>>> conditionList);
        void ExecuteRawSQL(string sql);
        IQueryable<T> ExecStoreProcedure(string storeProcedureRawSql, object[] parameters);
    }
}

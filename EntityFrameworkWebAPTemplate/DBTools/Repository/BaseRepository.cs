using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkWebAPTemplate.DBTools.Tools;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace EntityFrameworkWebAPTemplate.DBTools.Repository
{
    public class BaseRepository<T> where T:class
    {
        private IEnumerable<DbContext> _dbContexts;
        protected Dictionary<string, DbContext> _dbContextsDic;
        protected string _currentDBName;
        protected DbContext _currentDbContext;

        public BaseRepository(IEnumerable<DbContext> dbContexts,string dbName)
        {
            _currentDBName = dbName;
            _dbContexts = dbContexts;
            _dbContextsDic = new Dictionary<string, DbContext>();
            foreach (DbContext dbContext in _dbContexts)
            {
                _dbContextsDic.Add(dbContext.GetDBName(), dbContext);
            }
            _currentDbContext = _dbContextsDic[_currentDBName];
        }

        public void Insert(T parameter)
        {
            _currentDbContext.Add(parameter);
            _currentDbContext.SaveChanges();
        }

        public void Update(T parameter)
        {
            _currentDbContext.Update(parameter);
            _currentDbContext.SaveChanges();
        }

        public IQueryable<T> Query(string col = "*")
        {
            if (col == "*")
            {
                return _currentDbContext.Set<T>().AsNoTracking();
            }
            return _currentDbContext.Set<T>().AsNoTracking().Select<T>($"new {{ {col} }}");//"new { City, CompanyName }"
        }

        public IQueryable<T> QueryBy(Expression<Func<T, bool>> condition)
        {
            return _currentDbContext.Set<T>().Where(condition).AsNoTracking();
        }
    }
}

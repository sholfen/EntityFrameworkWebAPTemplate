using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkWebAPTemplate.DBTools.Tools;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Dynamic;

namespace EntityFrameworkWebAPTemplate.DBTools.Repository
{
    public class BaseRepository<T> where T : class
    {
        private IEnumerable<DbContext> _dbContexts;
        protected Dictionary<string, DbContext> _dbContextsDic;
        protected string _currentDBName;
        protected DbContext _currentDbContext;

        public BaseRepository(IEnumerable<DbContext> dbContexts, string dbName)
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

        public IQueryable<T> Query(List<Expression<Func<T, bool>>> conditionList)
        {
            IQueryable<T> query = _currentDbContext.Set<T>().AsNoTracking().Where(conditionList[0]);
            foreach (var condition in conditionList.Skip(1))
            {
                query = query.Where(condition);
            }

            return query;
        }

        public IQueryable<T> QueryBy(Expression<Func<T, bool>> condition)
        {
            return _currentDbContext.Set<T>().Where(condition).AsNoTracking();
        }

        public void ExecuteRawSQL(string sql)
        {
            _ = _currentDbContext.Database.ExecuteSqlRaw(sql);
        }

        public IQueryable<T> ExecStoreProcedure(string storeProcedureRawSql, object[] parameters)
        {
            IQueryable<T> result = null;
            if (parameters == null)
            {
                result = _currentDbContext.Set<T>().FromSqlRaw(storeProcedureRawSql);
            }
            else
            {
                result = _currentDbContext.Set<T>().FromSqlRaw(storeProcedureRawSql, parameters);
            }
            //exec [dbo].[CustOrderHist] @CustomerID = N'BOTTM'
            //SP Example:
            //USE[Northwind]
            //GO
            ///****** Object:  StoredProcedure [dbo].[MyTest]    Script Date: 2020/6/3 上午 09:28:31 ******/
            //SET ANSI_NULLS ON
            //GO
            //SET QUOTED_IDENTIFIER ON
            //GO
            //-- =============================================
            //--Author:		< Author,,Name >
            //--Create date: < Create Date,,>
            //--Description:	< Description,,>
            //-- =============================================
            //CREATE PROCEDURE[dbo].[MyTest]
            //    -- Add the parameters for the stored procedure here

            //    @Num int
            //AS
            //BEGIN
            //    -- SET NOCOUNT ON added to prevent extra result sets from
            //    -- interfering with SELECT statements.

            //    SET NOCOUNT ON;

            //--Insert statements for procedure here
       
            //SELECT TOP(@Num) * FROM[dbo].[Customers];
            //END


            return result;
        }
    }
}

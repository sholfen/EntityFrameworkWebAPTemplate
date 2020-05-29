using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.DBTools.Tools
{
    public static class DatabaseTools
    {
        public static string GetDBName(this DbContext dbContext)
        {
            return dbContext.Database.GetDbConnection().Database; 
        }

        public enum DBName
        {
            Northwind,
            main
        }
    }
}

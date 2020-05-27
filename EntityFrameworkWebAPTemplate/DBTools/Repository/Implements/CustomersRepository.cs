using EntityFrameworkWebAPTemplate.DBTools.Repository.Interfaces;
using EntityFrameworkWebAPTemplate.DBTools.Tools;
using EntityFrameworkWebAPTemplate.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.DBTools.Repository.Implements
{
    public class CustomersRepository: BaseRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(IEnumerable<DbContext> dbContexts) : base(dbContexts, DatabaseTools.DBName.Northwind.ToString())
        {

        }
    }
}

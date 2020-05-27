using EntityFrameworkWebAPTemplate.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.Services.Interfaces
{
    public interface ICustomersService
    {
        void AddCustomer(Customers customers);
    }
}

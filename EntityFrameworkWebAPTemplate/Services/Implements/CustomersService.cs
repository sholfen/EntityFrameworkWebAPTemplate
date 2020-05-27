using EntityFrameworkWebAPTemplate.DBTools.Repository.Interfaces;
using EntityFrameworkWebAPTemplate.Models.DBModels;
using EntityFrameworkWebAPTemplate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.Services.Implements
{
    public class CustomersService: ICustomersService
    {
        private ICustomersRepository _customersRepository;
        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public void AddCustomer(Customers customers)
        {
            _customersRepository.Insert(customers);
        }

        public List<Customers> GetAll()
        {
            var query = _customersRepository.Query();
            return query.ToList();
        }
    }
}

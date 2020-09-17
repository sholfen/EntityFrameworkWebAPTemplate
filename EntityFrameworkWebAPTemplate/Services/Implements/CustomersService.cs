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

        public List<Customers> GetAll(string col = "*")
        {
            var query = _customersRepository.Query(col);
            return query.ToList();
        }

        public Customers GetCustomerByID(string customerID)
        {
            Customers customer = _customersRepository.QueryBy(c => c.CustomerId == customerID).FirstOrDefault();
            return customer;
        }

        public List<Customers> GetCustomersBySP()
        {
            //exec [dbo].[CustOrderHist] @CustomerID = N'BOTTM'
            //dbContext.Set().FromSql("dbo.SomeSproc @Id = {0}, @Name = {1}", 45, "Ada");
            List<Customers> customers = _customersRepository.ExecStoreProcedure("exec [dbo].[MyTest] @Num = {0};", new object[] { 5 }).ToList();

            return customers;
        }
    }
}

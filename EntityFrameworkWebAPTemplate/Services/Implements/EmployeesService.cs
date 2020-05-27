using EntityFrameworkWebAPTemplate.DBTools.Repository.Interfaces;
using EntityFrameworkWebAPTemplate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.Services.Implements
{
    public class EmployeesService : IEmployeesService
    {
        private IEmployeesRepository _employeesRepository;
        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
    }
}

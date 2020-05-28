using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFrameworkWebAPTemplate.Models;
using EntityFrameworkWebAPTemplate.Services.Interfaces;
using EntityFrameworkWebAPTemplate.Models.DBModels;

namespace EntityFrameworkWebAPTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomersService _customersService;

        public HomeController(ILogger<HomeController> logger, ICustomersService customersService)
        {
            _logger = logger;
            _customersService = customersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult TestCustomers()
        {
            var result = _customersService.GetAll();
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult TestCustomer()
        {
            Customers customer = _customersService.GetCustomerByID("ANATR");
            return new JsonResult(customer);
        }

        public IActionResult TestDynamic()
        {
            var customers = _customersService.GetAll("CompanyName, CustomerID");
            return new JsonResult(customers);
        }
    }
}

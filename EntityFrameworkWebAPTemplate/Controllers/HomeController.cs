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
        private readonly IAlbumService _albumService;

        public HomeController(ILogger<HomeController> logger, ICustomersService customersService, IAlbumService albumService)
        {
            _logger = logger;
            _customersService = customersService;
            _albumService = albumService;
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

        [HttpGet]
        public IActionResult TestDynamic()
        {
            var customers = _customersService.GetAll("CompanyName, CustomerID");
            return new JsonResult(customers);
        }

        [HttpGet]
        public IActionResult TestSQLite()
        {
            var albums = _albumService.GetAll();
            return new JsonResult(albums);
        }

        [HttpGet]
        public IActionResult TestP()
        {
            var list = _customersService.GetCustomersBySP();
            return new JsonResult(list);
        }
    }
}

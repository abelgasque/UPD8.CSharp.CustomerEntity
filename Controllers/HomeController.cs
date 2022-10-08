using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UPD8.CSharp.Customer.Infrastructure.Services;
using UPD8.CSharp.Customer.Models;
using UPD8.CSharp.Infrastructure.Entities.EF;

namespace UPD8.CSharp.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CustomerService _service;

        public HomeController(
            ILogger<HomeController> logger,
            CustomerService service
        ) {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CurtomerPersistence()
        {
            return View();
        }

        public async Task<IActionResult> CurtomerConsult()
        {
            List<CustomerEntity> customers = await _service.GetAll();
            ViewBag.Customers = customers;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

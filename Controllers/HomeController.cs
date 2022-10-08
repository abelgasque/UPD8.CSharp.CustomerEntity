using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        )
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            ViewBag.Customer = new CustomerEntity();
            return View("CustomerPersistence");
        }

        [HttpGet]
        [Route("customer/delete/{id}")]
        public async Task<IActionResult> DeleteCustomerById(string id)
        {
            await _service.DeleteById(long.Parse(id));
            List<CustomerEntity> customers = await _service.GetAll();
            ViewBag.Customers = customers;
            return View("CustomerConsult");
        }

        [HttpGet]
        [Route("customer/read/{id}")]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                CustomerEntity customer = await _service.GetById(long.Parse(id));                
                ViewBag.Customer = customer;
                return View("CustomerPersistence");
            }
            ViewBag.Customer = new CustomerEntity();
            return View();
        }

        public async Task<IActionResult> GetCustomer()
        {
            List<CustomerEntity> customers = await _service.GetAll();
            ViewBag.Customers = customers;
            return View("CustomerConsult");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

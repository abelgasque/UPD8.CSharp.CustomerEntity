using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPD8.CSharp.Customer.Infrastructure.Services;
using UPD8.CSharp.Infrastructure.Entities.EF;

namespace UPD8.CSharp.Customer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CustomerService _service;

        public CustomerController(
            ILogger<HomeController> logger,
            CustomerService service
        )
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<CustomerEntity> customers = await _service.GetAll();
            ViewBag.Customers = customers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FilterForm(CustomerEntity pEntity)
        {
            List<CustomerEntity> customers = await _service.Filter(pEntity);
            ViewBag.Customers = customers;
            return View("Index");
        }

        public IActionResult Create()
        {
            ViewBag.Customer = new CustomerEntity();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateForm(CustomerEntity pEntity)
        {
            CustomerEntity entity = await _service.InsertAsync(pEntity);
            return RedirectToAction("Index");
        }

        [Route("customer/update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            CustomerEntity customer = await _service.GetById(long.Parse(id));
            ViewBag.Customer = customer;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateForm(CustomerEntity pEntity)
        {
            await _service.UpdateAsync(pEntity);
            return RedirectToAction("Index");
        }

        [Route("customer/delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            CustomerEntity customer = await _service.GetById(long.Parse(id));
            ViewBag.Customer = customer;
            return View();
        }

        [Route("customer/confirm/delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _service.DeleteById(long.Parse(id));
            return RedirectToAction("Index");
        }
    }
}

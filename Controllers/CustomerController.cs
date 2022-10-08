using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UPD8.CSharp.Customer.Infrastructure.Services;
using UPD8.CSharp.Infrastructure.Entities.EF;
using System.Collections.Generic;

namespace UPD8.CSharp.Customer.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerEntity>> InsertAsync([FromBody] CustomerEntity pEntity)
        {
            return await _service.InsertAsync(pEntity);
        }

        [HttpPut]
        public async Task<ActionResult<CustomerEntity>> UpdateAsync([FromBody] CustomerEntity pEntity)
        {
            return await _service.UpdateAsync(pEntity);
        }

        
        [HttpGet]
        [Route("{pId}")]
        public async Task<ActionResult<CustomerEntity>> GetById(long pId)
        {
            return await _service.GetById(pId);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerEntity>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpDelete]
        [Route("{pId}")]
        public async Task DeleteById(long pId)
        {
            await _service.DeleteById(pId);
        }
    }
}

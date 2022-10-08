using System.Threading.Tasks;
using System;
using UPD8.CSharp.Infrastructure.Repositories;
using UPD8.CSharp.Infrastructure.Entities.EF;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace UPD8.CSharp.Customer.Infrastructure.Services
{
    public class CustomerService
    {
        private readonly ILogger<CustomerService> _logger;

        private readonly CustomerRepository _repository;

        public CustomerService(
            ILogger<CustomerService> logger,
            CustomerRepository repository
        )
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<CustomerEntity> InsertAsync(CustomerEntity pEntity)
        {
            _logger.LogInformation($"CustomerService.InsertAsync => Start");
            try
            {
                _logger.LogInformation($"CustomerService.InsertAsync => End");
                return await _repository.InsertAsync(pEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService.InsertAsync => Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerEntity pEntity)
        {
            _logger.LogInformation($"CustomerService.UpdateAsync => Start");
            try
            {
                _logger.LogInformation($"CustomerService.UpdateAsync => End");
                return await _repository.UpdateAsync(pEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService.UpdateAsync => Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<CustomerEntity> GetById(long pId)
        {
            _logger.LogInformation($"CustomerService.GetById => Start");
            try
            {
                _logger.LogInformation($"CustomerService.GetById => End");
                return await _repository.GetById(pId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService.GetById => Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CustomerEntity>> GetAll()
        {
            _logger.LogInformation($"CustomerService.GetAll => Start");
            try
            {
                _logger.LogInformation($"CustomerService.GetAll => End");
                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService.GetAll => Exception: {ex.Message}");
                return new List<CustomerEntity>();
            }
        }

        public async Task DeleteById(long pId)
        {
            _logger.LogInformation($"CustomerService.DeleteById => Start");
            try
            {
                _logger.LogInformation($"CustomerService.DeleteById => End");
                await _repository.DeleteById(pId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService.DeleteById => Exception: {ex.Message}");                
            }
        }        
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPD8.CSharp.Infrastructure.Entities.EF;

namespace UPD8.CSharp.Infrastructure.Repositories
{
    public class CustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerEntity> InsertAsync(CustomerEntity pEntity)
        {
            _context.Customer.Add(pEntity);
            int nuResult = await _context.SaveChangesAsync();
            return (nuResult > 0) ? pEntity : null;
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerEntity pEntity)
        {
            _context.Customer.Update(pEntity);
            int nuResult = await _context.SaveChangesAsync();
            return (nuResult > 0) ? pEntity : null;
        }

        public async Task<CustomerEntity> GetById(long pId)
        {
            IQueryable<CustomerEntity> query = _context.Customer.AsNoTracking().Where(e => e.Id == pId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<CustomerEntity>> GetAll()
        {
            IQueryable<CustomerEntity> query = _context.Customer.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<CustomerEntity>> Filter(CustomerEntity pEntity)
        {
            IQueryable<CustomerEntity> query = _context.Customer.AsNoTracking();
            query = (!string.IsNullOrEmpty(pEntity.Name)) ? query.Where(e => e.Name.Contains(pEntity.Name)) : query;
            query = (!string.IsNullOrEmpty(pEntity.Document)) ? query.Where(e => e.Document.Equals(pEntity.Document)) : query;
            query = (pEntity.Birth != null) ? query.Where(e => e.Birth.Equals(pEntity.Birth)) : query;
            query = (!string.IsNullOrEmpty(pEntity.Gender)) ? query.Where(e => e.Gender.Equals(pEntity.Gender)) : query;
            query = (!string.IsNullOrEmpty(pEntity.Address)) ? query.Where(e => e.Address.Contains(pEntity.Address)) : query;
            query = (!string.IsNullOrEmpty(pEntity.State)) ? query.Where(e => e.State.Equals(pEntity.State)) : query;
            query = (!string.IsNullOrEmpty(pEntity.City)) ? query.Where(e => e.City.Contains(pEntity.City)) : query;
            return await query.ToListAsync();
        }

        public async Task<bool> DeleteById(long pId)
        {
            var entity = await this.GetById(pId);
            _context.Customer.Remove(entity);
            int nuResult = await _context.SaveChangesAsync();
            return (nuResult > 0);
        }
    }
}
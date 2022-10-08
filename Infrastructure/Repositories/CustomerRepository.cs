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
            //query = (pIsActive != null) ? query.Where(e => e.IsActive == pIsActive.Value) : query;
            return await query.OrderByDescending(e => e.Id).ToListAsync();
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
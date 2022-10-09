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
            query = (pEntity.Name != null) ? query.Where(e => e.Name.Contains(pEntity.Name)) : query;
            query = (pEntity.Document != null) ? query.Where(e => e.Document.Equals(pEntity.Document)) : query;
            query = (pEntity.Birth != null) ? query.Where(e => e.Birth.Equals(pEntity.Birth)) : query;
            query = (pEntity.Gender != "Selecione") ? query.Where(e => e.Gender.Equals(pEntity.Gender)) : query;
            query = (pEntity.Address != null) ? query.Where(e => e.Address.Contains(pEntity.Address)) : query;
            query = (pEntity.State != "Selecione") ? query.Where(e => e.State.Equals(pEntity.State)) : query;
            query = (pEntity.City != null) ? query.Where(e => e.City.Contains(pEntity.City)) : query;
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
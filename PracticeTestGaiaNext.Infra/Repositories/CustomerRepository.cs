using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticeTestGaiaNext.Domain.Entities;
using PracticeTestGaiaNext.Domain.Repositories;
using PracticeTestGaiaNext.Infra.Data;

namespace PracticeTestGaiaNext.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Customer[]> GetCustomersAsync()
        {
            return await _context.Customers.AsNoTracking().ToArrayAsync();
        }

        public async Task<Customer> GetCustomersAsyncById(int Id)
        {
            return await _context.Customers.AsNoTracking().Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}

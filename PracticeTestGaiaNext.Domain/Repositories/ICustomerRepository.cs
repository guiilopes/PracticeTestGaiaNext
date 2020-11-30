using PracticeTestGaiaNext.Domain.Entities;
using System.Threading.Tasks;

namespace PracticeTestGaiaNext.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Customer[]> GetCustomersAsync();
        Task<Customer> GetCustomersAsyncById(int Id);
    }
}

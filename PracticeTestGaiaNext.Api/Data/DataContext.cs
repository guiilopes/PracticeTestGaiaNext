using Microsoft.EntityFrameworkCore;
using PracticeTestGaiaNext.Api.Model;

namespace PracticeTestGaiaNext.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}

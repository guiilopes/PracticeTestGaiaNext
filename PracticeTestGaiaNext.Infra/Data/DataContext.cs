using Microsoft.EntityFrameworkCore;
using PracticeTestGaiaNext.Domain.Entities;

namespace PracticeTestGaiaNext.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}

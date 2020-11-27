using Microsoft.EntityFrameworkCore;

namespace PracticeTestGaiaNext.Infra.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}

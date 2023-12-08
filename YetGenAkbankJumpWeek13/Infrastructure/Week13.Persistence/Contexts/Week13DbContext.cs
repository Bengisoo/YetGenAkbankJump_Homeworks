using Microsoft.EntityFrameworkCore;

using Week13.Domain.Entities;

namespace Week13.Persistence.Contexts
{
    public class Week13DbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("YetgenPostgreSQLDb");
        }
    }
}

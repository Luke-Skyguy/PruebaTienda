
using Microsoft.EntityFrameworkCore;
using PruebaTenda.Entity;

namespace PruebaTenda.Data
{
    public class DataContext : DbContext
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        public DataContext(DbContextOptions<DataContext> options) : base(options)
#pragma warning restore CS0436 // Type conflicts with imported type
        {

        }
#pragma warning disable CS0436 // Type conflicts with imported type
        public DbSet<Product> Products { get; set;}
#pragma warning restore CS0436 // Type conflicts with imported type
    }
}
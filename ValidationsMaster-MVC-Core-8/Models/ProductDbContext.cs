using Microsoft.EntityFrameworkCore;
using ValidationsMaster_MVC_Core_8.Models;

namespace ValidationsMaster_MVC_Core_8.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

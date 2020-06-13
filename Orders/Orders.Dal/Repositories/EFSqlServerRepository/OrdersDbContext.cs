using Microsoft.EntityFrameworkCore;
using Orders.Dal.Dbos;

namespace Orders.Dal.Repositories.EFSqlServerRepository
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductDbo> Products { get; set; }
    }
}
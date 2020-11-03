using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orders.Dal.Dbos;

namespace Orders.Dal.Repositories.EFSqlServerRepository
{
    public class EfSqlServerProductRepository : IProductRepository
    {
        private DbContextOptionsBuilder<OrdersDbContext> optionsBuilder;

        public EfSqlServerProductRepository(IConfiguration configuration)
        {
            optionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }

        public async ValueTask<IEnumerable<ProductDbo>> Get()
        {
            await using var ctxt = new OrdersDbContext(optionsBuilder.Options);
            return await ctxt.Products.ToListAsync();
        }

        public async ValueTask<ProductDbo> Get(long id)
        {
            await using var ctxt = new OrdersDbContext(optionsBuilder.Options);
            return await ctxt.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async ValueTask<long> Create(ProductDbo productDbo)
        {
            await using var ctxt = new OrdersDbContext(optionsBuilder.Options);
            await ctxt.Products.AddAsync(productDbo);

            await ctxt.SaveChangesAsync();

            return productDbo.Id;
        }

        public async ValueTask<bool> Exists(long id)
        {
            await using var ctxt = new OrdersDbContext(optionsBuilder.Options);
            return await ctxt.Products.AnyAsync(x => x.Id == id);
        }

        public async ValueTask Update(long id, ProductDbo productDbo)
        {
            await using var ctxt = new OrdersDbContext(optionsBuilder.Options);
            var res = await ctxt.Products.FirstOrDefaultAsync(x => x.Id == id);

            res.Name = productDbo.Name;
            res.Description = productDbo.Description;
            res.Price = productDbo.Price;

            await ctxt.SaveChangesAsync();
        }

        public async ValueTask Delete(long id)
        {
            await using var ctxt = new OrdersDbContext(optionsBuilder.Options);
            var res = await ctxt.Products.FirstOrDefaultAsync(x => x.Id == id);

            ctxt.Remove(res);

            await ctxt.SaveChangesAsync();
        }
    }
}
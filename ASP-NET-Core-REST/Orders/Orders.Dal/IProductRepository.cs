using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Dal.Dbos;

namespace Orders.Dal
{
    public interface IProductRepository
    {
        ValueTask<IEnumerable<ProductDbo>> Get();
        
        ValueTask<ProductDbo> Get(long id);
        
        ValueTask<long> Create(ProductDbo productDbo);
        
        ValueTask<bool> Exists(long id);

        ValueTask Update(long id, ProductDbo productDbo);
        
        ValueTask Delete(long id);
    }
}

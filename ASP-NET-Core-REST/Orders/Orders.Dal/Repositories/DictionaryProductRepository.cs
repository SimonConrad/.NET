using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Dal.Dbos;

namespace Orders.Dal.Repositories
{
    public class DictionaryProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<long, ProductDbo> storage = new ConcurrentDictionary<long, ProductDbo>();

        public async ValueTask<IEnumerable<ProductDbo>> Get()
        {
            // INFO No async methods so use of such hack, only for testing purposes
            await Task.Delay(5);
            return storage.Values.ToList();
        }

        public async ValueTask<ProductDbo> Get(long id)
        {
            await Task.Delay(5);
            
            storage.TryGetValue(id, out var res);
            return res;
        }

        public async ValueTask<long> Create(ProductDbo productDbo)
        {
            await Task.Delay(5);

            long nextId = 0;

            if (storage.Any())
            {
                nextId = storage.Keys.Max();
            }
            nextId++;

            productDbo.Id = nextId;
            storage.TryAdd(nextId, productDbo);

            return nextId;
        }

        public async ValueTask<bool> Exists(long id)
        {
            await Task.Delay(5);

            return storage.Keys.Any(x => x == id);
        }

        public async ValueTask Update(long id, ProductDbo productDbo)
        {
            await Task.Delay(5);

            storage.TryRemove(id, out var res);
            storage.TryAdd(id, productDbo);
        }

        public async ValueTask Delete(long id)
        {
            await Task.Delay(5);

            storage.TryRemove(id, out var res);
        }
    }
}
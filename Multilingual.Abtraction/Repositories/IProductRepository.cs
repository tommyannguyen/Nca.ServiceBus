using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Multilingual.Abtraction.Repositories
{
    public interface IProductRepository 
    {
        Task<Product> GetProductAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsAsync(int top);

        Task<Guid> AddProductAsync(Product product);
    }
}

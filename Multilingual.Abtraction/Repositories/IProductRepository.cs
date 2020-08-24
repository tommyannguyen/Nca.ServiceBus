using System;
using System.Threading.Tasks;

namespace Multilingual.Abtraction.Repositories
{
    public interface IProductRepository 
    {
        Task<Product> GetProductAsync(Guid id);
        Task<Guid> AddProductAsync(Product product);
    }
}

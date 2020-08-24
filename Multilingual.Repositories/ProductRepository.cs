using Microsoft.EntityFrameworkCore;
using Multilingual.Abtraction;
using Multilingual.Abtraction.Repositories;
using System;
using System.Threading.Tasks;

namespace Multilingual.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly MultilingualDbContext _dbContext;

        public ProductRepository(MultilingualDbContext multilingualDbContext)
        {
            _dbContext = multilingualDbContext;
        }

        public async Task<Guid> AddProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}

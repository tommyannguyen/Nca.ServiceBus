using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Multilingual.Abtraction;
using Multilingual.Abtraction.Repositories;
using Multilingual.MockDb.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multilingual.MockDb.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MockDbContext _dbContext;

        public ProductRepository(MockDbContext mockDbContext)
        {
            _dbContext = mockDbContext;
        }
        public async Task<Guid> AddProductAsync(Product product)
        {
            var dbProduct = ProductConverter.Convert(product);
            _dbContext.Products.Add(dbProduct);

            await _dbContext.SaveChangesAsync();

            return dbProduct.Id;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            return ProductConverter.Convert(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int top)
        {
            var products = await _dbContext.Products
                .AsQueryable()
                .OrderByDescending(o => o.Id)
                .Take(top)
                .ToListAsync();
            return products.Select(ProductConverter.Convert);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Multilinguage.ApplicationServices;
using Multilingual.Abtraction;
using Multilingual.Abtraction.Application;
using Multilingual.Abtraction.Repositories;
using Multilingual.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Multilingual.Test
{
    public class TestProduct
    {
        private readonly IServiceProvider _serviceProvider;
        public TestProduct()
        {
            var services = new ServiceCollection();
            services.AddDbContext<MultilingualDbContext>(options =>
                options.UseMySql("Server=localhost; Database=testDb;User=root;Password=password123")
            );

            //IoC
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IApplicationContext>(f =>
            {
                return new ApplicationContext()
                {
                    CurrentCulture = CultureNames.En,
                    TenantId = 1
                };
            });
            services.AddTransient<IProductRepository, ProductRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task TestAddProduct()
        {
            var productService = _serviceProvider.GetService<IProductService>();

            var productId = await productService.AddProductAsync(new Abtraction.Dto.AddProductInfoDto() { Name = "test" });

            var product = await productService.GetProductAsync(productId);

            Assert.NotNull(product);
            Assert.Equal("test", product.Name);
        }
    }
}

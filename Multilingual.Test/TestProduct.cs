using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Multilinguage.ApplicationServices;
using Multilingual.Abtraction;
using Multilingual.Abtraction.Application;
using Multilingual.Abtraction.Dto;
using Multilingual.Abtraction.Repositories;
using Multilingual.MockDb;
using Multilingual.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            //Default

            services.AddDbContext<MultilingualDbContext>(options =>
                options.UseMySql("Server=localhost; Database=testDb;User=root;Password=123456a@A")
            );
            services.AddTransient<IProductRepository, ProductRepository>();

            //Chang Repository

            //services.AddDbContext<MockDbContext>(options =>
            //    options.UseMySql("Server=localhost; Database=mockDb;User=root;Password=123456a@A")
            // );

            //services.AddTransient<IProductRepository, Multilingual.MockDb.Repositories.ProductRepository>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task TestAddProduct()
        {
            var productService = _serviceProvider.GetService<IProductService>();

            var productId = await productService.AddProductAsync(new AddProductInfoDto() { Name = "test" });

            //ui call
            var product = await productService.GetProductAsync(productId);

            Assert.NotNull(product);
            Assert.Equal("test", product.Name);
        }

        [Fact]
        public async Task TestInsertValuesAsync()
        {
            var productService = _serviceProvider.GetService<IProductService>();
            var productIds = new List<Guid>();

            await CaculateTimeTaskAsync("Insert", async () =>
            {
                var numberOnProducts = 50 * 1000;
                for (var i = 0; i < numberOnProducts; i++)
                {
                    var productId = await productService.AddProductAsync(new AddProductDto()
                    {

                        Data = new List<MultilingualDto<AddProductInfoDto>>()
                    {
                     new MultilingualDto<AddProductInfoDto>(){  CultuleName = CultureNames.En, Value = new AddProductInfoDto(){ Name= $"{i}_{CultureNames.En}_Test" } },
                     new MultilingualDto<AddProductInfoDto>(){  CultuleName = CultureNames.De, Value = new AddProductInfoDto(){ Name= $"{i}_{CultureNames.De}_Test" } },
                     new MultilingualDto<AddProductInfoDto>(){  CultuleName = CultureNames.Fr, Value = new AddProductInfoDto(){ Name= $"{i}_{CultureNames.Fr}_Test" } },
                     new MultilingualDto<AddProductInfoDto>(){  CultuleName = CultureNames.Vn, Value = new AddProductInfoDto(){ Name= $"{i}_{CultureNames.Vn}_Test" } },
                    }
                    });

                    productIds.Add(productId);
                }
            });
         

            Assert.True(productIds.Any());
        }
        [Fact]
        public async Task GetTopValuesAsync()
        {
            var productService = _serviceProvider.GetService<IProductService>();
            var top = 100;
            //Initial
            await CaculateTimeTaskAsync($"1 call GetTopDescById-Top ${top}", async () =>
            {
                var products = await productService.GetProductsAsync(top);

                Assert.True(products.Any());
            });

            //Second times
            await CaculateTimeTaskAsync($"2 call GetTopDescById-Top ${top}", async () =>
            {
                var products = await productService.GetProductsAsync(top);

                Assert.True(products.Any());
            });


        }
        private async Task CaculateTimeTaskAsync(string prefix ,Func<Task> function)
        {
            var sw = new Stopwatch();
            sw.Start();
                await function();
            sw.Stop();
            Trace.WriteLine($"{prefix} Time Taken --> {sw.ElapsedMilliseconds} Milliseconds");
        }

    }
}

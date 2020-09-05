using Multilinguage.ApplicationServices.Converter;
using Multilingual.Abtraction;
using Multilingual.Abtraction.Application;
using Multilingual.Abtraction.Dto;
using Multilingual.Abtraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multilinguage.ApplicationServices
{
    public class ProductService : IProductService
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IApplicationContext applicationContext, 
            IProductRepository productRepository)
        {
            _applicationContext = applicationContext;
            _productRepository = productRepository;
        }

        public async Task<Guid> AddProductAsync(AddProductInfoDto productDto)
        {
            var currentCulture = _applicationContext.CurrentCulture;

            // Automapper
            var product = ProductConverter.Convert(productDto, currentCulture);
            return await _productRepository.AddProductAsync(product);
        }

        public async Task<Guid> AddProductAsync(AddProductDto productDtos)
        {
            //Automapper
            var product = ProductConverter.Convert(productDtos);
            return await _productRepository.AddProductAsync(product);
        }

        public async Task<ProductDto> GetProductAsync(Guid id)
        {
            var currentCulture = _applicationContext.CurrentCulture;

            var product = await _productRepository.GetProductAsync(id);

            //Autompper;
            return ProductConverter.Convert(product, currentCulture);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(int top)
        {
            var products = await _productRepository.GetProductsAsync(top);
            var currentCulture = _applicationContext.CurrentCulture;

            return products.Select(product => ProductConverter.Convert(product, currentCulture));
        }
    }
}

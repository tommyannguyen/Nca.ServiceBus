using Multilingual.Abtraction.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Multilingual.Abtraction.Application
{
    public interface IProductService
    {
        Task<ProductDto> GetProductAsync(Guid id);

        Task<IEnumerable<ProductDto>> GetProductsAsync(int top);

        Task<Guid> AddProductAsync(AddProductInfoDto product);
        Task<Guid> AddProductAsync(AddProductDto productDto);
    }
}

using Multilingual.Abtraction.Dto;
using System;
using System.Threading.Tasks;

namespace Multilingual.Abtraction.Application
{
    public interface IProductService
    {
        Task<ProductDto> GetProductAsync(Guid id);

        Task<Guid> AddProductAsync(AddProductInfoDto product);
        Task<Guid> AddProductAsync(AddProductDto productDto);
    }
}

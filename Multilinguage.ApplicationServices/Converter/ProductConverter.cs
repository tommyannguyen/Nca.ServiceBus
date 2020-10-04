using Multilingual.Abtraction;
using Multilingual.Abtraction.Dto;
using Multilingual.Abtraction.Types;

namespace Multilinguage.ApplicationServices.Converter
{
    public static class ProductConverter
    {
        public static Product Convert(AddProductInfoDto addProductInfoDto, string currentCulture)
        {
            var product = new Product
            {
                ProductName = new MultilingualString()
            };
            product.ProductName.SetTranslation(currentCulture, addProductInfoDto.Name);
            return product;
        }

        public static Product Convert(AddProductDto addProductDto)
        {
            var product = new Product
            {
                ProductName = new MultilingualString()
            };
            foreach (var productDto in addProductDto.Data)
            {
                product.ProductName.SetTranslation(productDto.CultuleName, productDto.Value.Name);
            }
            return product;
        }

        public static ProductDto Convert(Product product, string currentCulture)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.ProductName.Translate(currentCulture)
            };
        }
    }
}

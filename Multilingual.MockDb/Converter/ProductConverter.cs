
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Multilingual.MockDb.Converter
{
    public static class ProductConverter
    {
        public static Models.Product Convert(Multilingual.Abtraction.Product product)
        {
            return new Models.Product()
            {
                Name = JsonConvert.SerializeObject(Convert(product.ProductName))
            };
        }

        public static IEnumerable<Models.Translation> Convert(Multilingual.Abtraction.MultilingualString multilingualString)
        {
            return multilingualString.Translations.Select(s => new Models.Translation()
            {
                IsAutomatic = s.IsAutomatic,
                Language = s.Language,
                Text = s.Text
            });
        }

        public static Multilingual.Abtraction.Product Convert(Models.Product product)
        {
            return new Abtraction.Product()
            {
                Id = product.Id,
                ProductName = new Abtraction.MultilingualString()
                {
                    Id = Guid.NewGuid(),
                    Translations = Convert(product.Name).ToList()
                }
            };
        }
        public static IEnumerable<Abtraction.Translation> Convert(string text)
        {
            var dbTranslations = JsonConvert.DeserializeObject<IEnumerable<Models.Translation>>(text);

            return dbTranslations.Select(s => new Abtraction.Translation()
            {
                Id = Guid.NewGuid(),
                IsAutomatic = s.IsAutomatic,
                Language = s.Language,
                Text = s.Text
            });
        }
    }
}

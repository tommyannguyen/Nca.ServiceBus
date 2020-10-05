using Multilingual.Abtraction;
using Multilingual.Abtraction.Models.Metadata;
using Multilingual.Abtraction.Properties;
using Multilingual.Abtraction.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Multilinguage.ApplicationServices.QueryExtentions;
using Multilingual.Abtraction.Descrtiptions;

namespace Multilingual.Test
{
    public class TestMetadata
    {
        [Fact]
        public async Task Test()
        {
            //Encapsulate data
            var titlePropertyName = "Title";
            var textValue = "AAA";
            var titleProperty = new MultilingualProperty()
            {
                Description = new DefaultDescription()
                {
                    Id = Guid.NewGuid(),
                    IsCustom = false,
                    PropertyName = titlePropertyName,
                    DisplayName = new MultilingualString()
                    {
                        Text = textValue
                    },
                },
                Value = new MultilingualString()
                {
                    Text = textValue
                }
            };

            var intPropertyName = "Integer";
            int iValue = 5;
            var integerProperty = new BasicProperty<IntMedatadaDescription, IntegerType>()
            {
                Description = new IntMedatadaDescription()
                {
                    Id = Guid.NewGuid(),
                    IsCustom = false,
                    PropertyName = intPropertyName,
                    DisplayName = new MultilingualString()
                    {
                        Text = textValue
                    },
                },
                Value = new IntegerType()
                {
                    Value = iValue
                }
            };
            var metadatas = new List<IProperty>
            {
                titleProperty,
                integerProperty
            };
            var product = new Product(metadatas);


            // Extract data
            var title = product.GetPropertyValue<MultilingualString>(titlePropertyName);

            var unknow = product.GetPropertyValue<MultilingualString>("unknow");

            var integerValue = product.GetPropertyValue<IntegerType>(intPropertyName);
            
            var wrongType = product.GetPropertyValue<IntegerType>(titlePropertyName);

            Assert.Null(unknow);
            Assert.Null(wrongType);
            Assert.True(title.Text == textValue);
            Assert.Equal(integerValue.Value, iValue);

            var newTitle = "Ten ten ten";
            title.Text = newTitle;
            product.SetPropertyValue(titlePropertyName, title);
            title = product.GetPropertyValue<MultilingualString>(titlePropertyName);
            Assert.Equal(title.Text, newTitle);

        }
    }
}

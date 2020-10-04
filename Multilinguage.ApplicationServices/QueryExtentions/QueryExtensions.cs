using Multilingual.Abtraction;
using Multilingual.Abtraction.Models.Metadata;
using Multilingual.Abtraction.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Multilinguage.ApplicationServices.QueryExtentions
{
    public static class QueryExtensions
    {
        public static V GetPropertyValue<V>(this MetadataEntity entity, string propertyName)
        {
            return entity.Metadatas.OfType<IProperty>()
                .Where(t => t.Description.PropertyName == propertyName)
                .Where(s => s.Value is V)
                .Select(s => (V) s.Value)
                .FirstOrDefault();
        }

        public static void SetPropertyValue<V>(this MetadataEntity entity, string propertyName, V value)
        {
            var propertyValue = entity.GetPropertyValue<V>(propertyName);
            if(propertyValue != null)
            {
                propertyValue = value;
            }
        }
    }
}

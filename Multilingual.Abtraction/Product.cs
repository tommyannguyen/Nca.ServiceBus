using Multilingual.Abtraction.Models.Metadata;
using Multilingual.Abtraction.Types;
using System;
using System.Collections.Generic;

namespace Multilingual.Abtraction
{
    public class Product : MetadataEntity
    {
        public Product() : base(new List<IProperty>())
        {

        }
        public Product(IEnumerable<IProperty> metadatas) : base(metadatas)
        {
        }

        public Guid Id { get; set; }
        public MultilingualString ProductName { get; set; }// string
    }
}

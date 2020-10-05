using Multilingual.Abtraction.Models.Metadata;
using Multilingual.Abtraction.Types;
using System;

namespace Multilingual.Abtraction.Descrtiptions
{
    public abstract class MetadataDescription<T> :
        IMedatadaDescription<T>
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; }
        public MultilingualString DisplayName { get; set; }
        public Type Type => typeof(T);
        public bool IsCustom { get; set; }
    }
}

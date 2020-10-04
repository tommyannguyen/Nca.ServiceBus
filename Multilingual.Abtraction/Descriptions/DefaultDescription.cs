using Multilingual.Abtraction.Models.Metadata;
using Multilingual.Abtraction.Types;
using System;

namespace Multilingual.Abtraction.Descrtiptions
{
    public class DefaultDescription : IMedatadaDescription<MultilingualString>
    {
        public Guid Id { get; set; }

        public MultilingualString DisplayName { get; set; }
        public bool IsCustom { get; set; }

        public Type Type { get; set; }
        public string PropertyName { get; set; }
    }
}

using Multilingual.Abtraction.Descrtiptions;
using Multilingual.Abtraction.Models.Metadata;
using Multilingual.Abtraction.Types;

namespace Multilingual.Abtraction.Properties
{
    public class MultilingualProperty : 
        IProperty<MultilingualDescription, MultilingualString>
    {
        public IMedatadaDescription Description { get; set; }
        public IDefinedType Value { get; set; }
        public string Name { get; set; }
    }
}

using Multilingual.Abtraction.Models.Metadata;

namespace Multilingual.Abtraction.Properties
{
    public class BasicProperty<D, V> : IProperty where V : IDefinedType where D : IMedatadaDescription<V>
    {
        public IMedatadaDescription Description { get; set; }
        public IDefinedType Value { get; set; }
        public string Name { get; set; }
    }
}

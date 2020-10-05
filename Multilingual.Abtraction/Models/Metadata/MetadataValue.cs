namespace Multilingual.Abtraction.Models.Metadata
{
    public class MetadataValue<T>: IProperty<T>
    {
        public IMedatadaDescription<T> Description { get; set; }
        public T Value { get; set; }
    }
}

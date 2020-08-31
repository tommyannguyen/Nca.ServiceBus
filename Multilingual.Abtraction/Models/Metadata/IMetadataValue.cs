namespace Multilingual.Abtraction.Models.Metadata
{
    public interface IMetadataValue
    {

    }
    public interface IMetadataValue<T> : IMetadataValue
    {
        IMedatadaDescription<T> Description { get; set; }
        T Value { get; set; }
    }

}

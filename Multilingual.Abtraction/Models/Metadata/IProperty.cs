namespace Multilingual.Abtraction.Models.Metadata
{
    public interface IProperty
    {
        string Name { get; set; }
        IMedatadaDescription Description { get; set; }
        IDefinedType Value { get; set; }
    }
    public interface IProperty<D,V>: IProperty where V: IDefinedType where D : IMedatadaDescription<V>
    {
    }

}

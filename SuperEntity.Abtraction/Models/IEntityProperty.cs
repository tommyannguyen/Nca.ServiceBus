namespace SuperEntity.Abtraction.Models
{
    public interface IEntityProperty<D,T> 
        where T : IEntityPropertyValue
        where D : IEntityPropertyDescriptor
    {
        D Descriptor { get; }
        T Value { get; }
        EntityMultilingualContext MultilingualContext { get; }
    }
}

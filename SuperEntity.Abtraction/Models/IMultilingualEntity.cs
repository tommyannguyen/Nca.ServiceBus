
namespace SuperEntity.Abtraction.Models
{
    public interface IMultilingualEntity : IEntity
    {
        EntityMultilingualContext MultilingualContext { get; }
    }
}

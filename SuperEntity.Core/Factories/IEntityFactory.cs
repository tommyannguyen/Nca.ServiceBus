using SuperEntity.Abtraction.Models;
using SuperEntity.Core.Models;

namespace SuperEntity.Core.Factories
{
    public interface IEntityFactory
    {
        Venture CreateVenture(Language language = null);
    }
}

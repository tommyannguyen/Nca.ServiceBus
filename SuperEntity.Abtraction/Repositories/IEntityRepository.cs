using SuperEntity.Abtraction.Models.Descriptors;
using System.Collections.Generic;

namespace SuperEntity.Abtraction.Repositories
{
    public interface IEntityRepository
    {
        IEnumerable<MultiLingualStringDescriptor> GetStringDescriptors();
    }
}

using SuperEntity.Abtraction.Models.Descriptors;

namespace SuperEntity.Abtraction.Services
{
    public interface IEntityService
    {
        public MultiLingualStringDescriptor GetMultiLingualStringDescriptor(string key);
    }

}

using SuperEntity.Abtraction.Models.Descriptors;
using SuperEntity.Abtraction.Repositories;
using SuperEntity.Abtraction.Services;
using System;
using System.Linq;

namespace SuperEntity.Core.Services
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public MultiLingualStringDescriptor GetMultiLingualStringDescriptor(string key)
        {
            var descriptor = _entityRepository.GetStringDescriptors().FirstOrDefault(d => d.Key.Equals(key));

            if (descriptor == null)
                throw new ArgumentOutOfRangeException();

            return descriptor;
        }
    }
}

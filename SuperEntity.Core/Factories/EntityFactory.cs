using SuperEntity.Abtraction.Models;
using SuperEntity.Abtraction.Services;
using SuperEntity.Core.Models;

namespace SuperEntity.Core.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IEntityService _entityService;

        public EntityFactory(IEntityService entityService)
        {
            _entityService = entityService;
        }
        public Venture CreateVenture(Language language = null)
        {
            var venture = new Venture();
            venture.SetCurrentLanguage(language);
            var descritor = _entityService.GetMultiLingualStringDescriptor(venture.Title.Descriptor.Key);


            venture.Title.Descriptor.UpdateValue(descritor.Value);
            return venture;
        }
    }
}

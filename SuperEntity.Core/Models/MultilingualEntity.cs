using SuperEntity.Abtraction.Models;
using System.Collections.Generic;

namespace SuperEntity.Core.Models
{
    public class MultilingualEntity : IMultilingualEntity
    {
        public MultilingualEntity()
        {
            MultilingualContext = new EntityMultilingualContext(new List<Language>());
        }
        public EntityMultilingualContext MultilingualContext { get; private set; } 

        public void SetCurrentLanguage(Language language = null)
        {
            MultilingualContext.SetCurrentLanguage(language?? SystemLanguages.DefaultLanguage);
        }
    }
}

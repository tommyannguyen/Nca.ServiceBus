using System.Collections.Generic;
using System.Linq;

namespace SuperEntity.Abtraction.Models
{
    public interface IEntityMultilingualContext
    {
       IList<Language> Languages { get; }
       Language CurrentLanguage { get; }
       void SetCurrentLanguage(Language language);
    }

    public class EntityMultilingualContext : IEntityMultilingualContext
    {
        public EntityMultilingualContext(IList<Language> languages)
        {
            Languages = languages;
            CurrentLanguage = SystemLanguages.DefaultLanguage;
        }
        public IList<Language> Languages { get; private set; }

        public Language CurrentLanguage { get; private set; }

        public void SetCurrentLanguage(Language language)
        {
            if(!Languages.Any(l => l.Equals(language)))
            {
                Languages.Add(language);
            }
            CurrentLanguage = language;
        }
    }
}

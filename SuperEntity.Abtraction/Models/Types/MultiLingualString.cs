using System.Collections.Generic;
using System.Linq;

namespace SuperEntity.Abtraction.Models.Types
{
    public class MultiLingualString: IEntityPropertyValue
    {
        public MultiLingualString()
        {
            Language = SystemLanguages.DefaultLanguage;
            Values = new List<MultileLingualValue>() { new MultileLingualValue(Language, string.Empty) };
        }
        public Language Language { get; protected set; } 
        public string Value
        {
            get
            {
                return Values.FirstOrDefault(v => v.Language.Equals(Language)).Value;
            }
        }
        protected IEnumerable<MultileLingualValue> Values { get; private set; }

        public IEnumerable<Language> GetLanguages()
        {
            return Values.Select(v => v.Language);
        }

        public void SetLanguage(Language language)
        {
            Language = language;
            var selectValue = Values.FirstOrDefault(v => v.Language.Equals(language));
            if (selectValue == null)
            {
                selectValue = new MultileLingualValue(language, string.Empty);
            }
        }

        public void SetValue(Language language, string value)
        {
            var selectValue = Values.FirstOrDefault(v => v.Language.Equals(language));
            if (selectValue == null)
            {
                selectValue = new MultileLingualValue(language, value);
            }
            else
            {
                selectValue.SetValue(value);
            }
        }
    }
}

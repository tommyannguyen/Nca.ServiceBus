using Multilingual.Abtraction.Models.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Multilingual.Abtraction.Types
{
    public class MultilingualString : IDefinedType
    {
        public Guid Id { get; set; }

        // Default value
        public string Text { get; set; } = "";
        public virtual ICollection<Translation> Translations { get; set; }
        public void SetTranslation(string language, string text, bool isAutomatic = false)
        {
            if (Translations == null)
                Translations = new List<Translation>();

            var found = Translations
                                .Where(t => t.Language.Equals(language, StringComparison.OrdinalIgnoreCase))
                                .FirstOrDefault();
            if (found == null)
                Translations.Add(new Translation() { Language = language, Text = text, IsAutomatic = isAutomatic });
            else
            {
                found.Text = text;
                found.IsAutomatic = isAutomatic;
            }
        }

        public string Translate(string cultureName)
        {
            var translation = Translations?.Where(
                                     t => t.Language.Equals(cultureName)).FirstOrDefault();

            return translation == null ? Text : translation.Text;
        }
    }
}

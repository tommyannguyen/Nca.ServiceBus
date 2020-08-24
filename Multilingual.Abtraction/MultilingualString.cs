using System;
using System.Collections.Generic;
using System.Linq;

namespace Multilingual.Abtraction
{
    public class MultilingualString
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = "";
        public virtual ICollection<Translation> Translations { get; set; }
        public void SetTranslation(string language, string text)
        {
            if (Translations == null)
                Translations = new List<Translation>();

            var found = Translations.Where(t => t.Language.Equals(language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (found == null)
                Translations.Add(new Translation() { Language = language, Text = text });
            else
                found.Text = text;
        }

        public string Translate(string cultureName)
        {
            var translation = Translations?.Where(
                                     t => t.Language.Equals(cultureName)).FirstOrDefault();

            return translation == null ? Text : translation.Text;
        }
    }
}

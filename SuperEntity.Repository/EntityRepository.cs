

using SuperEntity.Abtraction.Models;
using SuperEntity.Abtraction.Models.Descriptors;
using System;
using System.Collections.Generic;

namespace SuperEntity.Repository
{
    public class EntityRepository : SuperEntity.Abtraction.Repositories.IEntityRepository
    {
        public IEnumerable<MultiLingualStringDescriptor> GetStringDescriptors()
        {
            return new List<MultiLingualStringDescriptor>() {
                CreateMultiLingualStringDescriptor("Venture.Tile")
            };
        }

        /// <summary>
        /// Json data
        /// </summary>
        private MultiLingualStringDescriptor CreateMultiLingualStringDescriptor(string key)
        {
            var value = new Abtraction.Models.Types.MultiLingualString();

            foreach (var language in GetSystemLanguages())
            {
                value.SetValue(language, $"Test {language.Code}");
            }
            return new MultiLingualStringDescriptor(key, value);
        }

        private IEnumerable<Language> GetSystemLanguages()
        {
            return new List<Language>()
            {
                SystemLanguages.English,
                SystemLanguages.GermanSwitzerland,
                SystemLanguages.FrenchSwitzerland
            };
        }
    }
}

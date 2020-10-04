using SuperEntity.Abtraction.Models;
using SuperEntity.Abtraction.Repositories;
using SuperEntity.Abtraction.Services;
using SuperEntity.Core.Factories;
using SuperEntity.Core.Models;
using SuperEntity.Core.Services;
using SuperEntity.Repository;
using System;
using System.Diagnostics;
using System.Globalization;
using Xunit;

namespace SuperEntity.Test
{
    public class TestCultures
    {
        [Fact]
        public void ExportAllCultures()
        {
            Trace.WriteLine("CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME");
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                Trace.WriteLine("==========================");
                Trace.Write($"Name.${ci.Name}");
                Trace.Write(ci.TwoLetterISOLanguageName);
                Trace.Write(ci.ThreeLetterISOLanguageName);
                Trace.Write(ci.ThreeLetterWindowsLanguageName);
                Trace.Write(ci.DisplayName);
                Trace.WriteLine(ci.EnglishName);
            }
            Assert.True(true);
            /*
            This code produces the following output.  This output has been cropped for brevity.

            CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME
            ar      ar  ara ARA Arabic                                   Arabic
            bg      bg  bul BGR Bulgarian                                Bulgarian
            ca      ca  cat CAT Catalan                                  Catalan
            zh-Hans zh  zho CHS Chinese (Simplified)                     Chinese (Simplified)
            cs      cs  ces CSY Czech                                    Czech
            da      da  dan DAN Danish                                   Danish
            de      de  deu DEU German                                   German
            el      el  ell ELL Greek                                    Greek
            en      en  eng ENU English                                  English
            es      es  spa ESP Spanish                                  Spanish
            fi      fi  fin FIN Finnish                                  Finnish
            zh      zh  zho CHS Chinese                                  Chinese
            zh-Hant zh  zho CHT Chinese (Traditional)                    Chinese (Traditional)
            zh-CHS  zh  zho CHS Chinese (Simplified) Legacy              Chinese (Simplified) Legacy
            zh-CHT  zh  zho CHT Chinese (Traditional) Legacy             Chinese (Traditional) Legacy

            */
        }

        [Fact]
        public void TestMultiLingual()
        {
            var venture = new Venture();
            var title = "tententen";
            venture.SetTitle(title);

            Assert.True(title.Equals(venture.Title.ToString()));

            venture.SetCurrentLanguage(SystemLanguages.FrenchSwitzerland);

            var title1 = "blar blar";
            venture.SetTitle(title1);

            Assert.True(title1.Equals(venture.Title.ToString()));
        }

        [Fact]
        public void TestCreateVentureUsingFactory()
        {
            IEntityRepository entityRepository = new EntityRepository();
            IEntityService entityService = new EntityService(entityRepository);
            IEntityFactory entityFactory = new EntityFactory(entityService);

            var venture = entityFactory.CreateVenture();

            Assert.True(venture.Title.Descriptor.Value != null);


            var venture2 = entityFactory.CreateVenture(SystemLanguages.FrenchSwitzerland);

            Assert.True(venture.Title.Descriptor.Value != null);
        }
    }
}

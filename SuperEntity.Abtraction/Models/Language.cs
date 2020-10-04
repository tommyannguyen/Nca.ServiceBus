
using System;

namespace SuperEntity.Abtraction.Models
{
    /// <summary>
    /// https://www.andiamo.co.uk/resources/iso-language-codes/
    /// </summary>
    public class Language
    {
        public Language(string code, string region)
        {
            Code = code;
            Region = region;
        }
        public string Region { get; } = "";
        public string Code { get; } = "";

        public override bool Equals(object obj)
        {
            if(obj is Language refLanguage)
                return Code.Equals(refLanguage.Code);

            throw new ArgumentOutOfRangeException();
        }
    }
}

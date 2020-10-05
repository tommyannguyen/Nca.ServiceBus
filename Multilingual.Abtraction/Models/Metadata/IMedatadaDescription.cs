using Multilingual.Abtraction.Types;
using System;
using System.Diagnostics.Contracts;

namespace Multilingual.Abtraction.Models.Metadata
{
    public interface IMedatadaDescription
    {
        string PropertyName { get; set; }
    }
    public interface IMedatadaDescription<T>: IMedatadaDescription
    {
        MultilingualString DisplayName { get; }
        bool IsCustom { get; set; }
        Type Type { get; }
    }
}

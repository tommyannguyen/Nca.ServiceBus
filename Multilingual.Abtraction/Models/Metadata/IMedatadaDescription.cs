using System;

namespace Multilingual.Abtraction.Models.Metadata
{
    public interface IMedatadaDescription
    {

    }
    public interface IMedatadaDescription<T>: IMedatadaDescription
    {
        Guid Id { get; }
        MultilingualString Name { get; }
        bool IsCustom { get; set; }
        Type Type { get; }
    }
}

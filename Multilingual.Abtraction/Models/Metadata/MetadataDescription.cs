using System;

namespace Multilingual.Abtraction.Models.Metadata
{
    public abstract class MetadataDescription<T> : IMedatadaDescription<T>
    {
        public Guid Id { get; set; }
        public MultilingualString Name { get; set; }
        public WidgetType WidgetType { get; set; }

        public Type Type => typeof(T);
        public bool IsCustom { get; set; }
    }
}

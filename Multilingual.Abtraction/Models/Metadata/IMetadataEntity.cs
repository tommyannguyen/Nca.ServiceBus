using System.Collections.Generic;

namespace Multilingual.Abtraction.Models.Metadata
{
    public interface IMetadataEntity : IEntity
    {
        IEnumerable<IProperty> Metadatas { get; set; }
    }
}

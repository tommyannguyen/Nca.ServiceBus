using System.Collections.Generic;

namespace Multilingual.Abtraction.Models.Metadata
{
    public class MetadataEntity : IMetadataEntity
    {
        public IEnumerable<IMetadataValue> Metadatas { get; set; }
    }

    public interface IMetadataEntity : IEntity
    {
        IEnumerable<IMetadataValue> Metadatas { get; set; }
    }
}

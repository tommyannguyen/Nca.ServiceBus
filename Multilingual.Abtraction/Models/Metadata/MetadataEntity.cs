using System.Collections.Generic;

namespace Multilingual.Abtraction.Models.Metadata
{
    public class MetadataEntity : IMetadataEntity
    {
        public MetadataEntity(IEnumerable<IProperty> metadatas)
        {
            this.Metadatas = metadatas;
        }
        public IEnumerable<IProperty> Metadatas { get; set; }
    }
}

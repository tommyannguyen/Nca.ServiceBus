using System.Collections.Generic;

namespace Multilingual.Abtraction.Models.Metadata
{
    public class MetadataEntityRelation
    {
        public IMetadataEntity Entity { get; set; }
        public IEnumerable<IMedatadaDescription> MedatadaDescriptions { get; set; }
    }
}

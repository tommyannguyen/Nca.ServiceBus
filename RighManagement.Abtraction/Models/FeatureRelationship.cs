using System.Collections.Generic;

namespace RighManagement.Abtraction.Models
{
    public class FeatureRelationship
    {
        public Feature From { get; set; }
        public Feature To { get; set; }
        public IList<Right> Rights { get; set; }
    }
}

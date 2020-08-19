using System.Collections.Generic;
using System.Net.Http.Headers;

namespace RighManagement.Abtraction.Models
{
    public class RelationshipTree
    {
        public Feature From { get; set; }
        public Feature To { get; set; }

        public IList<ListFeatureRelationship> Relationships { get; set; } 
    }
}

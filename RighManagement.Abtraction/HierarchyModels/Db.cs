using RighManagement.Abtraction.Models;
using System.Collections.Generic;

namespace RighManagement.Abtraction.HierarchyModels
{
    public class Db
    {
        public IList<User> Users { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<Tenant> Tenants { get; set; }

        public IList<FeatureRelationship> FeatureRelationships { get; set; }
    }
}

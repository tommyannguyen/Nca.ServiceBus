using RighManagement.Abtraction.Models;
using System.Collections.Generic;

namespace RighManagement.Abtraction
{
    public interface IRightManager
    {
        RelationshipTree GetRelationshipTree(Feature from, Feature to);
        IList<Right> GetRights(Feature from, Feature to);
    }
}

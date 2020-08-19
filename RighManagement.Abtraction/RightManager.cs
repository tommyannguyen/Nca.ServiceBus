using RighManagement.Abtraction.HierarchyModels;
using RighManagement.Abtraction.Models;
using System.Collections.Generic;
using System.Linq;

namespace RighManagement.Abtraction
{
    public class RightManager : IRightManager
    {
        private readonly Db _db;

        public RightManager(Db db)
        {
            _db = db;
        }
        public IList<Right> GetRights(Feature from, Feature to)
        {

            return null;
        }

        public RelationshipTree GetRelationshipTree(Feature from, Feature to)
        {
            throw new System.NotImplementedException();
        }

        private bool FindNestedFrom(Feature from, Feature to)
        {
            var fromRelationships = _db.FeatureRelationships.Where(f => f.From.GetType() == from.GetType() && f.From.Id == from.Id);
            foreach(var fromRelationship in fromRelationships)
            {
                var isTo = fromRelationship.To.GetType() == to.GetType() && fromRelationship.To.Id == to.Id;
                if (isTo)
                {
                    return true;
                }
                else
                {
                    return FindNestedFrom(fromRelationship.To, to);
                }
            }
            return false;
        }
    }
}

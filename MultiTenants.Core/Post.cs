using MultiTenants.Abtraction;
using System.Collections.Generic;

namespace MultiTenants.Core
{
    public class Post : IEntity, IHavingComment, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public IEnumerable<IComment> Comments { get; set; }
    }
}

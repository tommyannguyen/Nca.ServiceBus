using MultiTenants.Abtraction;

namespace MultiTenants.Core
{
    public class Comment : IEntity, IComment
    {
        public int? TenantId { get; set; }
    }
}

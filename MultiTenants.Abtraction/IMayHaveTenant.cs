namespace MultiTenants.Abtraction
{
    /// <summary>
    /// Entity belong to tenant or All
    /// </summary>
    public interface IMayHaveTenant
    {
        int? TenantId { get; }
    }
}

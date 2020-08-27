namespace MultiTenants.Abtraction
{
    /// <summary>
    /// Entity belong to 1 tenant
    /// </summary>
    public interface IMustHaveTenant
    {
        int TenantId { get; }
    }
}

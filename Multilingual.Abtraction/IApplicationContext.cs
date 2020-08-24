namespace Multilingual.Abtraction
{
    public interface IApplicationContext
    {
        string CurrentCulture { get; set; }
        int TenantId { get; set; }
    }
}

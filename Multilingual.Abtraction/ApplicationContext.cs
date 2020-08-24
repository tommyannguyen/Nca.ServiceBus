namespace Multilingual.Abtraction
{
    public class ApplicationContext : IApplicationContext
    {
        public string CurrentCulture { get; set; }
        public int TenantId { get; set; }
    }
}

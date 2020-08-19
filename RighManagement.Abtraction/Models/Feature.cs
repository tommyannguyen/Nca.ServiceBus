namespace RighManagement.Abtraction.Models
{
    public abstract class Feature
    {
        public string Id { get; set; }

        public Feature Parent { get; set; }
    }
}

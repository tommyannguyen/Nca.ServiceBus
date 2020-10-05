
namespace SuperEntity.Core.Models
{
    public class Venture : MultilingualEntity
    {
        public VentureTile Title { get; set; } = new VentureTile();
        public void SetTitle(string value)
        {
            Title.Value.SetValue(MultilingualContext.CurrentLanguage, value);
        }
    }
}

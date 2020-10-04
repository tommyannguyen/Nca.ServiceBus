namespace SuperEntity.Abtraction.Models.Types
{
    public class MultileLingualValue
    {
        public MultileLingualValue(Language language, string value)
        {
            Language = language;
            Value = value;
        }
        public Language Language { get; private set; }
        public string Value { get; private set; }

        public void SetValue(string value)
        {
            Value = value;
        }
    }
}

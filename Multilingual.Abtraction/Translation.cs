using System;

namespace Multilingual.Abtraction
{
    public class Translation
    {
        public Guid Id { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
        public bool IsAutomatic { get; set; } = false;
    }
}

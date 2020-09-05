using System;

namespace Multilingual.Abtraction
{
    public class Product: IEntity
    {
        public Guid Id { get; set; }
        public MultilingualString ProductName { get; set; }// string
    }
}

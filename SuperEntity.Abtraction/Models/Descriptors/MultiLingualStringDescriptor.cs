using SuperEntity.Abtraction.Models.Types;
using System.Collections.Generic;

namespace SuperEntity.Abtraction.Models.Descriptors
{
    /// <summary>
    /// Static text in system
    /// </summary>
    public class MultiLingualStringDescriptor : IEntityPropertyDescriptor
    {
        public MultiLingualStringDescriptor(string key, MultiLingualString value = null)
        {
            Key = key;

            Value = value;
        }
        public string Key { get; private set; }
        public MultiLingualString Value { get; private set; }

        public void UpdateValue(MultiLingualString value)
        {
            Value = value;
        }
    }
}

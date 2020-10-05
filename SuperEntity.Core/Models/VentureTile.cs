using SuperEntity.Abtraction.Models;
using SuperEntity.Abtraction.Models.Descriptors;
using SuperEntity.Abtraction.Models.Types;

namespace SuperEntity.Core.Models
{
    public class VentureTile : IEntityProperty<MultiLingualStringDescriptor, MultiLingualString>
    {
        public MultiLingualStringDescriptor Descriptor { get; } = new MultiLingualStringDescriptor("Venture.Tile");

        public MultiLingualString Value { get; } = new MultiLingualString();

        public EntityMultilingualContext MultilingualContext { get;}

        public override string ToString()
        {
            return Value.Value;
        }
    }
}

using System.Collections.Generic;

namespace Multilingual.Abtraction.Dto
{
    public class AddProductDto
    {
        public IEnumerable<MultilingualDto<AddProductInfoDto>> Data { get; set; }
    }
    public class AddProductInfoDto
    {
        public string Name { get; set; }
    }
}

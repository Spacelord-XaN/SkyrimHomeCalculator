using System.Collections.Generic;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class CompoundMaterial
        : RawMaterial
    {

        [XmlAttribute]
        public MaterialType Type { get; set; }

        public List<MaterialUsage> UsedMaterials { get; } = new List<MaterialUsage>();
    }
}

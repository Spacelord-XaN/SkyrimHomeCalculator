using System.Collections.Generic;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class BlueprintGroup
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement(nameof(Blueprint))]
        public List<Blueprint> Parts { get; } = new List<Blueprint>();
    }
}

using System.Collections.Generic;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class RoomConfiguration
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string MaterialName { get; set; }

        public List<BlueprintGroup> Interior { get; set; } = new List<BlueprintGroup>();
    }
}

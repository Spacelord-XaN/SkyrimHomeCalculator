using System.Collections.Generic;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class RoomBlueprint
        : Blueprint
    {
        [XmlAttribute]
        public string Name { get; set; }

        public List<BlueprintGroup> Interior { get; } = new List<BlueprintGroup>();
    }
}

using System.Collections.Generic;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class HouseConfiguration
    {
        public List<string> ExteriorParts { get; set; } = new List<string>();

        [XmlElement("Location")]
        public string Location { get; set; }

        public List<WingConfiguration> Wings { get; set; } = new List<WingConfiguration>();
    }
}

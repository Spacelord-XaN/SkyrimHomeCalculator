using System.Collections.Generic;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class WingConfiguration
    {
        [XmlAttribute]
        public string Direction { get; set; }

        public List<string> MaterialNames { get; } = new List<string>();
    }
}

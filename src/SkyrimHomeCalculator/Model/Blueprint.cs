using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class Blueprint
    {
        [XmlAttribute]
        public string MaterialName { get; set; }
    }
}

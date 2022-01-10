using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class RawMaterial
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}

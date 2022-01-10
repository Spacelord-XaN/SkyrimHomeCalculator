using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class MaterialUsage
    {
        public static MaterialUsage Unknown(string name) => new MaterialUsage { MaterialName = $"# Material not found: {name}" };

        [XmlAttribute]
        public string MaterialName { get; set; }

        [XmlAttribute]
        public decimal Amount { get; set; }
    }
}

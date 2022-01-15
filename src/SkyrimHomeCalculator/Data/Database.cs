using SkyrimHomeCalculator.Model;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Data
{
    public class Database
    {
        public MaterialCollection GetMaterialCollection() => Deserialize<MaterialCollection>("MaterialCollection.xml");

        public HouseBlueprint GetBlueprint() => Deserialize<HouseBlueprint>("HouseBlueprint.xml");

        private static T Deserialize<T>(string fileName) where T : class
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return xmlSerializer.Deserialize(fileStream) as T;
            }
        }

        public static void Serialize<T>(T instance, string fileName) where T : class
        {
            var settings = new XmlWriterSettings
            {
                Indent = true
            };

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (var xmlWriter = XmlWriter.Create(fileStream, settings))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(xmlWriter, instance);
            }
        }
    }
}

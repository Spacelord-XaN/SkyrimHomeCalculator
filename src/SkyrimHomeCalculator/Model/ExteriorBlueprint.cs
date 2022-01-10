using System;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class ExteriorBlueprint
        : Blueprint
    {
        [XmlAttribute]
        public string ExclusiveLocation { get; set; }

        public bool HasLocationConstraint() => !string.IsNullOrEmpty(ExclusiveLocation);

        public bool IsAllowed(string location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));

            if (HasLocationConstraint())
            {
                return ExclusiveLocation == location;
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SkyrimHomeCalculator.Model
{
    public class HouseBlueprint
    {
        public List<ExteriorBlueprint> ExteriorParts { get; } = new List<ExteriorBlueprint>();

        public List<string> Locations { get; } = new List<string>();

        public List<WingBlueprint> Wings { get; } = new List<WingBlueprint>();

        public bool IsAllowed(string exteriorName, string location)
        {
            if (exteriorName == null) throw new ArgumentNullException(nameof(exteriorName));
            if (location == null) throw new ArgumentNullException(nameof(location));

            return ExteriorParts.Where(part => part.MaterialName == exteriorName).All(part => part.IsAllowed(location));
        }

        public IEnumerable<ExteriorBlueprint> GetAllowedExteriorParts(string location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));

            return ExteriorParts.Where(part => part.IsAllowed(location));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    public class WingBlueprint
    {
        [XmlAttribute]
        public string Direction { get; set; }

        [XmlElement(nameof(RoomBlueprint))]
        public List<RoomBlueprint> Rooms { get; } = new List<RoomBlueprint>();

        public IEnumerable<BlueprintGroup> GetInteriorGroups(string roomConfigurationName)
        {
            if (roomConfigurationName == null) throw new ArgumentNullException(nameof(roomConfigurationName));

            return GetRoomBlueprint(roomConfigurationName).Interior;
        }

        public string GetRoomMaterialName(string roomConfigurationName)
        {
            if (roomConfigurationName == null) throw new ArgumentNullException(nameof(roomConfigurationName));

            return GetRoomBlueprint(roomConfigurationName).MaterialName;
        }

        public RoomBlueprint GetRoomBlueprint(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return Rooms.First(X => X.Name == name);
        }

        public IEnumerable<string> GetRoomNames()
        {
            return Rooms.Select(X => X.Name);
        }
    }
}

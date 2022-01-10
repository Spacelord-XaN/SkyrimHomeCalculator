using SkyrimHomeCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkyrimHomeCalculator.ViewModel
{
    public class WingViewModel : ConfigurationViewModel
    {
        private readonly WingBlueprint _blueprint;
        private string _roomConfigurationName;

        public WingViewModel(WingBlueprint blueprint)
        {
            _blueprint = blueprint ?? throw new ArgumentNullException(nameof(blueprint));
            _roomConfigurationName = RoomConfigurationNames.First();
            InteriorList = new InteriorListViewModel(_blueprint);
            InteriorList.ConfigurationChanged += InteriorListConfigurationChanged;

            UpdateRoomConfiguration();
        }

        public WingConfiguration GetConfiguration()
        {
            var config = new WingConfiguration
            {
                Direction = _blueprint.Direction
            };
            var roomMaterialName = _blueprint.GetRoomMaterialName(RoomConfigurationName);
            if (roomMaterialName != null)
            {
                config.MaterialNames.Add(roomMaterialName);                
            }
            config.MaterialNames.AddRange(InteriorList.GetMaterialNames());
            return config;
        }

        public void SetIsCheckedState(bool state)
        {
            DisableConfigurationChangedEvent();

            InteriorList.SetIsCheckedState(state);

            EnabledConfigurationChangedEvent();
            RaiseConfigurationChanged();
        }

        private void InteriorListConfigurationChanged(object sender, EventArgs args)
        {
            RaiseConfigurationChanged();
        }

        private void UpdateRoomConfiguration()
        {
            InteriorList.UpdateRoomConfiguration(RoomConfigurationName);
        }

        public string Direction
        {
            get
            {
                return _blueprint.Direction;
            }
        }

        public InteriorListViewModel InteriorList
        {
            get;
            private set;
        }

        public IEnumerable<string> RoomConfigurationNames
        {
            get
            {
                return _blueprint.GetRoomNames();
            }
        }

        public string RoomConfigurationName
        {
            get
            {
                return _roomConfigurationName;
            }
            set
            {
                _roomConfigurationName = value;
                UpdateRoomConfiguration();
                RaisePropertyChagned("RoomConfigurationName");
                RaiseConfigurationChanged();
            }
        }
    }
}

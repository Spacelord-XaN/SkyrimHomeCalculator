using SkyrimHomeCalculator.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Input;
using SkyrimHomeCalculator.Data;

namespace SkyrimHomeCalculator.ViewModel
{
    public class HouseViewModel : ConfigurationViewModel, ICommand
    {
        private readonly HouseBlueprint _blueprint;
        private string _location;

        public event EventHandler CanExecuteChanged = delegate { };

        public HouseViewModel()
        {
            var db = new Database();
            _blueprint = db.GetBlueprint();

            ExteriorList = new ExteriorListViewModel(_blueprint);
            ExteriorList.ConfigurationChanged += ChildConfigurationChanged;
            WingList = new WingListViewModel(_blueprint);
            WingList.ConfigurationChanged += ChildConfigurationChanged;

            Location = Locations.First();
        }

        public HouseConfiguration GetConfiguration()
        {
            return new HouseConfiguration
            {
                Location = _location,
                ExteriorParts = ExteriorList.GetConfiguration(),
                Wings = WingList.GetConfiguration()
            };
        }

        public void Execute(object parameter)
        {
            var command = parameter as string;
            if (string.IsNullOrEmpty(command))
            {
                return;
            }
            command = command.ToLower();

            if (command == "all")
            {
                SetIsCheckedState(true);
            }
            else if (command == "none")
            {
                SetIsCheckedState(false);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private void ChildConfigurationChanged(object sender, EventArgs args)
        {
            RaiseConfigurationChanged();
        }

        private void SetIsCheckedState(bool state)
        {
            DisableConfigurationChangedEvent();

            ExteriorList.SetIsCheckedState(state);
            WingList.SetIsCheckedState(state);

            EnabledConfigurationChangedEvent();
            RaiseConfigurationChanged();
        }

        private void UpdateLocation()
        {
            ExteriorList.UpdateLocation(_location);
        }

        public ExteriorListViewModel ExteriorList { get; }

        public IEnumerable<string> Locations
        {
            get
            {
                return _blueprint.Locations;
            }
        }

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                UpdateLocation();
                RaisePropertyChagned("Location");
                RaiseConfigurationChanged();
            }
        }

        public WingListViewModel WingList { get; }
    }
}

using SkyrimHomeCalculator.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace SkyrimHomeCalculator.ViewModel
{
    public class InteriorListViewModel : ConfigurationViewModel
    {
        private readonly WingBlueprint _blueprint;

        public InteriorListViewModel(WingBlueprint blueprint)
        {
            _blueprint = blueprint ?? throw new ArgumentNullException(nameof(blueprint));
        }

        public IEnumerable<string> GetMaterialNames() => Groups.SelectMany(vm => vm.GetMaterialNames());

        public void SetIsCheckedState(bool state)
        {
            DisableConfigurationChangedEvent();

            foreach (InteriorGroupViewModel viewModel in Groups)
            {
                viewModel.SetIsCheckedState(state);
            }

            EnabledConfigurationChangedEvent();
            RaiseConfigurationChanged();
        }

        public void UpdateRoomConfiguration(string roomConfigurationName)
        {
            if (roomConfigurationName == null) throw new ArgumentNullException(nameof(roomConfigurationName));
            
            Groups.Clear();

            foreach (BlueprintGroup group in _blueprint.GetInteriorGroups(roomConfigurationName))
            {
                InteriorGroupViewModel viewModel = new InteriorGroupViewModel(group);
                viewModel.ConfigurationChanged += ChildConfigurationChanged;
                Groups.Add(viewModel);
            }
        }

        private void ChildConfigurationChanged(object sender, EventArgs args)
        {
            RaiseConfigurationChanged();
        }

        public ObservableCollection<InteriorGroupViewModel> Groups { get; } = new ObservableCollection<InteriorGroupViewModel>();
    }
}

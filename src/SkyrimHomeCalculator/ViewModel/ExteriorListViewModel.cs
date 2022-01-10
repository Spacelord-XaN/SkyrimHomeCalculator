using SkyrimHomeCalculator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SkyrimHomeCalculator.ViewModel
{
    public class ExteriorListViewModel : ConfigurationViewModel
    {
        private readonly HouseBlueprint _blueprint;

        public ExteriorListViewModel(HouseBlueprint blueprint)
        {
            _blueprint = blueprint ?? throw new ArgumentNullException(nameof(blueprint));
        }

        public List<string> GetConfiguration()
        {
            var list = new List<string>();
            foreach (var viewModel in Items)
            {
                if (viewModel.IsChecked)
                {
                    list.Add(viewModel.Name);
                }
            }
            return list;
        }

        public void SetIsCheckedState(bool state)
        {
            DisableConfigurationChangedEvent();

            foreach (var viewModel in Items)
            {
                viewModel.IsChecked = state;
            }

            EnabledConfigurationChangedEvent();
            RaiseConfigurationChanged();
        }

        public void UpdateLocation(string location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));

            var toRemove = new List<ExteriorViewModel>();
            foreach (var viewModel in Items)
            {
                if (_blueprint.IsAllowed(viewModel.Name, location))
                {
                    continue;
                }
                toRemove.Add(viewModel);
            }

            foreach (var viewModel in toRemove)
            {
                Items.Remove(viewModel);
            }

            foreach (var part in _blueprint.GetAllowedExteriorParts(location))
            {
                if (ContainsViewModel(part))
                {
                    continue;
                }
                var viewModel = new ExteriorViewModel(part);
                viewModel.ConfigurationChanged += ChildConfigurationChanged;
                Items.Add(viewModel);
            }
        }

        private void ChildConfigurationChanged(object sender, EventArgs args)
        {
            RaiseConfigurationChanged();
        }

        private bool ContainsViewModel(ExteriorBlueprint part)
        {
            return Items.Any(vm => vm.EqualsModel(part));
        }

        public ObservableCollection<ExteriorViewModel> Items { get; } = new ObservableCollection<ExteriorViewModel>();
    }
}

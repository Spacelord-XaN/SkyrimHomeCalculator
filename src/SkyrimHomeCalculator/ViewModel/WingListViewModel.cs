using SkyrimHomeCalculator.Model;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace SkyrimHomeCalculator.ViewModel
{
    public class WingListViewModel : ConfigurationViewModel
    {
        private readonly HouseBlueprint _blueprint;

        public WingListViewModel(HouseBlueprint blueprint)
        {
            _blueprint = blueprint ?? throw new ArgumentNullException(nameof(blueprint));
            Items = new ObservableCollection<WingViewModel>();

            foreach (var wingBlueprint in _blueprint.Wings)
            {
                WingViewModel viewModel = new WingViewModel(wingBlueprint);
                viewModel.ConfigurationChanged += WingConfigurationChanged;
                Items.Add(viewModel);
            }
        }

        public List<WingConfiguration> GetConfiguration()
        {
            var list = new List<WingConfiguration>();
            foreach (var viewModel in Items)
            {
                list.Add(viewModel.GetConfiguration());
            }
            return list;
        }

        public void SetIsCheckedState(bool State)
        {
            DisableConfigurationChangedEvent();

            foreach (var viewModel in Items)
            {
                viewModel.SetIsCheckedState(State);
            }

            EnabledConfigurationChangedEvent();
            RaiseConfigurationChanged();
        }

        private void WingConfigurationChanged(object sender, EventArgs args)
        {
            RaiseConfigurationChanged();
        }

        public ObservableCollection<WingViewModel> Items { get; } = new ObservableCollection<WingViewModel>();
    }
}

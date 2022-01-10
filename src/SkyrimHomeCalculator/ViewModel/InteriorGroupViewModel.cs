using SkyrimHomeCalculator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SkyrimHomeCalculator.ViewModel
{
    public class InteriorGroupViewModel : ConfigurationViewModel
    {
        private readonly BlueprintGroup _group;

        public InteriorGroupViewModel(BlueprintGroup group)
        {
            _group = group ?? throw new ArgumentNullException(nameof(group));

            foreach (var part in _group.Parts)
            {
                InteriorViewModel viewModel = new InteriorViewModel(part);
                viewModel.ConfigurationChanged += ChildConfigurationChanged;
                Parts.Add(viewModel);
            }
        }

        public IEnumerable<string> GetMaterialNames() => Parts.Where(vm => vm.IsChecked).Select(vm => vm.Name);

        public void SetIsCheckedState(bool state)
        {
            DisableConfigurationChangedEvent();

            foreach (var viewModel in Parts)
            {
                viewModel.IsChecked = state;
            }

            EnabledConfigurationChangedEvent();
            RaiseConfigurationChanged();
        }

        private void ChildConfigurationChanged(object sender, EventArgs args)
        {
            RaiseConfigurationChanged();
        }

        public string Name
        {
            get
            {
                return _group.Name;
            }
        }

        public ObservableCollection<InteriorViewModel> Parts { get; } = new ObservableCollection<InteriorViewModel>();
    }
}

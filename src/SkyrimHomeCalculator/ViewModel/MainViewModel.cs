using System;

namespace SkyrimHomeCalculator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            House.ConfigurationChanged += HouseConfigurationChanged;
            UpdateMaterialLists();
        }

        private void HouseConfigurationChanged(object Sender, EventArgs Args)
        {
            UpdateMaterialLists();
        }

        private void UpdateMaterialLists()
        {
            Materials.UpdateMaterialLists(House.GetConfiguration());
        }

        public HouseViewModel House { get; } = new HouseViewModel();

        public MaterialsViewModel Materials { get; } = new MaterialsViewModel();
    }
}

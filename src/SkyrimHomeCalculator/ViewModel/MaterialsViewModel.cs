using SkyrimHomeCalculator.Logic;
using SkyrimHomeCalculator.Model;

namespace SkyrimHomeCalculator.ViewModel
{
    public class MaterialsViewModel : ViewModelBase
    {
        private readonly MaterialCalculator _materialCalculator = new MaterialCalculator();
        public MaterialsViewModel()
        {
            RawMaterialList = new MaterialListViewModel(_materialCalculator.GetRawMaterials);
            BaseMaterialList = new MaterialListViewModel(_materialCalculator.GetBaseMaterials);
        }

        public void UpdateMaterialLists(HouseConfiguration houseConfiguration)
        {
            RawMaterialList.Update(houseConfiguration);
            BaseMaterialList.Update(houseConfiguration);
        }

        public MaterialListViewModel RawMaterialList { get; }

        public MaterialListViewModel BaseMaterialList { get; }
    }
}

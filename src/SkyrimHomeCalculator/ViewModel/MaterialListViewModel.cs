using SkyrimHomeCalculator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SkyrimHomeCalculator.ViewModel
{
    public class MaterialListViewModel : ObservableCollection<PartViewModel>
    {
        private readonly Func<HouseConfiguration, IDictionary<string, decimal>> _getMaterialsFunc;

        public MaterialListViewModel(Func<HouseConfiguration, IDictionary<string, decimal>> getMaterialsFunc)
        {
            _getMaterialsFunc = getMaterialsFunc ?? throw new ArgumentNullException(nameof(getMaterialsFunc));
        }

        public void Update(HouseConfiguration configuration)
        {
            Clear();

            var rawMaterials = _getMaterialsFunc(configuration);
            foreach (var material in rawMaterials.OrderBy(m => m.Key))
            {
                Add(new PartViewModel(material.Key, material.Value));
            }
        }
    }
}

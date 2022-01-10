using SkyrimHomeCalculator.Model;
using SkyrimHomeCalculator.Data;
using System.Collections.Generic;
using System;

namespace SkyrimHomeCalculator.Logic
{
    public class MaterialCalculator
    {
        private readonly MaterialCollection _materialCollection = new MaterialCollection();

        public MaterialCalculator()
        {
            var db = new Database();
            _materialCollection = db.GetMaterialCollection();
        }

        public IDictionary<string, decimal> GetRawMaterials(HouseConfiguration houseConfiguration)
        {
            if (houseConfiguration == null) throw new ArgumentNullException(nameof(houseConfiguration));

            var result = new Dictionary<string, decimal>();

            foreach (var usage in GetMaterialUsage(houseConfiguration))
            {
                var rawMaterials = _materialCollection.GetRawMaterials(usage.MaterialName);
                result.Add(rawMaterials, usage.Amount);
            }

            return result;
        }

        public IDictionary<string, decimal> GetBaseMaterials(HouseConfiguration houseConfiguration)
        {
            if (houseConfiguration == null) throw new ArgumentNullException(nameof(houseConfiguration));

            var result = new Dictionary<string, decimal>();

            foreach (var usage in GetMaterialUsage(houseConfiguration))
            {
                var baseMaterials = _materialCollection.GetBaseMaterials(usage.MaterialName);
                result.Add(baseMaterials, usage.Amount);
            }

            return result;
        }

        public IEnumerable<MaterialUsage> GetMaterialUsage(HouseConfiguration houseConfiguration)
        {
            if (houseConfiguration == null) throw new ArgumentNullException(nameof(houseConfiguration));

            var usages = new List<MaterialUsage>();
            foreach (var exteriorPart in houseConfiguration.ExteriorParts)
            {
                usages.AddRange(GetMaterialUsage(exteriorPart));
            }

            foreach (var wing in houseConfiguration.Wings)
            {
                foreach (var materialName in wing.MaterialNames)
                {
                    usages.AddRange(GetMaterialUsage(materialName));
                }
            }
            return usages;
        }

        private IEnumerable<MaterialUsage> GetMaterialUsage(string name)
        {
            var usages = new List<MaterialUsage>();
            if (_materialCollection.RawMaterials.Contains(name))
            {
                usages.Add(new MaterialUsage { MaterialName = name, Amount = 1 });
            }
            else
            {
                var compound = _materialCollection.CompoundMaterials.FirstOrDefault(name);
                if (compound != null)
                {
                    usages.Add(new MaterialUsage { MaterialName = name, Amount = 1 });
                }
                else
                {
                    usages.Add(MaterialUsage.Unknown(name));
                }
            }
            return usages;
        }
    }
}

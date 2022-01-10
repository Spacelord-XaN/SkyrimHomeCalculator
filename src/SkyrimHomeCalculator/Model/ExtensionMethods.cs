using System;
using System.Collections.Generic;
using System.Linq;

namespace SkyrimHomeCalculator.Model
{
    public static class ExtensionMethods
    {
        public static void Add(this IDictionary<string, decimal> materials, IDictionary<string, decimal> baseMaterials) => Add(materials, baseMaterials, 1);

        public static void Add(this IDictionary<string, decimal> materials, IDictionary<string, decimal> baseMaterials, decimal factor)
        {
            if (materials == null) throw new ArgumentNullException(nameof(materials));
            if (baseMaterials == null) throw new ArgumentNullException(nameof(baseMaterials));

            foreach (var baseMaterial in baseMaterials)
            {
                if (materials.ContainsKey(baseMaterial.Key))
                {
                    materials[baseMaterial.Key] += (baseMaterial.Value * factor);
                }
                else
                {
                    materials.Add(baseMaterial.Key, (baseMaterial.Value * factor));
                }
            }

        }

        public static bool Contains<TMaterial>(this IEnumerable<TMaterial> materials, string name)
            where TMaterial : RawMaterial
        {
            if (materials == null) throw new ArgumentNullException(nameof(materials));
            if (name == null) throw new ArgumentNullException(nameof(name));

            return materials.Any(m => m.Name == name);
        }

        public static TMaterial FirstOrDefault<TMaterial>(this IEnumerable<TMaterial> materials, string name)
            where TMaterial : RawMaterial
        {
            if (materials == null) throw new ArgumentNullException(nameof(materials));
            if (name == null) throw new ArgumentNullException(nameof(name));

            return materials.FirstOrDefault(m => m.Name == name);
        }
    }
}

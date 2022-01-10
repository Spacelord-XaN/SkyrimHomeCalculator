using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SkyrimHomeCalculator.Model
{
    [XmlInclude(typeof(RawMaterial))]
    [XmlInclude(typeof(CompoundMaterial))]
    public class MaterialCollection
    {
        public List<RawMaterial> RawMaterials { get; } = new List<RawMaterial>();

        public List<CompoundMaterial> CompoundMaterials { get; } = new List<CompoundMaterial>();

        public bool Contains(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return RawMaterials.Contains(name) || CompoundMaterials.Contains(name);
        }

        public IDictionary<string, decimal> GetBaseMaterials(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var baseMaterials = new Dictionary<string, decimal>();
            var compound = CompoundMaterials.FirstOrDefault(name);
            if (compound != null)
            {
                if (compound.Type == MaterialType.Base)
                {
                    baseMaterials.Add(compound.Name, 1);
                }
                foreach (var usage in compound.UsedMaterials)
                {
                    baseMaterials.Add(GetBaseMaterials(usage.MaterialName), usage.Amount);
                }
            }
            else if (!RawMaterials.Contains(name))
            {
                var notFound = MaterialUsage.Unknown(name);
                baseMaterials.Add(notFound.MaterialName, notFound.Amount);
            }

            return baseMaterials;
        }

        public IDictionary<string, decimal> GetRawMaterials(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var rawMaterials = new Dictionary<string, decimal>();
            if (RawMaterials.Contains(name))
            {
                rawMaterials.Add(name, 1);
            }
            else
            {
                var compound = CompoundMaterials.FirstOrDefault(name);
                if (compound != null)
                {
                    foreach (var usage in compound.UsedMaterials)
                    {
                        rawMaterials.Add(GetRawMaterials(usage.MaterialName), usage.Amount);
                    }
                }
                else
                {
                    var notFound = MaterialUsage.Unknown(name);
                    rawMaterials.Add(notFound.MaterialName, notFound.Amount);
                }
            }

            return rawMaterials;
        }
    }
}

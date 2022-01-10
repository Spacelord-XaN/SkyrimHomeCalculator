namespace SkyrimHomeCalculator.ViewModel
{
    public class PartViewModel
    {
        public PartViewModel(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public decimal Value { get;  }
    }
}

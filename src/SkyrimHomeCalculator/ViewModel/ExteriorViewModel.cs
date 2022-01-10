using SkyrimHomeCalculator.Model;
using System;

namespace SkyrimHomeCalculator.ViewModel
{
    public class ExteriorViewModel : ConfigurationViewModel
    {
        private readonly string _name;
        private bool _isChecked;

        public ExteriorViewModel(ExteriorBlueprint model)
        {
            _name = model.MaterialName ?? throw new ArgumentNullException(nameof(model));
        }

        public bool EqualsModel(ExteriorBlueprint part)
        {
            if (part == null) throw new ArgumentNullException(nameof(part));

            return _name == part.MaterialName;
        }

        public ExteriorBlueprint GetModel()
        {
            return new ExteriorBlueprint()
            {
                MaterialName = _name
            };
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                RaisePropertyChagned("IsChecked");
                RaiseConfigurationChanged();
            }
        }
    }
}

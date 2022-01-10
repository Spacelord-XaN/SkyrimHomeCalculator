using SkyrimHomeCalculator.Model;
using System;

namespace SkyrimHomeCalculator.ViewModel
{
    public class InteriorViewModel : ConfigurationViewModel
    {
        private bool _isChecked;

        public InteriorViewModel(Blueprint model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            
            Name = model.MaterialName;
        }

        public string Name { get; }

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

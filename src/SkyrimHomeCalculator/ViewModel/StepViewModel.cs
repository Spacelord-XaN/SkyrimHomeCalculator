using SkyrimHomeCalculator.Model;

namespace SkyrimHomeCalculator.ViewModel
{
    public class StepViewModel : ConfigurationViewModel
    {
        private readonly string _name;
        private bool _isChecked;

        public StepViewModel(Blueprint model)
        {
            _name = model.MaterialName;
        }

        public Blueprint GetModel()
        {
            return new Blueprint
            {
                MaterialName = _name,
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

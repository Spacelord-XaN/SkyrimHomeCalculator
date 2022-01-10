using System;

namespace SkyrimHomeCalculator.ViewModel
{
    public class ConfigurationViewModel : ViewModelBase
    {
        public event EventHandler<EventArgs> ConfigurationChanged = delegate { };

        private bool _isConfigurationChangedEnabled = true;

        protected void DisableConfigurationChangedEvent()
        {
            _isConfigurationChangedEnabled = true;
        }

        protected void EnabledConfigurationChangedEvent()
        {
            _isConfigurationChangedEnabled = true;
        }

        protected void RaiseConfigurationChanged()
        {
            if (_isConfigurationChangedEnabled)
            {
                ConfigurationChanged(this, EventArgs.Empty);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace BodyControlApp.Pages.Settings
{
    class SettingsPageViewModel : BaseViewModel
    {       
        public bool Vibrate
        {
            get => AppSettings.Vibrate;
            set
            {
                AppSettings.Vibrate = value;
                OnPropertyChanged();
            }
        }

        private ICommand _changeThemeCommand;

        public ICommand ChangeThemeCommand
        {
            get => _changeThemeCommand;
            set
            {
                _changeThemeCommand = value;
                OnPropertyChanged();
            }
        }
    }
}

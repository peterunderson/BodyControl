using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
    }
}

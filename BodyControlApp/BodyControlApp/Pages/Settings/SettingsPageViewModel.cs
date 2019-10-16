using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BodyControlApp.Pages.Settings
{
    class SettingsPageViewModel : BasicViewModel, INotifyPropertyChanged
    {       
        public bool Vibrate
        {
            get => AppSettings.Vibrate;
            set
            {
                AppSettings.Vibrate = value;
                OnPropertyChanged(nameof(Vibrate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

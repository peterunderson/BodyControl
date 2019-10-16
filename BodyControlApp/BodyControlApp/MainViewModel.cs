using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BodyControlApp
{
    class MainViewModel :INotifyPropertyChanged
    {
        private string _homeIconSource;
        public string HomeIconSource
        {
            get => _homeIconSource;
            set
            {
                _homeIconSource = value;
                OnPropertyChanged(nameof(HomeIconSource));                
            }
        }      

        private string _chartIconSource;
        public string ChartIconSource
        {
            get => _chartIconSource;
            set
            {
                _chartIconSource = value;
                OnPropertyChanged(nameof(ChartIconSource));                
            }
        }

        private string _settingsIconSource;
        public string SettingsIconSource
        {
            get => _settingsIconSource;
            set
            {
                _settingsIconSource = value;
                OnPropertyChanged(nameof(SettingsIconSource));              
            }
        }

        private string _headerImageSource;
        public string HeaderImageSource
        {
            get => _headerImageSource;
            set
            {
                _headerImageSource = value;
                OnPropertyChanged(nameof(HeaderImageSource));                
            }
        }        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BodyControlApp
{
    class MainViewModel :INotifyPropertyChanged
    {
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

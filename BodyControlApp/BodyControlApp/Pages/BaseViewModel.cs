using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using BodyControlApp.Annotations;

namespace BodyControlApp.Pages
{
    class BaseViewModel :INotifyPropertyChanged
    {
        private string _navBarImage;

        public string NavBarImage
        {
            get => _navBarImage;
            set
            {
                _navBarImage = value;
                OnPropertyChanged();
            }
        }

        private string _navBarTitle;

        public string NavBarText
        {
            get => _navBarTitle;
            set
            {
                _navBarTitle = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

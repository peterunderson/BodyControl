using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BodyControlApp.Pages.Home
{
    class HomePageViewModel : BasicViewModel, INotifyPropertyChanged
    {
        private ImageSource _penImageSource;
        public ImageSource PenImageSource
        {
            get => _penImageSource;
            set
            {
                _penImageSource = value;
                OnPropertyChanged(nameof(PenImageSource));
            }
        }

        private bool _contentViewIsVisible;
        public bool ContentViewIsVisible
        {
            get => _contentViewIsVisible;
            set
            {
                _contentViewIsVisible = value;
                OnPropertyChanged(nameof(ContentViewIsVisible));
            }
        }

        private ICommand _buttonPenCommand;
        public ICommand ButtonPenCommand
        {
            get => _buttonPenCommand;
            set
            {
                _buttonPenCommand = value;
                OnPropertyChanged(nameof(ButtonPenCommand));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

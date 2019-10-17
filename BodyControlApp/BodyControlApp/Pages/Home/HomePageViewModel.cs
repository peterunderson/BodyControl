using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BodyControlApp.Pages.Home
{
    class HomePageViewModel : BaseViewModel
    {
        private ImageSource _penImageSource;
        public ImageSource PenImageSource
        {
            get => _penImageSource;
            set
            {
                _penImageSource = value;
                OnPropertyChanged();
            }
        }

        private bool _contentViewIsVisible;
        public bool ContentViewIsVisible
        {
            get => _contentViewIsVisible;
            set
            {
                _contentViewIsVisible = value;
                OnPropertyChanged();
            }
        }

        private ICommand _buttonPenCommand;
        public ICommand ButtonPenCommand
        {
            get => _buttonPenCommand;
            set
            {
                _buttonPenCommand = value;
                OnPropertyChanged();
            }
        }
       
    }
}

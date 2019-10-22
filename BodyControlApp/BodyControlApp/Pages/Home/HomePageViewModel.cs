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
        private Image _penImage;
        public Image PenImage
        {
            get => _penImage;
            set
            {
                _penImage = value;
                OnPropertyChanged();
            }
        }

        private bool _popupIsOpen;
        public bool PopupIsOpen
        {
            get => _popupIsOpen;
            set
            {
                _popupIsOpen = value;
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

        private ICommand _buttonSaveCommand;
        public ICommand ButtonSaveCommand
        {
            get => _buttonSaveCommand;
            set
            {
                _buttonSaveCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get => _refreshCommand;
            set
            {
                _refreshCommand = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private double _weigthInputValue;
        public double WeigthInputValue
        {
            get => _weigthInputValue;
            set
            {
                _weigthInputValue = value;
                OnPropertyChanged();
            }
        }

        private DataTemplate _popupContentTemplate;
        public DataTemplate PopupContentTemplate
        {
            get => _popupContentTemplate;
            set
            {
                _popupContentTemplate = value;
                OnPropertyChanged();
            }
        }

        private int _popupWidth;
        public int PopupWidth
        {
            get => _popupWidth;
            set
            {
                _popupWidth = value;
                OnPropertyChanged();
            }
        }

        private int _popupHeight;
        public int PopupHeight
        {
            get => _popupHeight;
            set
            {
                _popupHeight = value;
                OnPropertyChanged();
            }
        }
    }
}

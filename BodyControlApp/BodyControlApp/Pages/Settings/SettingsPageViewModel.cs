using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ICommand _pickerSelectionChangedCommand;

        public ICommand PickerSelectionChangedCommand
        {
            get => _pickerSelectionChangedCommand;
            set
            {
                _pickerSelectionChangedCommand = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _pickerItemSource;

        public ObservableCollection<string> PickerItemSource
        {
            get => _pickerItemSource;
            set
            {
                _pickerItemSource = value;
                OnPropertyChanged();
            }
        }

        private string _pickerCurrentItem;

        public string PickerCurrentItem
        {
            get => _pickerCurrentItem;
            set
            {
                _pickerCurrentItem = value;
                OnPropertyChanged();
            }
        }

        private bool _pickerIsOpen;

        public bool PickerIsOpen
        {
            get => _pickerIsOpen;
            set
            {
                _pickerIsOpen = value;
                OnPropertyChanged();
            }
        }
    }
}

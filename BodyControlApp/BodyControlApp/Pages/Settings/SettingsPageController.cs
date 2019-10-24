using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database;
using BodyControlApp.MVVM;
using BodyControlApp.Themes;
using Xamarin.Forms;

namespace BodyControlApp.Pages.Settings
{
    public enum Themes
    {
        LightTheme,
        DarkTheme
    }

    [PageConfig("Settings", "Settings2.png", 5)]
    class SettingsPageController : IPageController
    {
        private SettingsPageViewModel _viewModel;
        private readonly SettingsPage _settingsPage;
        ICollection<ResourceDictionary> _mergedDictionaries = Application.Current.Resources.MergedDictionaries;

        public SettingsPageController(SettingsPage settingsPage)
        {
            this._settingsPage = settingsPage;
            LoadTheme();
            ServiceProvider.Current.OnBackButton += Current_OnBackButton;
        }

        private void Current_OnBackButton(object sender, BackButtonEventArgs e)
        {
            if (_viewModel.PickerIsOpen)
            {
                _viewModel.PickerIsOpen = false;
                e.Cancel = true;
            }
        }

        private void LoadTheme()
        {
            _mergedDictionaries.Clear();
            Enum.TryParse(AppSettings.ActiveTheme, out Themes theme);
            switch (theme)
            {
                case Themes.LightTheme:
                    _mergedDictionaries.Add(new LightTheme());
                    break;
                case Themes.DarkTheme:
                    _mergedDictionaries.Add(new DarkTheme());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public async Task<bool> LoadDataAsync(DataBaseController controller)
        {
            await Task.Delay(10);
            return true;
        }

        public void ExecuteInitializeViewModel(BaseViewModel viewModel)
        {
            _viewModel = viewModel as SettingsPageViewModel;
            _viewModel.ChangeThemeCommand = new DelegateCommand(ChangeTheme);
            _viewModel.PickerSelectionChangedCommand = new DelegateCommand(PickerSelectionChanged);
        }

        private void PickerSelectionChanged(object obj)
        {
            if (obj is Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
            {
                if (e.OldValue != null)
                {
                    AppSettings.ActiveTheme = e.NewValue.ToString();
                    LoadTheme();
                }
            }
        }

        private void ChangeTheme(object obj)
        {
            _viewModel.PickerItemSource = new ObservableCollection<string>() { nameof(LightTheme), nameof(DarkTheme) };
            _viewModel.PickerCurrentItem = AppSettings.ActiveTheme;
            _viewModel.PickerIsOpen = true;
            //ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            //if (mergedDictionaries != null)
            //{
            //    mergedDictionaries.Clear();

            //    var light = new DarkTheme();
            //    mergedDictionaries.Add(light);
            //}

            //}
        }
    }
}

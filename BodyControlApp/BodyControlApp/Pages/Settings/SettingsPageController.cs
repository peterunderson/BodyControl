using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database;
using BodyControlApp.MVVM;
using BodyControlApp.Themes;
using Xamarin.Forms;

namespace BodyControlApp.Pages.Settings
{
    [PageConfig("Settings", "Settings2.png", 4)]
    class SettingsPageController : IPageController
    {
        private readonly SettingsPage _settingsPage;

        public SettingsPageController(SettingsPage settingsPage)
        {
            this._settingsPage = settingsPage;            
        }
        public async Task<bool> LoadDataAsync(DataBaseController controller)
        {
            await Task.Delay(10);
            return true;
        }

        public void ExecuteInitializeViewModel(BaseViewModel viewModel)
        {
            var viewmodel = viewModel as SettingsPageViewModel;
            viewmodel.ChangeThemeCommand = new DelegateCommand(ChangeTheme);
        }

        private void ChangeTheme(object obj)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                var light = new DarkTheme();
                mergedDictionaries.Add(light);
            }

            }
    }
}

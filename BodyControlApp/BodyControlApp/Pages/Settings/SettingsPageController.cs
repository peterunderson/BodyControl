using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database;

namespace BodyControlApp.Pages.Settings
{
    [PageConfig("Settings", "Settings2.png","Settings2White.png", 4)]
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
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodyControlApp.Pages.Settings
{
    [FlyoutItem("Settings", "Settings2.png", 4)]
    class SettingsPageController : IPageController
    {
        private readonly SettingsPage _settingsPage;

        public SettingsPageController(SettingsPage settingsPage,SettingsPageViewModel settingsPageViewModel)
        {
            this._settingsPage = settingsPage;            
        }
        public async Task<bool> LoadDataAsync()
        {
            await Task.Delay(10);
            return true;
        }
    }
}

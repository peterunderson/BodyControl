using System;
using System.Collections.Generic;
using System.Text;
using BodyControlApp.Pages;
using Xamarin.Forms;
using System.Xml.Linq;
using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using BodyControlApp.Pages.Settings;
using BodyControlApp.Database;

namespace BodyControlApp
{
    class MainController
    {
        private readonly AppShell _appShell;
        private readonly PageManager _pageManager;
        private readonly MainViewModel _mainViewModel;
        private readonly DataBaseController _databaseController;

        public MainController(AppShell appShell, PageManager pageManager)
        {
            _appShell = appShell;
            _pageManager = pageManager;
            _mainViewModel = new MainViewModel();         
            _appShell.BindingContext = _mainViewModel;
            InitMainViewModel();
            ServiceProvider.Current.OnStart += Provider_OnStart;

            foreach (var item in _appShell.Items)
            {
                item.Appearing += Item_Appearing;
            }

            _databaseController = new DataBaseController();     
        }

        private async void Provider_OnStart(object sender, EventArgs e)
        {
            try
            {
                await _pageManager.FillPages(_databaseController);
            }
            catch (Exception ex)
            {
                await _appShell.DisplayAlert("Error lading Data", ex.Message, "Cancel");
            }
        }

        private void Item_Appearing(object sender, EventArgs e)
        {
            if (AppSettings.Vibrate)
            {
                Xamarin.Essentials.Vibration.Vibrate(200);
            }
            _appShell.FlyoutIsPresented = true;
            _appShell.FlyoutIsPresented = false;
            _appShell.ForceLayout();           
        }

        private void InitMainViewModel()
        {         
            _mainViewModel.ChartIconSource = "Chart.png";
            _mainViewModel.HeaderImageSource = "Header.jpg";
            _mainViewModel.HomeIconSource = "Home.png";
            _mainViewModel.SettingsIconSource = "Settings2.png";
        }
    }
}

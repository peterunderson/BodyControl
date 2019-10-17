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
        private readonly App _app;
        private readonly PageManager _pageManager;
        private readonly MainViewModel _mainViewModel;
        private readonly DataBaseController _databaseController;

        public MainController(AppShell appShell, App app,PageManager pageManager)
        {
            _appShell = appShell;
            _app = app;
            _pageManager = pageManager;
            _mainViewModel = new MainViewModel();         
            _appShell.BindingContext = _mainViewModel;
            InitMainViewModel();

            _app.Start += _app_Start;
            _app.Sleep += _app_Sleep;
            _app.Resume += _app_Resume;          
            
            //_pageManager = new PageManager(_appShell);

            foreach (var item in _appShell.Items)
            {
                item.Appearing += Item_Appearing;
            }

            _databaseController = new DataBaseController();     
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

        private void _app_Resume(object sender, EventArgs e)
        {
            
        }

        private void _app_Sleep(object sender, EventArgs e)
        {
          
        }

        private async void _app_Start(object sender, EventArgs e)
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
    }
}

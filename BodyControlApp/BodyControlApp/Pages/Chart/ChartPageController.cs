using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp;
using BodyControlApp.Pages;
using BodyControlApp.Pages.Chart;
using Xamarin.Forms;
using BodyControlApp.Database;

namespace BodyControlApp.Pages.Chart
{
    [PageConfig("Chart", "Chart.png", 1)]
    class ChartPageController : IPageController
    {
        private readonly ChartPage _chartPage;

        public ChartPageController(ChartPage chartPage)
        {
            _chartPage = chartPage;
            Xamarin.Essentials.DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        public async Task<bool> LoadDataAsync()
        {
            await Task.Delay(10);
            return true;
        }

        public void ExecuteInitializeViewModel(BaseViewModel viewModel)
        {
            
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, Xamarin.Essentials.DisplayInfoChangedEventArgs e)
        {
            if (e.DisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Landscape)
            {
                Shell.SetNavBarIsVisible(_chartPage, false);
            }
            else
            {
                Shell.SetNavBarIsVisible(_chartPage, true);
            }
        }
    }
}

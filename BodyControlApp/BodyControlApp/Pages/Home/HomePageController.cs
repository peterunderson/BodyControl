using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.App;
using Android.Views.InputMethods;
using BodyControlApp.MVVM;

namespace BodyControlApp.Pages.Home
{
    [PageConfig("Home","Home.png","HomeWhite.png",0)]
    class HomePageController:IPageController
    {
        private readonly HomePage _homePage;
        private readonly HomePageViewModel _homePageViewModel;

        public HomePageController(HomePage _homePage,HomePageViewModel viewModel)
        {
            this._homePage = _homePage;
            _homePage.ContentViewTapped += _homePage_ContentViewTapped;
            _homePageViewModel = viewModel;
            _homePageViewModel.ButtonPenCommand = new DelegateCommand(ButtonPenClicked);
            _homePageViewModel.PenImageSource = ImageSource.FromFile("PenSmall.png");
            _homePageViewModel.ContentViewIsVisible = false;
        }



        private void _homePage_ContentViewTapped(object sender, EventArgs e)
        {

            _homePageViewModel.ContentViewIsVisible = false;
        }

        private void ButtonPenClicked(object obj)
        {
            _homePageViewModel.ContentViewIsVisible = true;
            
        }

        public async Task<bool> LoadDataAsync()
        {
            
            return true;
        }
    }
}

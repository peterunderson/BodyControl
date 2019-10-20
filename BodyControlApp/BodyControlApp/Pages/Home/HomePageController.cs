using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.App;
using Android.Views.InputMethods;
using BodyControlApp.MVVM;
using BodyControlApp.Database;

namespace BodyControlApp.Pages.Home
{
    [PageConfig("Home","Home.png",0)]
    class HomePageController:IPageController
    {
        private  HomePage _homePage;
        private  HomePageViewModel _homePageViewModel;

        public HomePageController(HomePage _homePage)
        {
            this._homePage = _homePage;
        }

        private void ButtonPenClicked(object obj)
        {
            _homePageViewModel.PopupIsOpen = true;
        }

        public async Task<bool> LoadDataAsync(DataBaseController controller)
        {
            
            return true;
        }

        public void ExecuteInitializeViewModel(BaseViewModel viewModel)
        {
            _homePageViewModel = viewModel as HomePageViewModel;
            _homePageViewModel.ButtonPenCommand = new DelegateCommand(ButtonPenClicked);
            _homePageViewModel.ButtonSaveCommand = new DelegateCommand(ButtonSave);
        }

        private void ButtonSave(object obj)
        {
            var erigth = _homePageViewModel.WeigthInputValue;
            _homePageViewModel.PopupIsOpen = false;
        }
    }
}

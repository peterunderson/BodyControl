using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodyControlApp.Pages
{
    interface IPageController
    {
        Task<bool> LoadDataAsync();

        void ExecuteInitializeViewModel(BasicViewModel viewModel);
    }
}

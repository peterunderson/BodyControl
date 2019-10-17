using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database;

namespace BodyControlApp.Pages
{
    interface IPageController
    {
        Task<bool> LoadDataAsync(DataBaseController controller);

        void ExecuteInitializeViewModel(BaseViewModel viewModel);
    }
}

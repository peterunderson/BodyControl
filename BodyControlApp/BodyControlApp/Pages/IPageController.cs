﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database;

namespace BodyControlApp.Pages
{
    interface IPageController
    {
        Task<bool> LoadDataAsync();

        void ExecuteInitializeViewModel(BaseViewModel viewModel);
    }
}

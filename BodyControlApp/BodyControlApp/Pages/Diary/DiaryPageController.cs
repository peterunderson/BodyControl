﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodyControlApp.Pages.Diary
{
    [FlyoutItem("Tagebuch", "Book.png", 2)]
    class DiaryPageController : IPageController
    {
        public DiaryPageController(DiaryPage diaryPage,DiaryPageViewModel diaryPageViewModel)
        {

        }
        public async Task<bool> LoadDataAsync()
        {
           return true;
        }
    }
}
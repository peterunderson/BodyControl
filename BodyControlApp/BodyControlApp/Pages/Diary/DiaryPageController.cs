using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database;

namespace BodyControlApp.Pages.Diary
{
    [PageConfig("Tagebuch", "Book.png", 2)]
    class DiaryPageController : IPageController
    {
        public DiaryPageController(DiaryPage diaryPage)
        {

        }
        public async Task<bool> LoadDataAsync(DataBaseController controller)
        {
           return true;
        }

        public void ExecuteInitializeViewModel(BaseViewModel viewModel)
        {
           
        }
    }
}

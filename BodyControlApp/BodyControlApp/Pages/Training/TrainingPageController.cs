using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database;

namespace BodyControlApp.Pages.Training
{
    [PageConfig("Training", "Dumbell.png","DumbellWhite.png", 3)]
    class TrainingPageController : IPageController
    {
        public TrainingPageController(TrainingPage trainingPage)
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

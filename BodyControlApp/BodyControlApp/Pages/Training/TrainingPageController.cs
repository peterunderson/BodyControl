using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodyControlApp.Pages.Training
{
    [FlyoutItem("Training", "Dumbell.png", 3)]
    class TrainingPageController : IPageController
    {
        public TrainingPageController(TrainingPage trainingPage,TrainingPageViewModel trainingPageViewModel)
        {

        }
        public async Task<bool> LoadDataAsync()
        {
            return true;
        }
    }
}

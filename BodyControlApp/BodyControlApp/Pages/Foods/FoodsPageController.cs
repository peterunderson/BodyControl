using System.Threading.Tasks;
using BodyControlApp.Database;

namespace BodyControlApp.Pages.Foods
{
    [PageConfig("Lebensmittel", "Food.png", 4)]
    class FoodsPageController :IPageController
    {
        private readonly FoodsPage _foodsPage;

        public FoodsPageController(FoodsPage foodsPage)
        {
            _foodsPage = foodsPage;
        }
        public async Task<bool> LoadDataAsync(DataBaseController controller)
        {
            await Task.Delay(10);
            return true;
        }

        public void ExecuteInitializeViewModel(BaseViewModel viewModel)
        {
            
        }
    }
}

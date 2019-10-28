using System.Threading.Tasks;
using BodyControlApp.Database;
using BodyControlApp.Database.SqLite;
using BodyControlApp.Database.SqLite.Tables;
using BodyControlApp.MVVM;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace BodyControlApp.Pages.Foods
{
    [PageConfig("Lebensmittel", "Food.png", 4)]
    class FoodsPageController :IPageController
    {
        private readonly FoodsPage _foodsPage;
        private  FoodsPageViewModel _viewModel;

        public FoodsPageController(FoodsPage foodsPage)
        {
            _foodsPage = foodsPage;
        }
        public async Task<bool> LoadDataAsync()
        {
            _viewModel.ListViewItemSource = await DataBaseHelper.Database.GetItemsAsync();
            return true;
        }

        public void ExecuteInitializeViewModel(BaseViewModel viewModel)
        {
            _viewModel = viewModel as FoodsPageViewModel;
            _viewModel.SearchBarTextChangedCommand = new DelegateCommand(SearchBarTextChanged);
        }

        private void SearchBarTextChanged(object obj)
        {
            var grid = (obj as Grid);
            var searchBar = grid.Children[0] as SearchBar;
            var listview = grid.Children[1] as SfListView;

            if (listview.DataSource != null)
            {
                listview.DataSource.Filter = o =>
                {
                    if (searchBar == null || searchBar.Text == null)
                        return true;
                    var item = o as GenericFoods;
                    return (item.name_D.ToLower().Contains(searchBar.Text.ToLower()));
                };
                listview.DataSource.RefreshFilter();
            }
            listview.RefreshView();
        }

        
    }
}

using System.Collections.Generic;
using System.Windows.Input;
using BodyControlApp.Database.SqLite.Tables;
using Syncfusion.DataSource;

namespace BodyControlApp.Pages.Foods
{
    class FoodsPageViewModel :BaseViewModel
    {
        private List<GenericFoods> _listViewItemSource;
        public List<GenericFoods> ListViewItemSource
        {
            get => _listViewItemSource;
            set
            {
                _listViewItemSource = value;
                OnPropertyChanged();
            }
        }

        private ICommand _searchBarTextChangedCommand;
        public ICommand SearchBarTextChangedCommand
        {
            get => _searchBarTextChangedCommand;
            set
            {
                _searchBarTextChangedCommand = value;
                OnPropertyChanged();
            }
        }
    }
}

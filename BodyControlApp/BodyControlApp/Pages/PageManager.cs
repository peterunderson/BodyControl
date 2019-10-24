using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BodyControlApp.Pages.Home;
using BodyControlApp.Pages.Chart;
using BodyControlApp.Pages.Settings;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using BodyControlApp.Database;
using BodyControlApp.Database.SqLite.Tables;

namespace BodyControlApp.Pages
{
    class PageManager
    {
        private readonly List<IPageController> _pageControllers;
        private readonly AppShell _appShell;
        private DataBaseController _dataBaseController;

        public PageManager(AppShell appShell)
        {
            _pageControllers = new List<IPageController>();
            _appShell = appShell;
        }


        readonly Dictionary<int, ShellSection> _shellItems = new Dictionary<int, ShellSection>();
        private void AddFlyoutItem(ContentPage page, PageConfigAttribute flyoutItemAttribute)
        {
            ShellSection shellSection = new ShellSection
            {
                Title = flyoutItemAttribute.FlyoutName,
                Icon =  flyoutItemAttribute.FlyoutIcon,
            };
            shellSection.Items.Add(new ShellContent() { Content = page });
            _shellItems.Add(flyoutItemAttribute.FlyoutItemPosition, shellSection);
        }

        public void InitializePageSystem()
        {
            var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
            var pageControllers = assemblyTypes.Where(c => c.Name.Contains("Controller") 
                                                           && c.GetInterfaces().Any(i => i == typeof(IPageController))).ToList();

            for (int i = 0; i < pageControllers.Count(); i++)
            {
                Type page = assemblyTypes.FirstOrDefault(p => p.Namespace == pageControllers.ElementAt(i).Namespace 
                                                              && p.Name.Contains("Page") && p.BaseType == typeof(BasePage));
                PageConfigAttribute attribute = pageControllers.ElementAt(i).GetCustomAttribute<PageConfigAttribute>();
                if (attribute == null)
                    attribute = new PageConfigAttribute("","",0);
                Type viewModelType = assemblyTypes.FirstOrDefault(p => p.Namespace == pageControllers.ElementAt(i).Namespace
                                                                       && p.Name.Contains("ViewModel") && p.BaseType == typeof(BaseViewModel));
                if (page != null && viewModelType != null)
                {
                    Initialize(page, viewModelType, attribute, pageControllers, i);
                }
            }
            AddFlyoutItemsToShell();           
        }

        private void Initialize(Type page, Type viewModelType, PageConfigAttribute attribute, List<Type> pageControllers, int index)
        {
            ContentPage currPage = (BasePage) Activator.CreateInstance(page);
            currPage.Appearing += CurrPage_Appearing;
            var viewModel = (BaseViewModel) Activator.CreateInstance(viewModelType);
            viewModel.NavBarImage = attribute.FlyoutIcon;
            viewModel.NavBarText = attribute.FlyoutName;
            currPage.BindingContext = viewModel;
            try
            {
                var controller =
                    (IPageController) Activator.CreateInstance(pageControllers.ElementAt(index), currPage);
                _pageControllers.Add(controller);
                controller.ExecuteInitializeViewModel(viewModel);
                AddFlyoutItem(currPage, attribute);
            }
            catch (Exception)
            {
                Debug.WriteLine("Fail to add Page Controller");
            }
        }

        private void CurrPage_Appearing(object sender, EventArgs e)
        {
            if (Shell.Current != null)
            {
                Shell.Current.FlyoutIsPresented = true;
                Shell.Current.FlyoutIsPresented = false;
                Shell.Current.ForceLayout();
            }
        }

        private void AddFlyoutItemsToShell()
        {
            foreach (var item in _shellItems.OrderBy(x => x.Key))
            {
                _appShell.Items.Add(item.Value);
            }
            _appShell.CurrentItem = _appShell.Items[0];
        }

        public async Task LoadDataAsync(DataBaseController controller)
        {
            _dataBaseController = controller;            
            foreach (var pageController in _pageControllers)
            {
                await pageController.LoadDataAsync(controller);
            }
        }
    }
}

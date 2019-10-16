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

namespace BodyControlApp.Pages
{
    class PageManager
    {
        private List<IPageController> _pageControllers;
        private AppShell _appShell;

        public PageManager(AppShell appShell)
        {
            _pageControllers = new List<IPageController>();
            _appShell = appShell;
        }


        Dictionary<int, ShellSection> shellItems = new Dictionary<int, ShellSection>();
        private void AddFlyoutItem(ContentPage page, PageConfigAttribute flyoutItemAttribute)
        {
            ShellSection shell_section = new ShellSection
            {
                Title = flyoutItemAttribute.FlyoutName,
                Icon = flyoutItemAttribute.FlyoutIcon,
            };
            shell_section.Items.Add(new ShellContent() { Content = page });
            shellItems.Add(flyoutItemAttribute.FlyoutItemPosition, shell_section);
        }

        public void InitializePageSystem()
        {
            var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
            var pageControllers = assemblyTypes.Where(c => c.Name.Contains("Controller") && c.GetInterfaces().Any(i => i == typeof(IPageController)));

            for (int i = 0; i < pageControllers.Count(); i++)
            {
                ContentPage currPage;
                Type page = assemblyTypes.FirstOrDefault(p => p.Namespace == pageControllers.ElementAt(i).Namespace && p.Name.Contains("Page") && p.BaseType == typeof(BasePage));
                PageConfigAttribute attribute = pageControllers.ElementAt(i).GetCustomAttribute<PageConfigAttribute>();
                if (attribute == null)
                    attribute = new PageConfigAttribute("","","",0);
                Type viewModelType = assemblyTypes.FirstOrDefault(p => p.Namespace == pageControllers.ElementAt(i).Namespace && p.Name.Contains("ViewModel") && p.BaseType == typeof(BasicViewModel));
                if (page != null && viewModelType != null)
                {
                    currPage = (BasePage)Activator.CreateInstance(page);
                    currPage.Appearing += CurrPage_Appearing;
                    var viewModel = (BasicViewModel)Activator.CreateInstance(viewModelType);
                    viewModel.NavBarImage = attribute.NavBarImage;
                    viewModel.NavBarText = attribute.FlyoutName;
                    currPage.BindingContext = viewModel;
                    try
                    {
                        var controller =
                            (IPageController) Activator.CreateInstance(pageControllers.ElementAt(i), currPage);
                        _pageControllers.Add(controller);
                        controller.ExecuteInitializeViewModel(viewModel);
                        AddFlyoutItem(currPage, attribute);
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("Fail to add Page Controller");
                    }
                }
            }
            AddFlyoutItemsToShell();           
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
            foreach (var item in shellItems.OrderBy(x => x.Key))
            {
                _appShell.Items.Add(item.Value);
            }
            _appShell.CurrentItem = _appShell.Items[0];
        }

        public async Task FillPages()
        {
            foreach (var pageController in _pageControllers)
            {
                await pageController.LoadDataAsync();
            }
        }
    }
}

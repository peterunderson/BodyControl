using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Views;
using BodyControlApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Application = Android.App.Application;

namespace BodyControlApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public event EventHandler<BackButtonEventArgs> BackButton; 
        public AppShell(App app)
        {
            new ServiceProvider(app,this);
            var manager = new PageManager(this);
            manager.InitializePageSystem();
            InitializeComponent();
            new MainController(this, manager);
            // TabIndex = 3;
            //var list =  Items;
            // CurrentItem = list[1]; 
        }

        protected override bool OnBackButtonPressed()
        {
           var args = new BackButtonEventArgs();
           OnBackButton(args);
           if (args.Cancel)
           {
               base.OnBackButtonPressed();
               return true;
           }
           else
           {
               return false;
           }
        }

        protected virtual void OnBackButton(BackButtonEventArgs e)
        {
            BackButton?.Invoke(this, e);
        }
    }
}
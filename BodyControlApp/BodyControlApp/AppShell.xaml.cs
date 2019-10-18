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
        public AppShell()
        {
            var manager = new PageManager(this);
            manager.InitializePageSystem();
            InitializeComponent();
            new MainController(this, manager);
            // TabIndex = 3;
            //var list =  Items;
            // CurrentItem = list[1]; 
        }
    }
}
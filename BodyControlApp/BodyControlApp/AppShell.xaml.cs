using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BodyControlApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {       
        public AppShell(App app)
        {
            var manager = new PageManager(this);
            manager.InitializePageSystem();
            InitializeComponent();
            var main = new MainController(this,app, manager);
            // TabIndex = 3;
            //var list =  Items;
            // CurrentItem = list[1];        
            
        }
     
    }
}
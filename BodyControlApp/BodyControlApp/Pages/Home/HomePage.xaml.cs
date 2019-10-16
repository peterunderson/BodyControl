using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BodyControlApp.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public event EventHandler ContentViewTapped;
        public HomePage()
        {
            InitializeComponent();            
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (o, e) =>  OnContentViewTapped(); 
            contentView.GestureRecognizers.Add(tapGestureRecognizer);
            this.Disappearing += (o, e) => OnContentViewTapped();           
            
        }        

        private void OnContentViewTapped()
        {
            this.entry.Unfocus();
            ContentViewTapped?.Invoke(this, EventArgs.Empty);
        }
 
    }
}
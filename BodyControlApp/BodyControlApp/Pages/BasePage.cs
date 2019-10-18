using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Application = Xamarin.Forms.Application;
using View = Xamarin.Forms.View;

namespace BodyControlApp.Pages
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            SetDynamicResource(View.BackgroundColorProperty, "PageBackgroundColor");

            Image image = new Image();
            image.SetBinding(Image.SourceProperty,"NavBarImage");
            image.HeightRequest = 30;
            image.WidthRequest = 30;
            image.VerticalOptions = LayoutOptions.Center;

            Label label = new Label();
            label.SetBinding(Label.TextProperty,"NavBarText");
            label.FontSize = 20;
            label.TextColor = Color.White;
            label.VerticalOptions = LayoutOptions.Center;

            StackLayout stack = new StackLayout() { Children = { image,label } };
            stack.HorizontalOptions = LayoutOptions.StartAndExpand;
            stack.HeightRequest = 20;
            stack.Orientation = StackOrientation.Horizontal;

            Shell.SetTitleView(this, stack);
        }
    }
}
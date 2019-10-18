using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using BodyControlApp.Droid.Renderers;
using BodyControlApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(IconView), typeof(IconViewRenderer))]

namespace BodyControlApp.Droid.Renderers
{
    public class IconViewRenderer : ViewRenderer<IconView, ImageView>
    {
        private bool _isDisposed;

        public IconViewRenderer()
        {
            base.AutoPackage = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }

        private Xamarin.Forms.Color GetColor(object value)
        {
            if (value is Xamarin.Forms.Color color) return color;
            else if (value is DynamicResource resource)
                return (Xamarin.Forms.Color)App.Current.Resources[resource.Key]; // get the DynamicResource 
            else if (value is string code) return Xamarin.Forms.Color.FromHex(code);
            //...
            else return Xamarin.Forms.Color.Transparent;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<IconView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                SetNativeControl(new ImageView(Context));
            }
            UpdateBitmap(e.OldElement);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == IconView.SourceProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
            else if (e.PropertyName == IconView.ForegroundProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
        }

        private void UpdateBitmap(IconView previous = null)
        {
            if (!_isDisposed && !string.IsNullOrWhiteSpace(Element.Source))
            {
                var d = Resources.GetDrawable(Element.Source).Mutate();
                var color = GetColor(Element.Foreground);
                Xamarin.Forms.Color col = (Xamarin.Forms.Color)Element.Foreground;
                d.SetColorFilter(new LightingColorFilter(col.ToAndroid(), col.ToAndroid()));
                d.Alpha = col.ToAndroid().A;
                Control.SetImageDrawable(d);
                ((IVisualElementController)Element).NativeSizeChanged();
            }
        }
    }
}


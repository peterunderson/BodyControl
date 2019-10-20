using System.Collections.Generic;
using System.Windows.Input;
using BodyControlApp.Themes;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BodyControlApp.Pages
{
	public class IconView : View
	{
		#region ForegroundProperty


		public static readonly BindableProperty ForegroundProperty = BindableProperty.Create(nameof(Foreground), typeof(object), typeof(IconView), default(Color));

		public Color Foreground { 
			get
            {              
                return (Color)GetValue (ForegroundProperty); 
			} 
			set 
            { 
                SetValue (ForegroundProperty, value); 
			} 
		}

       

        #endregion

        #region SourceProperty

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(IconView), default(string));

		public string Source { 
			get { 
				return (string)GetValue (SourceProperty); 
			} 
			set { 
				SetValue (SourceProperty, value); 
			} 
		}

		#endregion
	}
}


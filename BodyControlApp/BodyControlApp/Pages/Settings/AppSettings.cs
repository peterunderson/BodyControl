using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BodyControlApp.Pages.Settings
{
   static class AppSettings
    {
        public static bool Vibrate
        {
            get
            {
                return Preferences.Get("Vibrate", true);
            }
            set
            {
                Vibration.Vibrate(100);
                Preferences.Set("Vibrate", value);
            }
        }

        public static void ClearSettings()
        {
            Preferences.Clear();
        }
    }
}

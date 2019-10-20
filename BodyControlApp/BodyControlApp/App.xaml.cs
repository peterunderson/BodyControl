using System;
using System.Collections.Generic;
using BodyControlApp.Themes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BodyControlApp
{
    public partial class App : Application
    {
        public event EventHandler Start;
        public event EventHandler Sleep;
        public event EventHandler Resume;

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU5NzA5QDMxMzcyZTMzMmUzMFcxOS9DMmtXbzd3elFzc2lCcCtUWWI0aXBEZE9XSjJlMEtKK0M1Y0h1QmM9");
            InitializeComponent();
            new ServiceProvider(this);
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnStarting();
        }

        protected override void OnSleep()
        {
            OnSleeping();
        }

        protected override void OnResume()
        {
            OnResumeing();
        }

        private void OnStarting()
        {
            Start?.Invoke(this,EventArgs.Empty);
        }

        private void OnSleeping()
        {
            Sleep?.Invoke(this, EventArgs.Empty);
        }

        private void OnResumeing()
        {
            Resume?.Invoke(this, EventArgs.Empty);
        }
    }
}

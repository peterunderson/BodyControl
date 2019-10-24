using System;
using System.Collections.Generic;
using System.Text;
using BodyControlApp.Pages;

namespace BodyControlApp
{
    public sealed class ServiceProvider
    {
        public event EventHandler OnStart;
        public event EventHandler OnSleep;
        public event EventHandler OnResume;
        public event EventHandler<BackButtonEventArgs> OnBackButton; 
        public static ServiceProvider Current;

        public ServiceProvider(App app,AppShell appShell)
        {
            if (Current == null)
            {
                appShell.BackButton += AppShell_BackButton;
                app.Start += App_Start;
                app.Sleep += App_Sleep;
                app.Resume += App_Resume;
                Current = this;
            }
            else
            {
                throw new NotSupportedException("Current ServiceProveider already exists");
            }
        }

        private void AppShell_BackButton(object sender, Pages.BackButtonEventArgs e)
        {
           OnOnBackButton(e);
        }

        private void App_Resume(object sender, EventArgs e)
        {
            OnOnResume();
        }

        private void App_Sleep(object sender, EventArgs e)
        {
           OnOnSleep();
        }

        private void App_Start(object sender, EventArgs e)
        {
           OnOnStart();
        }

        private void OnOnStart()
        {
            OnStart?.Invoke(this, EventArgs.Empty);
        }

        private void OnOnResume()
        {
            OnResume?.Invoke(this, EventArgs.Empty);
        }

        private void OnOnSleep()
        {
            OnSleep?.Invoke(this, EventArgs.Empty);
        }

        private void OnOnBackButton(BackButtonEventArgs e)
        {
            OnBackButton?.Invoke(this, e);
        }
    }
}

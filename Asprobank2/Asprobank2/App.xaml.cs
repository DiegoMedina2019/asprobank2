using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Asprobank2.Services;
using Asprobank2.Views;

namespace Asprobank2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            if (false)
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

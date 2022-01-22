using System;
using System.Collections.Generic;
using System.Windows.Input;
using Asprobank2.ViewModels;
using Asprobank2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asprobank2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetalleMensajePage), typeof(DetalleMensajePage));
           // Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ShellInvitados();
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}

    }
}

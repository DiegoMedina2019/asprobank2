using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Asprobank2.Models;
using Asprobank2.Views;
using Asprobank2.ViewModels;

namespace Asprobank2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesPage : ContentPage
    {
        private MensajesViewModel vm;

        public NotificacionesPage()
        {
            InitializeComponent();

            BindingContext = vm = new MensajesViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadMensajes();
        }
    }
}
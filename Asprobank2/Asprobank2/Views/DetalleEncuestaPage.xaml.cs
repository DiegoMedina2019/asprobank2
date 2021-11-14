using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Asprobank2.ViewModels;
using Asprobank2.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asprobank2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleEncuestaPage : ContentPage
    {
        
        private DetalleEncuestaViewModel vm;

        public DetalleEncuestaPage(Encuesta encu)
        {
            InitializeComponent();
            BindingContext = vm = new DetalleEncuestaViewModel(encu);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.getPreguntas();
        }
    }
}

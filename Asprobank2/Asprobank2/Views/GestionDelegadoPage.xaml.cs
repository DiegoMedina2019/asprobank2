using Asprobank2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asprobank2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GestionDelegadoPage : ContentPage
    {
        private DelegadoViewModel vm;
        public GestionDelegadoPage()
        {
            InitializeComponent();
            BindingContext = vm = new DelegadoViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadDelegado();
        }
    }
}
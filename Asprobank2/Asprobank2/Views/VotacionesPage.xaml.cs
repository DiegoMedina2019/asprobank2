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
    public partial class VotacionesPage : ContentPage
    {
        EncuestasViewModel vm;
        public VotacionesPage()
        {
            InitializeComponent();
            BindingContext = vm = new EncuestasViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadEncuestas("V");
        }
    }
}
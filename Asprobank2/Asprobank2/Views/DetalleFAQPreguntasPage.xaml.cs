using Asprobank2.Models;
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
    public partial class DetalleFAQPreguntasPage : ContentPage
    {
        private DetalleFAQPreguntasViewModel vm;
        public DetalleFAQPreguntasPage(FaqFamilia familia)
        {
            InitializeComponent();
            BindingContext = vm = new DetalleFAQPreguntasViewModel(familia);
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.getPreguntas();
        }
    }
}
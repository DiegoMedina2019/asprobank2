using System.ComponentModel;
using Asprobank2.ViewModels;
using Asprobank2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asprobank2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleMensajePage : ContentPage
    {
        private DetalleMjsViewModel vm;
        public DetalleMensajePage(Mensaje_obj mjs)
        {
            InitializeComponent();
            BindingContext = vm = new DetalleMjsViewModel(mjs);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.SetVisto();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Asprobank2.ViewModels;

namespace Asprobank2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FAQPage : ContentPage
    {
        FAQViewModel vm;
        public FAQPage()
        {
            InitializeComponent();
            BindingContext = vm = new FAQViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadFamilias();
        }
    }
}
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
    public partial class EditarPassPage : ContentPage
    {
        public EditarPassPage(bool isInit)
        {
            InitializeComponent();
            this.BindingContext = new ConfiguracionViewModel(isInit);
        }
    }
}
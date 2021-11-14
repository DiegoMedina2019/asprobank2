using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Asprobank2.ViewModels;


namespace Asprobank2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculadoraPage : ContentPage
    {
        public CalculadoraPage()
        {
            InitializeComponent();
            BindingContext = new CalculadoraViewModel();
        }
    }
}
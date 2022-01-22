using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Asprobank2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();
        public HomePage()
        {
            InitializeComponent();
            //imageSources.Add("carrusel1.jpg");
            //imageSources.Add("carrusel2.jpg");
            //imageSources.Add("carrusel3.jpg");

            //imgSlider.Images = imageSources;
        }
    }
}
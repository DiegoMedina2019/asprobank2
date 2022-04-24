using System;
using System.Collections.Generic;
using System.Text;


using Asprobank2.ViewModels;
using Asprobank2.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Asprobank2.Services;

namespace Asprobank2.ViewModels
{
    internal class CircularesViewModel : BaseViewModel
    {
        public Command Btn_descargaCirculares { get; }
        public CircularesViewModel()
        {
            Btn_descargaCirculares = new Command(OnDescargarCirculares);
        }

        private async void OnDescargarCirculares()
        {
            string url = App.api + "circulares";
            //await Launcher.TryOpenAsync(new Uri(url));

            try
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
                await Application.Current.MainPage.DisplayAlert("Aviso!", "Hubo un inconveniente al intentar abrir su navegador", "ok");
            }
           
        }
    }
}

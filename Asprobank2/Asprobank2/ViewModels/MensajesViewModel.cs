using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Asprobank2.Models;
using Asprobank2.Services;
using Asprobank2.Views;

namespace Asprobank2.ViewModels
{
    class MensajesViewModel: BaseViewModel
    {
        #region Atributos
        private List<Mensaje_obj> mensajesDelJson;
        private bool isLoading;
        private ObservableCollection<Mensaje_obj> mensajesList;
        public Command<Mensaje_obj> MensajeSeleccionado { get; }
        #endregion

        public MensajesViewModel()
        {
            MensajeSeleccionado = new Command<Mensaje_obj>(OnClickMjs);
        }

        #region Propiedades
        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; this.OnPropertyChanged(); }
        }
        public ObservableCollection<Mensaje_obj> MensajesList
        {
            get { return mensajesList; }
            set { mensajesList = value; this.OnPropertyChanged(); }
        }
        #endregion

        #region Metodos
        public async Task LoadMensajes()
        {
            isLoading = true;

            mensajesDelJson = await MensajesServices.GetMensajes();
            MensajesList = new ObservableCollection<Mensaje_obj>(mensajesDelJson);

            isLoading = false;
        }
        private async void OnClickMjs(Mensaje_obj mjs)
        {
            if (mjs == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Application.Current.MainPage.Navigation.PushModalAsync(new DetalleMensajePage(mjs));
            // await Shell.Current.GoToAsync($"{nameof(DetalleMensajePage)}?{nameof(DetalleMjsViewModel.MjsID)}={mjs.idmensajes}");
        }
        #endregion
    }
}

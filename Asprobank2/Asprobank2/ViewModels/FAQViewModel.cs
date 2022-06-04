using Asprobank2.Models;
using Asprobank2.Services;
using Asprobank2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace Asprobank2.ViewModels
{
    internal class FAQViewModel:BaseViewModel
    {
        #region Atributos
        private List<FaqFamilia> familiasDelJson;
        private bool isLoading;
        private ObservableCollection<FaqFamilia> familiasList;
        public Command<FaqFamilia> FamiliaSeleccionada { get; }
        #endregion

        public FAQViewModel()
        {
            FamiliaSeleccionada = new Command<FaqFamilia>(OnClickMjs);
        }

        public void OnBusqueda(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
            {
                FamiliasList = new ObservableCollection<FaqFamilia>(familiasDelJson);
                //await Application.Current.MainPage.DisplayAlert("entre al IF!", "Las palabnra ingresada es: " + palabra, "ok");
            }
            else
            {
               var faqFamilias = familiasDelJson.Where(
                                        f => f.nombre_familia.ToLower().Contains(palabra.ToLower())
                                    ).ToList();
                //await Application.Current.MainPage.DisplayAlert("Disculpe!", "Las palabnra ingresada es: "+palabra+" se encontraron:"+ faqFamilias.Count(), "ok");
              FamiliasList = new ObservableCollection<FaqFamilia>(faqFamilias);
                
            }
        }

        #region Propiedades
        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; this.OnPropertyChanged(); }
        }
        public ObservableCollection<FaqFamilia> FamiliasList
        {
            get { return familiasList; }
            set { familiasList = value; this.OnPropertyChanged(); }
        }

        #endregion

        #region Metodos
        public async Task LoadFamilias()
        {
            isLoading = true;

            familiasDelJson = await FaqServices.GetFamiliasPreguntas();
            FamiliasList = new ObservableCollection<FaqFamilia>(familiasDelJson);

            isLoading = false;
        }
        private async void OnClickMjs(FaqFamilia familia)
        {
            if (familia == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack

            await Application.Current.MainPage.Navigation.PushModalAsync(new DetalleFAQPreguntasPage(familia));

            // await Shell.Current.GoToAsync($"{nameof(DetalleMensajePage)}?{nameof(DetalleMjsViewModel.MjsID)}={mjs.idmensajes}");
        }
        #endregion
    }
}

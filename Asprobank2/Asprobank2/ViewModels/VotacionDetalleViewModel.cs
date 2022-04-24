using Asprobank2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Asprobank2.Services;

namespace Asprobank2.ViewModels
{
    class VotacionDetalleViewModel : BaseViewModel
    {
        private List<Pregunta_> preguntasDelJson;
        private bool isLoading;
        private bool isVotacion;
        private bool isEncuesta;
        private ObservableCollection<Pregunta_> preguntasList;
        private Encuesta encu;
        private bool noPregutas;
        private bool quitarBTN;

        public Command Btn_EnviarVotacion { get; }

        public VotacionDetalleViewModel(Encuesta encu)
        {
            this.encu = encu;
            IsVotacion = encu.tipo == "V";
            IsEncuesta = encu.tipo == "E";
            Btn_EnviarVotacion = new Command(OnEnviarVotacion);
        }
        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; this.OnPropertyChanged(); }
        }
        public bool IsVotacion
        {
            get { return isVotacion; }
            set { isVotacion = value; this.OnPropertyChanged(); }
        }
        public bool IsEncuesta
        {
            get { return isEncuesta; }
            set { isEncuesta = value; this.OnPropertyChanged(); }
        }
        public bool NoPregutas
        {
            get { return noPregutas; }
            set { noPregutas = value; this.OnPropertyChanged(); }
        }
        public bool QuitarBTN
        {
            get { return quitarBTN; }
            set { quitarBTN = value; this.OnPropertyChanged(); }
        }
        private async void OnEnviarVotacion()
        {
            var respuestas = new List<Pregunta_>(PreguntasList);
            string resp = await EncuestasServices.ResponderEncuesta(respuestas, encu.idencuestacabecera);
            await Application.Current.MainPage.DisplayAlert("Aviso!", resp, "OK");
        }

        public ObservableCollection<Pregunta_> PreguntasList
        {
            get { return preguntasList; }
            set { preguntasList = value; this.OnPropertyChanged(); }
        }
        public async Task getPreguntas()
        {
            IsLoading = true;
            preguntasDelJson = await encu.getPreguntas();
            PreguntasList = new ObservableCollection<Pregunta_>(preguntasDelJson);
            foreach (Pregunta_ pregunta in preguntasList)
            {
                pregunta.setTipo();//para poder evaluar un condicional de visibilidad en la vista xaml 
            }
            NoPregutas = preguntasDelJson.Count == 0;
            QuitarBTN = preguntasDelJson.Count == 0 ? false : true;
            IsLoading = false;
        }
    }
}

using Asprobank2.ViewModels;
using Asprobank2.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Asprobank2.ViewModels
{
    public class DetalleEncuestaViewModel : BaseViewModel
    {
        private List<Pregunta_> preguntasDelJson;
        private bool isLoading;
        private bool isVotacion;
        private bool isEncuesta;
        private ObservableCollection<Pregunta_> preguntasList;
        private Encuesta encu;
        private bool noPregutas;

        public Command Btn_EnviarEncuesta { get; }

        public DetalleEncuestaViewModel(Encuesta encu)
        {
            this.encu = encu;
            IsVotacion = encu.tipo == "V";
            IsEncuesta = encu.tipo == "E";
            Btn_EnviarEncuesta = new Command(OnEnviarEncuesta);
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
        private void OnEnviarEncuesta(object obj)
        {
            
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
            NoPregutas = preguntasDelJson.Count == 0;
            IsLoading = false;
        }
    }
}
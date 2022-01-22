﻿using Asprobank2.ViewModels;
using Asprobank2.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Xamarin.Essentials;
using Asprobank2.Services;


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
        private bool quitarBTN;

        public Command Btn_EnviarEncuesta { get; }
        public Command Btn_descargarDoc { get; }

        public DetalleEncuestaViewModel(Encuesta encu)
        {
            this.encu = encu;
            IsVotacion = encu.tipo == "V";
            IsEncuesta = encu.tipo == "E";
            Btn_EnviarEncuesta = new Command(OnEnviarEncuesta);
            Btn_descargarDoc = new Command(OnDescargarDoc);
        }

        private async void OnDescargarDoc()
        {
            string url = "https://192.168.1.43:433/api/doc_encuestas/" + encu.idencuestacabecera; //local
            //var url = "https://82.159.210.91:433/api/doc_encuestas/" + encu.idencuestacabecera;;
            await Launcher.TryOpenAsync(new Uri(url));
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
        private async void OnEnviarEncuesta()
        {
            var respuestas = new List<Pregunta_>(PreguntasList);
            string resp = await EncuestasServices.ResponderEncuesta(respuestas,encu.idencuestacabecera);
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
            NoPregutas = preguntasDelJson.Count == 0;
            QuitarBTN = preguntasDelJson.Count == 0?false:true;
            IsLoading = false;
        }
    }
}
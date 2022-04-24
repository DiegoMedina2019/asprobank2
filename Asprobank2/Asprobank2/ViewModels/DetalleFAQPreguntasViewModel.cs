using Asprobank2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asprobank2.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Asprobank2.ViewModels
{
    internal class DetalleFAQPreguntasViewModel: BaseViewModel
    {
        private FaqFamilia familia;
        private List<FaqPregunta> preguntasDelJson;
        private bool isLoading;
        private ObservableCollection<FaqPregunta> preguntasList;
        private bool noPregutas;

        public DetalleFAQPreguntasViewModel(FaqFamilia familia)
        {
            this.familia = familia;
        }
        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; this.OnPropertyChanged(); }
        }
        public bool NoPregutas
        {
            get { return noPregutas; }
            set { noPregutas = value; this.OnPropertyChanged(); }
        }
        public ObservableCollection<FaqPregunta> PreguntasList
        {
            get { return preguntasList; }
            set { preguntasList = value; this.OnPropertyChanged(); }
        }
        internal async Task getPreguntas()
        {
            IsLoading = true;
            preguntasDelJson = await familia.GetPreguntas();
            PreguntasList = new ObservableCollection<FaqPregunta>(preguntasDelJson);

            NoPregutas = preguntasDelJson.Count == 0;
            IsLoading = false;
        }
    }
}

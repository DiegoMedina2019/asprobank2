using Asprobank2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Asprobank2.Services
{
    public class EncuestasServices
    {
        public static readonly HttpClient client = CrearHttpClient();

        private static HttpClient CrearHttpClient()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
            return httpClient;

        }
        public static async Task<List<Encuesta>> GetEncuestas(string tipo)
        {
            var id = Application.Current.Properties["idafiliados"].ToString();

            //string url = "https://192.168.1.38:433/api/encuestas/"+tipo+"/" + id; //local
            string url = "https://82.159.210.91:433/api/encuestas/" + tipo + "/" + id; // server

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Encuesta>>(json);
            }
            return default;
        }

        public static async Task<List<Pregunta_>> GetPreguntas(int idencuestacabecera)
        {
            var id = idencuestacabecera.ToString();
            //string url = "https://192.168.1.38:433/api/encuestas_preguntas/"+id; //local
            string url = "https://82.159.210.91:433/api/encuestas_preguntas/"+id; // server

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Pregunta_>>(json);
            }
            return default;
        }
    }
}

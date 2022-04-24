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

            string url =  App.api + "encuestas/" + tipo+"/" + id;

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
            string url = App.api + "encuestas_preguntas/" + id;

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Pregunta_>>(json);
            }
            return default;
        }

        //completar es un copy paste
        public static async Task<string> ResponderEncuesta(List<Pregunta_> respuestas,int idencuestacabecera)
        {
            var id = Application.Current.Properties["idafiliados"].ToString();
            object o = new
            {
                respuestas,
                idafiliado = id,
                idencuestacabecera
            };
            string url = App.api + "encuestas/respondida";

            string body = JsonConvert.SerializeObject(o);

            var respuesta = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
            string resp;
            if (respuesta.IsSuccessStatusCode)
            {

                string json = await respuesta.Content.ReadAsStringAsync();
                resp = JsonConvert.DeserializeObject<rsp>(json).callMjs;
            }
            else
            {
                resp = "Hubo un inconveniente al enviar su solicitud, por favor revise su internet";
            }
            return resp;
        }

    }
    internal class rsp
    {
        public string callMjs { get; set; }
    }
}

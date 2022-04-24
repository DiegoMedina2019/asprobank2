using System;
using System.Collections.Generic;
using System.Text;


using Asprobank2.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Asprobank2.Services
{
    internal class FaqServices
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
        public static async Task<List<FaqFamilia>> GetFamiliasPreguntas()
        {
            string url = App.api + "list_familias";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FaqFamilia>>(json);
            }
            return default;
        }

        public static async Task<List<FaqPregunta>> GetFaqPreguntas(int idfamiliapregunta)
        {
            object o = new
            {
                idfamilia = idfamiliapregunta
            };
            string url = App.api + "list_preguntas";

            string body = JsonConvert.SerializeObject(o);

            var response = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FaqPregunta>>(json);
            }
            return default;
        }
    }

}



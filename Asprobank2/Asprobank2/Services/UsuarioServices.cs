using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Asprobank2.Models;
using Xamarin.Forms;

namespace Asprobank2.Services
{
    class UsuarioServices
    {
        public static readonly HttpClient client = CrearHttpClient();

        private static HttpClient CrearHttpClient()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            // client = new HttpClient(httpClientHandler);
            /*
             este parte de codigo de arriba la agregue para descartar la exepciones SSL q me daba al traer el listado
            al parecer al ser certificados ssl autofirmados los detecta como invalidos desde la maquina virtual del cel
            al cer algo "externo a mi PC la cual los detecta como legitimos, 
            debo realizar algunas configuraciones para solicionar esto, ya que esto que hice es una mala practica
            ignorar la seguridad ssl"
            */
            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
            return httpClient;

        }

        internal async static Task<bool> SetPassword(string idafiliado, string pass)
        {
            //string url = "https://192.168.1.38:433/api/afiliado/" + idafiliado; //local
            string url = "https://82.159.210.91:433/api/afiliado/" +idafiliado; // server
            object a = new
            {
                password = pass
            };
            string body = JsonConvert.SerializeObject(a);
            var respuesta = await client.PutAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));

            if (respuesta.IsSuccessStatusCode)
            {
                string json = await respuesta.Content.ReadAsStringAsync();
                if (json.Contains("\"affectedRows\":1"))
                {
                    return respuesta.IsSuccessStatusCode;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return respuesta.IsSuccessStatusCode;
            }
        }

        public async static Task<bool> ValidarAfiliado(string correo, string pass) // para el Loguin
        {
            //string url = "https://192.168.1.38:433/api/login"; //local
            string url = "https://82.159.210.91:433/api/login"; // server
            Usuario a = new Usuario();
            a.email = correo;
            a.password = pass;
            string body = JsonConvert.SerializeObject(a);


            var respuesta = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));

            if (respuesta.IsSuccessStatusCode)
            {
                string json = await respuesta.Content.ReadAsStringAsync();
                List<Usuario> afi = JsonConvert.DeserializeObject<List<Usuario>>(json);

                App.Current.Properties["idafiliados"] = (respuesta.IsSuccessStatusCode) ? afi[0].idafiliado : 0;

            }
            return respuesta.IsSuccessStatusCode;


        }
        internal async static Task<bool> ValidarAfiliado(string emailTxt, string nombreTxt, string v)//sobrecarga para el registro
        {
            //string url = "https://192.168.1.38:433/api/login"; //local
            string url = "https://82.159.210.91:433/api/login"; // server
            object a = new
            {
                email = emailTxt,
                nombre = nombreTxt,
                registro = v
            };

            string body = JsonConvert.SerializeObject(a);


            var respuesta = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));

            if (respuesta.IsSuccessStatusCode)
            {
                string json = await respuesta.Content.ReadAsStringAsync();
                List<Usuario> afi = JsonConvert.DeserializeObject<List<Usuario>>(json);

                Application.Current.Properties["RegistroIdAfiliado"] = (respuesta.IsSuccessStatusCode) ? afi[0].idafiliado : 0;

            }
            return respuesta.IsSuccessStatusCode;
        }

    }
}

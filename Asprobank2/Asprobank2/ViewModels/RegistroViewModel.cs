using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Asprobank2.Models;
using Asprobank2.Services;

namespace Asprobank2.ViewModels
{

    class RegistroViewModel:BaseViewModel
    {
        private string email;
        private string nombre;
        public Command RegistrarCommand { get; }
        public RegistroViewModel()
        {
            RegistrarCommand = new Command(Registro);
        }


        public string EmailTxt
        {
            get { return email; }
            set { SetProperty(ref this.email, value); }
        }
        public string NombreTxt
        {
            get { return nombre; }
            set { SetProperty(ref this.nombre, value); }
        }

        private async void Registro()
        {
            bool respuesta = false;
            if (!string.IsNullOrEmpty(EmailTxt) && !string.IsNullOrEmpty(NombreTxt))
            {
                respuesta = await UsuarioServices.ValidarAfiliado(EmailTxt, NombreTxt, "registro"); //sobrecarga del metodo
            }

            if (respuesta)
            {
                bool passIngresada = false;
                string idafiliado = App.Current.Properties["RegistroIdAfiliado"].ToString();
                string pass = Generador.Password();
                passIngresada = await UsuarioServices.SetPassword(idafiliado, pass);

                if (passIngresada)
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.DisplayAlert("Registro exitoso!", "Su nueva Contraseña es : " + pass, "ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Disculpe!", "hubo un inconveniente, verifique su conexion a internet y repita el proceso", "ok");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Disculpe!", "No se encontraron registros para estos datos", "ok");
            }
        }
    }

}

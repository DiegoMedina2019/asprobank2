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

        //Metodo para cambiar contraseña en el caso que se olvide el usuario, esta se desencadena desde la View de Loguin
        private async void Registro()
        {
            bool respuesta = false;
            if (!string.IsNullOrEmpty(EmailTxt) && !string.IsNullOrEmpty(NombreTxt)) //Nombre es el valor del campo nombre de la tabla afiliados en la DB del server
            {
                respuesta = await UsuarioServices.ValidarAfiliado(EmailTxt, NombreTxt, "registro"); //sobrecarga del metodo
            }

            if (respuesta)
            {
                bool passIngresada = false;
                string idafiliado = App.Current.Properties["RegistroIdAfiliado"].ToString();//RegistroIdAfiliado: es la declaracion de la propiedad idafiliado 
                                                                                            //del usuario devuelta por el servicio de usuario
                string pass = Generador.Password();
                passIngresada = await UsuarioServices.SetPassword(idafiliado, pass);

                if (passIngresada)
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.DisplayAlert("Registro exitoso!", "Su nueva Contraseña es : " + pass + " Podras cambiar esta contraseña en la seccion de Configuración -> Editar Contraseña", "ok");
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

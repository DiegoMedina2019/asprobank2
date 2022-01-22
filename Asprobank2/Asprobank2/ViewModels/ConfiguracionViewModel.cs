using Asprobank2.Models;
using Asprobank2.Services;
using Asprobank2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Asprobank2.ViewModels
{
    public class ConfiguracionViewModel : BaseViewModel
    {
        private string passActual;
        private string repitPassActual;
        private string newPass;
        private bool isInit;
        public Command EditPassCommand { get; }
        public Command ViewEditPass { get; }

        public ConfiguracionViewModel(bool isInit)
        {
            IsInit = isInit;
            EditPassCommand = new Command(EditPass);
            ViewEditPass = new Command(viewEditPass);
        }

        private async void viewEditPass()
        {
            IsInit = false;
            await Application.Current.MainPage.Navigation.PushModalAsync(new EditarPassPage(IsInit));
        }

        public string PassActual
        {
            get { return passActual; }
            set { SetProperty(ref this.passActual, value); }
        }
        public string RepitPassActual
        {
            get { return repitPassActual; }
            set { SetProperty(ref this.repitPassActual, value); }
        }
        public string NewPass
        {
            get { return newPass; }
            set { SetProperty(ref this.newPass, value); }
        }
        public bool IsInit
        {
            get { return isInit; }
            set { SetProperty(ref this.isInit, value); }
        }
        private async void EditPass()
        {
            if (!string.IsNullOrEmpty(PassActual) && !string.IsNullOrEmpty(RepitPassActual) && !string.IsNullOrEmpty(NewPass) && NewPass.Equals(RepitPassActual) )
            {
                bool passIngresada = false;
                string idafiliado = App.Current.Properties["idafiliados"].ToString();
                if (IsInit)
                {
                    passIngresada = await UsuarioServices.SetPassword(idafiliado, NewPass, IsInit);
                }
                else
                {
                    passIngresada = await UsuarioServices.SetPassword(idafiliado, NewPass);
                }

                if (passIngresada)
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    if (IsInit)
                    {
                        Application.Current.MainPage = new AppShell();
                    }
                    await Application.Current.MainPage.DisplayAlert("Registro exitoso!", "Su Contraseña fue actualizada", "ok");


                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Disculpe!", "hubo un inconveniente, verifique su conexion a internet y repita el proceso", "ok");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Disculpe!", "Verifique que los campos solicitados esten completos y las Contraseña nueva como la repetida sean iguales", "ok");
            }

        }
    }
}

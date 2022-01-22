using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Asprobank2.Models;
using Asprobank2.Services;
using Asprobank2.Views;

namespace Asprobank2.ViewModels
{
    public class DelegadoViewModel: BaseViewModel
    {
        private Delegado _delegado;
        private bool isLoading;

        private string delegado;
        private string emaildelegado;
        private string oficinadelegado;
        private string domicilio;
        private string codigopostal;
        private string poblacion;
        private string provincia;
        private string telefono1;
        private string telefono2;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; this.OnPropertyChanged(); }
        }
        public string Delegado
        {
            get { return delegado; }
            set { delegado = value; this.OnPropertyChanged(); }
        }
        public string Email
        {
            get { return emaildelegado; }
            set { emaildelegado = value; this.OnPropertyChanged(); }
        }
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; this.OnPropertyChanged(); }
        }
        public string CodigoPostal
        {
            get { return codigopostal; }
            set { codigopostal = value; this.OnPropertyChanged(); }
        }
        public string Oficina
        {
            get { return oficinadelegado; }
            set { oficinadelegado = value; this.OnPropertyChanged(); }
        }
        public string Poblacion
        {
            get { return poblacion; }
            set { poblacion = value; this.OnPropertyChanged(); }
        }
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; this.OnPropertyChanged(); }
        }
        public string Telefono1
        {
            get { return telefono1; }
            set { telefono1 = value; this.OnPropertyChanged(); }
        }
        public string Telefono2
        {
            get { return telefono2; }
            set { telefono2 = value; this.OnPropertyChanged(); }
        }
        public async Task LoadDelegado()
        {
            isLoading = true;

            _delegado = await UsuarioServices.GetDelegado();
            try
            {
                Delegado = _delegado.delegado;
                Email = _delegado.emaildelegado;
                CodigoPostal = _delegado.codigopostal;
                Domicilio = _delegado.domicilio;
                Oficina = _delegado.oficinadelegado;
                Poblacion = _delegado.poblacion;
                Provincia = _delegado.provincia;
                Telefono1 = _delegado.telefono1;
                Telefono2 = _delegado.telefono2;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }

            isLoading = false;
        }
    }
}

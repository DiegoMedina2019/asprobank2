using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.Generic;
using Asprobank2.Models;

namespace Asprobank2.ViewModels
{
    public class CalculadoraViewModel : BaseViewModel
    {
        #region atributos
        private List<Origen> _origenes = new List<Origen>();
        private DateTime _fNacimiento;
        private DateTime _fAntiguedad;
        private double _salarioBaseMensual;
        private DateTime _fAntiguedadNivel;
        private Origen item;
        private string _total = "$";

        #region Command
        public ICommand Btn_Calcular { get; }
        //public ICommand OpenWebCommand { get; }
        #endregion

        #endregion
        public CalculadoraViewModel()
        {
            Title = "Calculadora";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            Btn_Calcular = new Command(Calculo);

            _origenes.Add(new Origen
            {
                _nombre = "CajaSur antes 31-12-1994",
                _valor = 19.5
            });
            _origenes.Add(new Origen
            {
                _nombre = "CajaSur desde 1995",
                _valor = 17.5
            });
            _origenes.Add(new Origen
            {
                _nombre = "bbk",
                _valor = 14
            });
            _origenes.Add(new Origen
            {
                _nombre = "Kutxa",
                _valor = 14
            });
            _fNacimiento = new DateTime(DateTime.Today.Year - 18, 01, 01);// .Today;
            _fAntiguedad = DateTime.Today;
            _fAntiguedadNivel = DateTime.Today;
        }

        #region Propiedades
        public Origen itemSeleccion
        {
            get { return this.item; }
            set
            {
                SetProperty(ref this.item, value);
            }
        }
        public List<Origen> Origenes
        {
            get { return this._origenes; }
            set
            {
                SetProperty(ref this._origenes, value);
            }
        }
        public DateTime F_Nacimiento
        {
            get { return this._fNacimiento; }
            set { SetProperty(ref this._fNacimiento, value); }
        }
        public DateTime F_Antiguedad
        {
            get => this._fAntiguedad;
            set => SetProperty(ref this._fAntiguedad, value);
        }
        public DateTime F_AntiguedadNivel
        {
            get => this._fAntiguedadNivel;
            set => SetProperty(ref this._fAntiguedadNivel, value);
        }
        public double Salario_Base_Mensual
        {
            get => this._salarioBaseMensual;
            set => SetProperty(ref this._salarioBaseMensual, value);
        }
        public string Resultado
        {
            get => this._total;
            set => SetProperty(ref this._total, value);
        }
        #endregion


        #region Methods
        private void Calculo()
        {
            try
            {
                if (F_Nacimiento.Year <= DateTime.Today.Year - 18)
                {
                    var c = new CalculadoraModel
                    {
                        _origen = itemSeleccion,
                        _nacimiento = F_Nacimiento,
                        _antiguedad = F_Antiguedad,
                        _antiguedadNivel = F_AntiguedadNivel,
                        _salarioBaseMensual = Salario_Base_Mensual,
                    };
                    double perdida_ocasionada = c.calcular();
                    double x = Math.Truncate(perdida_ocasionada * 100) / 100;
                    this.Resultado = $"${ x }";
                }
                else
                {
                    throw new MyExceptionFecha("La fecha debe ser menor para un adulto de 18 años");
                }

            }
            catch (Exception e)
            {
                Application.Current.MainPage.DisplayAlert("Disculpe!", "Tienes que seleccionar un origen o una fecha de nacimiento valida para un adulto de 18 años", "Aceptar");
            }

        }

        #endregion
    }
    public class MyExceptionFecha : Exception
    {
        public MyExceptionFecha() { }
        public MyExceptionFecha(string message) : base(message) { }
        public MyExceptionFecha(string message, Exception inner) : base(message, inner) { }
        protected MyExceptionFecha(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
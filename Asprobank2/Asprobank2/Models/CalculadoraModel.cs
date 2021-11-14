using System;
using System.Collections.Generic;
using System.Text;

namespace Asprobank2.Models
{
    public class CalculadoraModel
    {
        //CAMPOS DE ENTRADA
        public Origen _origen { get; internal set; }
        public DateTime _nacimiento { get; internal set; }
        public DateTime _antiguedad { get; internal set; }
        public DateTime _antiguedadNivel { get; internal set; }
        public double _salarioBaseMensual { get; internal set; }

        // CAMPOS CALCULADOS
        private DateTime _jubilacion { get; set; }
        private DateTime _fEfectoCambios { get; set; }
        private int _mesesHastaJubilacion { get; set; }
        private double _trieniosAfectados { get; set; }
        private double _importeTrienio4 { get; set; }
        private double _importeTrienio3 { get; set; }


        public CalculadoraModel()
        {
            _fEfectoCambios = new DateTime(2019, 07, 01);
        }

        public double calcular()
        {
            calcularJubilacion();
            calcularMesesHastaJubilacion();
            calcularTrieniosAfectados();
            calcularImporteTrienio4();
            calcularImporteTrienio3();
            double efecto_reduccion_trienio = _importeTrienio4 - _importeTrienio3;
            double efecto_susp_antiguedad = (_salarioBaseMensual * _origen._valor) * 0.02;

            double result = efecto_reduccion_trienio + efecto_susp_antiguedad;

            return result;
        }
        public void calcularJubilacion()
        {
            _jubilacion = _nacimiento.AddYears(65);
        }
        public void calcularMesesHastaJubilacion()
        {
            int year = _jubilacion.Year - _fEfectoCambios.Year;
            int mesesDiff = _jubilacion.Month - _fEfectoCambios.Month;
            _mesesHastaJubilacion = (year * 12) + mesesDiff;
        }
        public void calcularTrieniosAfectados()
        {
            _trieniosAfectados = (_mesesHastaJubilacion / 12) / 3;
        }
        public void calcularImporteTrienio4()
        {
            int periodo = (int)Math.Floor(_trieniosAfectados);
            double va = _salarioBaseMensual * _origen._valor * 3;
            double vf = va * ((Math.Pow(1, periodo) - Math.Pow(1.04, periodo)) / (1 - 1.04));
            _importeTrienio4 = vf;
        }
        public void calcularImporteTrienio3()
        {
            int periodo = (int)Math.Floor(_trieniosAfectados);
            double va = _salarioBaseMensual * _origen._valor * 3;
            double vf = va * ((Math.Pow(1, periodo) - Math.Pow(1.03, periodo)) / (1 - 1.03));
            _importeTrienio3 = vf;
        }

    }
}

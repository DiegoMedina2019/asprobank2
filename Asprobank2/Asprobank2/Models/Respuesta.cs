
using System;
using System.Collections.Generic;
using System.Text;

namespace Asprobank2.Models
{
    public class Respuesta
    {
        public int idencuestadetalle { get; set; }
        public int idafiliado { get; set; }
        public int Resultado { get; set; }
        public string ResultadoSN { get; set; }
        public int ResultadoValor { get; set; }
    }
}

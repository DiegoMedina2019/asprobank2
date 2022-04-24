using System;
using System.Collections.Generic;
using System.Text;

namespace Asprobank2.Models
{
    public class FaqPregunta
    {
        public int idpregunta { get; set; }
        public int idFamiliapregunta { get; set; }
        public string pregunta { get; set; }
        public string respuesta { get; set; }
    }

}

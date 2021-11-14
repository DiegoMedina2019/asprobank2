namespace Asprobank2.Models
{
    public class Pregunta_
    {
        public bool isSN { get; set; }
        public bool isValor { get; set; }

        public int idencuestadetalle { get; set; }
        public string Pregunta { get; set; }
        public int Resultado { get; set; }
        public Respuesta respuesta { get; set; }

    }

}
using System;
using System.Collections.Generic;
using System.Text;
using Asprobank2.Services;
using System.Threading.Tasks;

namespace Asprobank2.Models
{
    public class FaqFamilia
    {
        public int idfamiliapregunta { get; set; }
        public string nombre_familia { get; set; }

        public List<FaqPregunta> faq_preguntas { get; set; }


        public async Task<List<FaqPregunta>> GetPreguntas()
        {
            faq_preguntas = await FaqServices.GetFaqPreguntas(this.idfamiliapregunta);
            return faq_preguntas;
        }
    }

}

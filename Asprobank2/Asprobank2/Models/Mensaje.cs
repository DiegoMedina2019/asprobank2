using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Asprobank2.Services;

namespace Asprobank2.Models
{
    public class Mensaje_obj
    {
        public string nombre { get; set; }//es el nombre de la empresas
        public int idmensaje { get; set; }
        public int idafiliado { get; set; }
        //public int idoperador { get; set; }
        public string Mensaje { get; set; }
        //public string Fichero { get; set; }
        public DateTime Fecha;
        //public DateTime FechaVisto { get; set; }
        public string idEmpresa { get; set; }
        //public int borrado { get; set; }
        //public DateTime idCreacion;
        //public DateTime idModificacion;
        //public DateTime idBorrado;
        //public int insertado { get; set; }

        public string Fecha_
        { //pude formatear la fecha rara q viene desde node.Js ejemplo: 2020-12-05T21:24:14.000Z 
          //pero no estoy seguro si es la hora correcta

            get
            {
                var f = Fecha.ToString();
                return String.Format("{0:dd/MM/yyyy}", Fecha);
            }//  DateTime.Parse(f, CultureInfo.InvariantCulture).ToString() ; }
            set { Fecha = DateTime.Parse(value); }
        }
        //public string Fecha_Visto 
        //{ 
        //    get { return FechaVisto.ToString(); }
        //    set { FechaVisto = DateTime.Parse(value); }
        //}
        //public string IdCreacion
        //{
        //    get { return idCreacion.ToString(); }
        //    set { idCreacion = DateTime.Parse(value); }
        //}
        //public string IdModificacion
        //{
        //    get { return idModificacion.ToString(); }
        //    set { idModificacion = DateTime.Parse(value); }
        //}
        //public string IdBorrado
        //{
        //    get { return idBorrado.ToString(); }
        //    set { idBorrado = DateTime.Parse(value); }
        //}
        public string GetFechaMysql(DateTime f)
        {
            IFormatProvider culture =
                    new CultureInfo("es-ES", true);
            return f.GetDateTimeFormats('u', culture)[0];
        }
        public async Task SetVisto()
        {
            object o = new
            {
                FechaVisto = GetFechaMysql(DateTime.Now),
                idModificacion = GetFechaMysql(DateTime.Now)
            };

            await MensajesServices.UpdateMensajes(this.idmensaje, o);
        }
    }
}

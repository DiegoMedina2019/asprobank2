using System;
using System.Collections.Generic;
using System.Text;

namespace Asprobank2.Models
{
    public class Usuario
    {
        public int idafiliado { get; set; }
        public string codigo { get; set; }
        public string idempresa { get; set; }
        public int borrado { get; set; }
        public string razonsocial { get; set; }
        public string nombre { get; set; }
        public string nif { get; set; }
        public string direccion { get; set; }
        public string cp { get; set; }
        public string poblacion { get; set; }
        public string provincia { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public Notas notas { get; set; }
        public string email { get; set; }
        public int idoficina { get; set; }
        public string fecoficina { get; set; }
        public int idcargo { get; set; }
        public string feccargo { get; set; }
        public int idcategoria { get; set; }
        public string feccategoria { get; set; }
        public int idcenso { get; set; }
        public string feccenso { get; set; }
        public int idestado { get; set; }
        public string fecestado { get; set; }
        public int idtarifa { get; set; }
        public string fectarifa { get; set; }
        public Imagen imagen { get; set; }
        public int idBanco { get; set; }
        public int idsucursal { get; set; }
        public string DC { get; set; }
        public string NumeroCuenta { get; set; }
        public int esdelegadoter { get; set; }
        public int esdelegadozon { get; set; }
        public int esdirector { get; set; }
        public int essubdirector { get; set; }
        public int esdirectorssgg { get; set; }
        public int essubdirectorssgg { get; set; }
        public int esjefedptossgg { get; set; }
        public int extension { get; set; }
        public string emailpersonal { get; set; }
        public int esdelegado_s { get; set; }
        public int esdelegadolols_s { get; set; }
        public int esdelegadopot_s { get; set; }
        public int estadistica { get; set; }
        public int idcomite { get; set; }
        public int idorigen { get; set; }
        public int idcargosindicato { get; set; }
        public string telefono_s { get; set; }
        public DateTime idcreacion { get; set; }
        public DateTime idmodificacion { get; set; }
        public DateTime idborrado { get; set; }
        public int insertado { get; set; }
        public string facebook { get; set; }
        public string twiter { get; set; }
        public string linkedin { get; set; }
        public string DFecha_Inactivo { get; set; }
        public string HFecha_Inactivo { get; set; }
        public int idcarrera { get; set; }
        public int idclasificacion { get; set; }
        public int idempresaorigen { get; set; }
        public int idasignado { get; set; }
        public string NombreBorrar1 { get; set; }
        public string NombreBorrar2 { get; set; }
        public string cargossindicato { get; set; }
        public string comites { get; set; }
        public int cuotaborrar { get; set; }
        public int Tarifa { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaAltaEmpresa { get; set; }
        public int idestadocopia { get; set; }
        public int idempresaorigencopia { get; set; }
        public int FijoTemporal { get; set; }
        public int Sexo { get; set; }
        public int copiaoficina { get; set; }
        public int Actualizado { get; set; }
        public int equiposustitucion { get; set; }
        public int Telef2ofi { get; set; }
        public object notas2 { get; set; }
        public string CodigoOfiCorrespondencia { get; set; }
        public string NombreOfiCorrespondencia { get; set; }
        public string ProvinciaOfiCorrespondencia { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public int login_init { get; set; }
    }

    public class Notas
    {
        public string type { get; set; }
        public object[] data { get; set; }
    }

    public class Imagen
    {
        public string type { get; set; }
        public int[] data { get; set; }
    }


    //public class Afiliado
    //{
    //    public int idafiliado { get; set; }
    //    public string nombre { get; set; }
    //    public string razonsocial { get; set; }
    //    public string email { get; set; }
    //    public string password { get; set; }
    //    public object token { get; set; }
    //}
}

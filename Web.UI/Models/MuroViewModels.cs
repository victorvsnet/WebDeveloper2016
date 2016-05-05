using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.UI.Models
{
    /// <summary>
    /// Detalle de la persona que cumple años
    /// </summary>
    public class MuroViewModels
    {
        public string nombre { get; set; }
        public string ape_paterno { get; set; }
        public string gls_estado_perfil { get; set; }
        public string gls_Cargo { get; set; }
        public string anexo { get; set; }
        public int total_mensajes { get; set; }
        public string FecNacimiento { get; set; }
        public List<Organizador> Organizadores { get; set; }
        public List<Mensaje> Mensajes { get; set; }
    }

    /// <summary>
    /// Lista de los organizadores del evento, cumpleaños, coordinacion
    /// </summary>
    public class Organizador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string ape_paterno { get; set; }
        public string gls_Cargo { get; set; }
    }

    /// <summary>
    /// Lista de mensajes registrado por los demas usuarios
    /// </summary>
    public class Mensaje
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string ape_paterno { get; set; }
        public string gls_mensaje { get; set; }
    }
}
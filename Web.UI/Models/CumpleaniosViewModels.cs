using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.UI.Models
{
    /// <summary>
    /// Contiene la lista de cumpleaños del dia
    /// </summary>
    public class CumpleaniosViewModels
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string ape_paterno { get; set; }
        public string gls_Cargo { get; set; }
        public string gls_area { get; set; }
        public string Username { get; set; }
    }
}
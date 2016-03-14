using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.BusinessEntity
{
    public class BEMensajes : Entidad
    {
        public int idusuariopara { get; set; }
        public int idusuariode { get; set; }
        public string gls_mensaje { get; set; }
    }
}

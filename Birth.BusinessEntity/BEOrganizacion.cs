using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.BusinessEntity
{
    public class BEOrganizacion : Entidad
    {
        public int idusuario { get; set; }
        public int idusuariorganiza { get; set; }
        public int anio { get; set; }
        public string gls_Cumpleaniero { get; set; }
        public string gls_organizador { get; set; }
        public string gls_Cargo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.BusinessEntity
{
    public class BEUsuario : Entidad
    {
        public string gls_nombre { get; set; }
        public string gls_ape_paterno { get; set; }
        public string gls_ape_materno { get; set; }
        public string correo { get; set; }
        public int? anexo { get; set; }
        public string gls_usuario { get; set; }
        public DateTime? fec_nacimiento { get; set; }
        public int? idcargo { get; set; }
        public int? idarea { get; set; }
        public int? idempresa { get; set; }
        public int? idcategoria { get; set; }
        public string guid_user { get; set; }

        public string gls_Cargo { get; set; }
        public string gls_area { get; set; }
        public string gls_empresa { get; set; }
    }
}

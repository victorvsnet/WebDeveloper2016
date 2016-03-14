using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.BusinessEntity
{
    public abstract class Entidad
    {

        public int id { get; set; }
        public string estado { get; set; }
        public string aud_usr_ingreso { get; set; }
        public DateTime aud_fec_ingreso { get; set; }
        public string aud_usr_modificacion { get; set; }
        public DateTime aud_fec_modificacion { get; set; }

    }
}

using Birth.BusinessEntity;
using Birth.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.BusinessLogic
{
    public class BLOrganizacion
    {
        public List<BEOrganizacion> ObtenerOrganizadores(int anio, int idUsuario)
        {
            return new DAOrganizacion().ObtenerOrganizadores(anio, idUsuario);
        }
    }
}

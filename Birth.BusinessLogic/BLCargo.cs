using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth.BusinessEntity;
using Birth.DataAccess;

namespace Birth.BusinessLogic
{
    public class BLCargo
    {
        /// <summary>
        /// Obtiene todos los Cargos registrados.
        /// </summary>
        /// <returns></returns>
        public List<BECargo> ListarCargo()
        {
            return new DACargo().ListarCargo();
        }

        public BECargo ObtenerCargo(int id)
        {
            return new DACargo().ObtenerCargo(id);
        }
    }
}

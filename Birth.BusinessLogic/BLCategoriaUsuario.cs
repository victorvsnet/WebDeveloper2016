using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth.BusinessEntity;
using Birth.DataAccess;

namespace Birth.BusinessLogic
{
    public class BLCategoriaUsuario
    {
        /// <summary>
        /// Obtiene todos los CategoriaUsuario registrados
        /// </summary>
        /// <returns></returns>
        public List<BECategoriaUsuario> ListarCategoriaUsuario()
        {
            return new DACategoriaUsuario().ListarCategoriaUsuario();
        }
    }
}
